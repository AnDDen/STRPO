using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Task1
{
    public partial class _Default : Page
    {
        bool isSort;
        string sortExpr, order;

        protected void BindData()
        {
            string connectionStr = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            string sqlCommand;
            if (!isSort)
                sqlCommand = @"SELECT Id, Surname, Name, ThirdName, DisciplineName, Mark 
                               FROM Students JOIN Discipline ON Students.DisciplineID = Discipline.DisciplineId";
            else
            {
                sqlCommand = string.Format(@"SELECT Id, Surname, Name, ThirdName, DisciplineName, Mark 
                                            FROM Students JOIN Discipline ON Students.DisciplineID = Discipline.DisciplineId 
                                            ORDER BY {0} {1}", sortExpr, order);

                for (int i = 0; i < studGrid.Columns.Count; i++)
                {
                    if (studGrid.Columns[i].SortExpression == sortExpr)
                        studGrid.Columns[i].HeaderStyle.CssClass =
                          "gridHeader" + order;
                    else
                        studGrid.Columns[i].HeaderStyle.CssClass = "gridHeader";
                }
            }
            SqlDataSource dataSource = new SqlDataSource(connectionStr, sqlCommand);
            studGrid.DataSource = dataSource;
            studGrid.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
            if (Session["isSort"] != null)
                isSort = (bool)Session["isSort"];
            if (isSort)
            {
                sortExpr = (string)Session["sortExpr"];
                order = (string)Session["order"];
            }
        }

        protected void studGridEditCommand(object source, DataGridCommandEventArgs e)
        {
            Response.Redirect(string.Format("Edit.aspx?id={0}", Convert.ToInt32(studGrid.DataKeys[e.Item.ItemIndex])));
        }

        protected void studGridDeleteCommand(object source, DataGridCommandEventArgs e)
        {
            string connectionStr = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionStr);
            connection.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM Students WHERE Id=@ID", connection);
            cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(studGrid.DataKeys[e.Item.ItemIndex]));
            cmd.ExecuteNonQuery();
            connection.Close();

            studGrid.EditItemIndex = -1;

            BindData();
        }

        protected void studGridUpdateCommand(object source, DataGridCommandEventArgs e)
        {
            BindData();
        }

        protected void studGrid_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            studGrid.CurrentPageIndex = e.NewPageIndex;
            BindData();
        }

        protected void studGrid_SortCommand(object source, DataGridSortCommandEventArgs e)
        {
            isSort = true;
            if (sortExpr == null || sortExpr != e.SortExpression)
            {
                sortExpr = e.SortExpression;
                order = "ASC";
            }
            else order = (order == "ASC") ? "DESC" : "ASC";

            Session["isSort"] = isSort;
            Session["sortExpr"] = sortExpr;
            Session["order"] = order;

            BindData();
        }
    }
}