using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace ASPWebFormStudentManagementSystem.pages
{
    public partial class Dashboard : System.Web.UI.Page
    {
        string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetDashboarData();
                LoadChartData();
            }
        }
        private void GetDashboarData()
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd1 = new SqlCommand("SELECT COUNT(*) FROM Students", con);
                SqlCommand cmd2 = new SqlCommand("SELECT COUNT(*) FROM DEPARTMENT", con);

                con.Open();
                int stdCount = (int)cmd1.ExecuteScalar();
                int DeptCount = (int)cmd2.ExecuteScalar();

                txtStudentCount.Text = stdCount.ToString();
                txtDepartmentCount.Text = DeptCount.ToString();
            }
        }

        private void LoadChartData()
        {

            using (SqlConnection con = new SqlConnection(CS))
            {
                string query = "SELECT DepartmentName, COUNT(*) AS StudentCount FROM Students JOIN DEPARTMENT ON Students.DepartmentID=DEPARTMENT.DepartmentID GROUP BY DEPARTMENT.DepartmentName;";

                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                da.Fill(dt);

                Chart1.DataSource = dt;
                Chart1.Series["Series1"].XValueMember = "DepartmentName";
                Chart1.Series["Series1"].YValueMembers = "StudentCount";
                Chart1.DataBind();
            }
        }

    }
}