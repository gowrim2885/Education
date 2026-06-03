using System;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

public class DepartmentHelper
{
    public static void LoadDepartment(DropDownList ddlDepartment, string CS)
    {
        try
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("Select DepartmentID, DepartmentName from DEPARTMENT", con);
                con.Open();

                ddlDepartment.DataValueField = "DepartmentID";
                ddlDepartment.DataTextField = "DepartmentName";
                SqlDataReader reader = cmd.ExecuteReader();
                ddlDepartment.DataSource = reader;
                ddlDepartment.DataBind();
                con.Close();
                ddlDepartment.Items.Insert(0, "Select Department");
            }
        }
        catch (Exception ex)
        {
            throw new Exception("Error loading Department: " + ex.Message);
        }
    }
}