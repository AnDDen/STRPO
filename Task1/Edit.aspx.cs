using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Task1
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected int id;

        protected void LoadDisciplines()
        {
            string connectionStr = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionStr);
            connection.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM DISCIPLINE", connection);
                SqlDataReader r = cmd.ExecuteReader();
                IDictionary<string, int> disc = new Dictionary<string, int>();
                while (r.Read())
                    disc[r["DisciplineName"].ToString()] = (int)r["DisciplineId"];
                addEditControl.Disciplines = disc;
            }
            finally
            {
                connection.Close();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            addEditControl.Submit += addEditControl_Submit;
            addEditControl.Cancel += addEditControl_Cancel;

            LoadDisciplines();

            if (!IsPostBack)
            {
                id = Convert.ToInt32(Request.QueryString["id"]);

                string connectionStr = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                SqlConnection connection = new SqlConnection(connectionStr);
                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT Surname, Name, ThirdName, DisciplineID, Mark FROM Students WHERE (Id = @ID)", connection);
                cmd.Parameters.AddWithValue("@ID", id);
                SqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    addEditControl.Surname = r["Surname"].ToString();
                    addEditControl.Name = r["Name"].ToString();
                    addEditControl.ThirdName = r["ThirdName"].ToString();
                    addEditControl.CurrentDiscipline = (int)r["DisciplineID"];
                    addEditControl.Mark = (int)r["Mark"];
                }
                r.Close();
                connection.Close();
            }
        }

        void addEditControl_Cancel(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        void addEditControl_Submit(object sender, EventArgs e)
        {
            string connectionStr = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionStr);
            connection.Open();
            SqlCommand cmd = new SqlCommand("UPDATE Students SET Surname=@SURNAME, Name=@NAME, ThirdName=@THIRDNAME, DisciplineID=@DISCIPLINEID, Mark=@MARK WHERE Id=@ID", connection);
            cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(Request.QueryString["id"]));
            cmd.Parameters.AddWithValue("@SURNAME", addEditControl.Surname);
            cmd.Parameters.AddWithValue("@NAME", addEditControl.Name);
            cmd.Parameters.AddWithValue("@THIRDNAME", addEditControl.ThirdName);
            cmd.Parameters.AddWithValue("@DISCIPLINEID", addEditControl.CurrentDiscipline);
            cmd.Parameters.AddWithValue("@MARK", addEditControl.Mark);
            cmd.ExecuteNonQuery();
            connection.Close();

            Response.Redirect("Default.aspx");
        }
    }
}