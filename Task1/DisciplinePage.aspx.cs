using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Task1
{
    public partial class DisciplinePage : System.Web.UI.Page
    {
        protected void BindData()
        {
            string connectionStr = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlDataSource dataSource = new SqlDataSource(connectionStr,
                "SELECT DisciplineId, DisciplineName FROM Discipline");
            discGrid.DataSource = dataSource;
            discGrid.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                BindData();
        }

        protected void buttonSubmit_Click(object sender, EventArgs e)
        {
            string connectionStr = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionStr);
            connection.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Discipline (DisciplineName) VALUES (@DISCIPLINENAME)", connection);
                cmd.Parameters.AddWithValue("@DISCIPLINENAME", textBoxDiscipline.Text);
                cmd.ExecuteNonQuery();
            }
            finally
            {
                connection.Close();
            }

            BindData();
        }

        protected void discGrid_DeleteCommand(object source, DataGridCommandEventArgs e)
        {
            string connectionStr = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionStr);
            connection.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM Discipline WHERE DisciplineId=@DISCIPLINEID", connection);
                cmd.Parameters.AddWithValue("@DISCIPLINEID", Convert.ToInt32(discGrid.DataKeys[e.Item.ItemIndex]));
                cmd.ExecuteNonQuery();
            }
            finally
            {
                connection.Close();
            }

            discGrid.EditItemIndex = -1;

            BindData();
        }

        protected void discGrid_EditCommand(object source, DataGridCommandEventArgs e)
        {
            discGrid.EditItemIndex = e.Item.ItemIndex;
            BindData();
        }

        protected void discGrid_UpdateCommand(object source, DataGridCommandEventArgs e)
        {           
            string connectionStr = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionStr);
            connection.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("UPDATE Discipline SET DisciplineName=@DISCIPLINENAME WHERE  DisciplineId=@DISCIPLINEID", connection);
                cmd.Parameters.AddWithValue("@DISCIPLINEID", Convert.ToInt32(discGrid.DataKeys[e.Item.ItemIndex]));
                cmd.Parameters.AddWithValue("@DISCIPLINENAME", ((TextBox)e.Item.Cells[0].Controls[0]).Text);
                cmd.ExecuteNonQuery();
            }
            finally 
            {
                connection.Close();
            }

            discGrid.EditItemIndex = -1;
            BindData();
        }

        protected void discGrid_CancelCommand(object source, DataGridCommandEventArgs e)
        {
            discGrid.EditItemIndex = -1;
            BindData();
        }
    }
}