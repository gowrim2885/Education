using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.EnterpriseServices;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace ASPWebFormStudentManagementSystem.pages
{
    public partial class EditStudent : System.Web.UI.Page
    {
        string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int RollNumber = Convert.ToInt32(Request.QueryString["RollNumber"]);
                DepartmentHelper.LoadDepartment(ddlDepartment, CS);
                LoadStudent(RollNumber);
            }

        }

        private void LoadStudent(int RollNumber)
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("SELECT RollNumber, Name, Email, DepartmentID, Gender, Address, Age, DateOfBirth, Phone, AddmissionDate FROM Students WHERE RollNumber=@Rollnumber", con);
                cmd.Parameters.AddWithValue("@RollNumber", RollNumber);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    inputRollNumber.Text = RollNumber.ToString();
                    inputName.Text = reader["Name"].ToString();
                    inputEmail.Text = reader["Email"].ToString();

                    ddlDepartment.SelectedValue = reader["DepartmentID"].ToString();
                    rblGender.Text = reader["Gender"].ToString();
                    inputAddress.Text = reader["Address"].ToString();
                    inputAge.Text = reader["Age"].ToString();
                    
                    inputPhone.Text = reader["Phone"].ToString();

                    DateTime DOB = Convert.ToDateTime(reader["DateOfBirth"]);
                    inputDateOfBirth.Text = DOB.ToString("yyyy-MM-dd");

                    DateTime addmissionDate = Convert.ToDateTime(reader["AddmissionDate"]);
                    inputAddmissionDate.Text = DOB.ToString("yyyy-MM-dd");
     
                }
            }
        }
        protected void UpdateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("UpdateStudentInfo", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@RollNumber", inputRollNumber.Text);
                    cmd.Parameters.AddWithValue("@Name", inputName.Text);
                    cmd.Parameters.AddWithValue("@Email", inputEmail.Text);
                    cmd.Parameters.AddWithValue("@DepartmentID", Convert.ToInt32(ddlDepartment.Text));
                    cmd.Parameters.AddWithValue("@Address", inputAddress.Text);
                    cmd.Parameters.AddWithValue("@Gender", rblGender.Text);
                    cmd.Parameters.AddWithValue("@Age", Convert.ToInt32(inputAge.Text));
                    cmd.Parameters.AddWithValue("@DateOfBirth", Convert.ToDateTime(inputDateOfBirth.Text));
                    cmd.Parameters.AddWithValue("@Phone", inputPhone.Text);

                    con.Open();
                    int changes = (int)cmd.ExecuteNonQuery();

                    if (changes > 0)
                    {
                        string script = "alert('Student Updated Successfully'); window.location='DisplayPage.aspx';";
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
                    }
                }
            }
            catch (SqlException ex)
            {
                string message = ex.Message;
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('An Error Occurred: " + message + "');", true);

            }
        }

        protected void CancelBtn_Click(object sender, EventArgs e)
        {
            string script = "window.location='DisplayPage.aspx';";
            ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
        }
    }
}