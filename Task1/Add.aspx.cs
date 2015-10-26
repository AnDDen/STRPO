using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Task1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
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
                if (Session["CurrentDiscipline"] != null)
                    addEditControl.CurrentDiscipline = (int)(Session["CurrentDiscipline"]);
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
            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Students (Surname, Name, ThirdName, DisciplineID, Mark) VALUES (@SURNAME, @NAME, @THIRDNAME, @DISCIPLINEID, @MARK)", connection);
                cmd.Parameters.AddWithValue("@SURNAME", addEditControl.Surname);
                cmd.Parameters.AddWithValue("@NAME", addEditControl.Name);
                cmd.Parameters.AddWithValue("@THIRDNAME", addEditControl.ThirdName);
                cmd.Parameters.AddWithValue("@DISCIPLINEID", addEditControl.CurrentDiscipline);
                cmd.Parameters.AddWithValue("@MARK", addEditControl.Mark);
                cmd.ExecuteNonQuery();
            }
            finally
            {
                connection.Close();
            }

            Session["CurrentDiscipline"] = addEditControl.CurrentDiscipline;

            Response.Redirect("Default.aspx");
        }
    }
}