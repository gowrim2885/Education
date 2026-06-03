using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ASPWebFormStudentManagementSystem.pages
{
    public partial class DisplayPage : System.Web.UI.Page
    {
        string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString; 
        protected void Page_Load(object sender, EventArgs e)
        {
            DisplayStudentDetails();
        }

        protected void Delete_StudentInfo_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;

            GridViewRow row = (GridViewRow)btn.NamingContainer;

            int RowIndex = row.RowIndex;

            try
            {
                using (SqlConnection con = new SqlConnection(CS))
                {
                    using (SqlCommand cmd = new SqlCommand("DeleteStudentInfo", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        //((TextBox)GridView1.Rows[e.RowIndex].Cells[1].Controls[0]).Text;

                        int RollNumber = Convert.ToInt32(GridView1.DataKeys[RowIndex].Value);

                        cmd.Parameters.AddWithValue("@RollNumber", RollNumber);

                        con.Open();

                        int changes = (int)cmd.ExecuteNonQuery();
                        if(changes > 0)
                        {
                            Response.Write("Student " + RollNumber + " Deleted Successfully. ");
                        }
                        else
                        {
                            Response.Write("Student " + RollNumber + " Not Deleted. The data are not available on your database," +
                                "Check Again.");
                        }

                        DisplayStudentDetails();
                    }
                }
            }
            catch(Exception ex)
            {
                Response.Write("Error: " + ex.Message);
                DisplayStudentDetails();
            }
            
        }
        private void DisplayStudentDetails()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(CS))
                {
                    using (SqlDataAdapter adap = new SqlDataAdapter("DisplayStudentsInfo", con))
                    {
                        DataSet ds = new DataSet();

                        adap.Fill(ds, "StudentsList");

                        GridView1.DataSource = ds.Tables["StudentsList"];
                        GridView1.DataBind();
                        
                    }
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Error: " + message + "');", true);
            }
        }

        protected void Getdata_Click(object sender, EventArgs e)
        {
            string search_data = "%" + searchBox.Text + "%";

            if (string.IsNullOrEmpty(search_data))
            {
                DisplayStudentDetails();
            }
            else
            {
                FindStudentData(search_data);
            }
        }

        private void FindStudentData(string searchTerm)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("SearchStudent", con);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SearchTerm", searchTerm);

                    con.Open();
                    GridView1.DataSource= cmd.ExecuteReader();
                    GridView1.DataBind();

                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Error: " + message + "');", true);
            }
        }

        protected void SortAZStudentData_Click(object sender, EventArgs e)
        {
            using(SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("SortStudentInfo", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                GridView1.DataSource = cmd.ExecuteReader();
                GridView1.DataBind();
            }
        }
        protected void SortZAStudentData_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("SortStudentInfoZA", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                GridView1.DataSource = cmd.ExecuteReader();
                GridView1.DataBind();
            }
        }
    }
}