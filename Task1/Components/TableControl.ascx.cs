using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Task1.Components
{
    public partial class TableControl : System.Web.UI.UserControl
    {
        private string tableName;
        public string TableName
        {
            get { return tableName; }
            set { 
                tableName = value; 
                selectFrom = tableName;
            }
        }

        private string selectFrom;
        public string SelectFrom
        {
            get { return selectFrom; }
            set { selectFrom = value; }
        }

        private string pkField;
        public string PrimareKeyField
        {
            get { return pkField; }
            set { 
                pkField = value;
                grid.DataKeyField = pkField;
            }
        }

        private IList<string> fields = new List<string>();
        public IList<string> Fields
        {
            get { return fields; }
            set { fields = value; }
        }

        private string fieldsStr;

        private void CreateColumns()
        {
            grid.Columns.Clear();
            fieldsStr = pkField;

            foreach (string field in fields) {
                BoundColumn c = new BoundColumn();
                c.DataField = field;
                c.SortExpression = field;
                c.HeaderText = field;
                grid.Columns.Add(c);

                fieldsStr += ", " + field;
            }

            EditCommandColumn editCol = new EditCommandColumn();
            editCol.EditText = "Редактировать";
            editCol.HeaderText = "Редактирование";
            grid.Columns.Add(editCol);

            ButtonColumn delCol = new ButtonColumn();
            delCol.CommandName = "Delete";
            delCol.Text = "Удаление";
            delCol.HeaderText = "Удалить";
            grid.Columns.Add(delCol);
        }

        protected void BindData()
        {
            string connectionStr = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            string sqlCommand;

            if (ViewState["isSort"] == null || !(bool)ViewState["isSort"])
                /* sqlCommand = @"SELECT Id, Surname, Name, ThirdName, DisciplineName, Mark 
                               FROM Students JOIN Discipline ON Students.DisciplineID = Discipline.DisciplineId"; */
                sqlCommand = string.Format("SELECT {0} FROM {1}", fieldsStr, selectFrom);
            else
            {
                sqlCommand = string.Format(@"SELECT {0} FROM {1} ORDER BY {2} {3}",
                    fieldsStr, selectFrom, ViewState["sortExpr"].ToString(), ViewState["order"].ToString());

                for (int i = 0; i < grid.Columns.Count; i++)
                {
                    if (grid.Columns[i].SortExpression == ViewState["sortExpr"].ToString())
                        grid.Columns[i].HeaderStyle.CssClass =
                          "gridHeader" + ViewState["order"].ToString();
                    else
                        grid.Columns[i].HeaderStyle.CssClass = "gridHeader";
                }
            }
            SqlDataSource dataSource = new SqlDataSource(connectionStr, sqlCommand);
            grid.DataSource = dataSource;
            grid.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            CreateColumns();
            BindData();
        }

        protected void gridEditCommand(object source, DataGridCommandEventArgs e)
        {
            Response.Redirect(string.Format("Edit.aspx?id={0}", Convert.ToInt32(grid.DataKeys[e.Item.ItemIndex])));
        }

        protected void gridDeleteCommand(object source, DataGridCommandEventArgs e)
        {
            string connectionStr = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionStr);
            connection.Open();
            SqlCommand cmd = new SqlCommand(string.Format("DELETE FROM {0} WHERE {1}=@ID", tableName, pkField), connection);
            cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(grid.DataKeys[e.Item.ItemIndex]));
            cmd.ExecuteNonQuery();
            connection.Close();

            grid.EditItemIndex = -1;

            BindData();
        }

        protected void gridUpdateCommand(object source, DataGridCommandEventArgs e)
        {
            BindData();
        }

        protected void grid_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            grid.CurrentPageIndex = e.NewPageIndex;
            BindData();
        }

        protected void grid_SortCommand(object source, DataGridSortCommandEventArgs e)
        {
            ViewState["isSort"] = true;
            if (ViewState["sortExpr"] == null || ViewState["sortExpr"].ToString() != e.SortExpression)
            {
                ViewState["sortExpr"] = e.SortExpression;
                ViewState["order"] = "ASC";
            }
            else
            {
                if (ViewState["order"] == null) 
                    ViewState["order"] = "ASC"; 
                else
                    ViewState["order"] = (ViewState["order"].ToString() == "ASC") ? "DESC" : "ASC";
            }

            BindData();
        }
    }
}