using System;

using System.Configuration;
using System.Data;
using System.Data.SqlClient;

using System.Windows.Forms;
using System.Runtime.Caching;
using System.Linq.Expressions;


namespace DBConnection
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            string connctionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            try
            {
                MemoryCache Cache = MemoryCache.Default;

                if (Cache["Data"] == null)
                {
                    using (SqlConnection connection = new SqlConnection(connctionString))
                    {
                        string query = "SELECT * FROM Employee";
                        using (SqlDataAdapter da = new SqlDataAdapter(query, connection))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);

                            Cache["Data"] = dt;
                            dataGridView2.DataSource = dt;
                            textBox1.Text = "Data Comes from the DataBase.";
                        }
                    }
                }
                else
                {
                    dataGridView2.DataSource = Cache["Data"];
                    textBox1.Text = "Data Comes from the Cache Memory.";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }

        }

        public void LoadDataFromTwoTable()
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS2"].ConnectionString;
            try
            {
                MemoryCache Cache = MemoryCache.Default;
                if (Cache["Employees"] == null || Cache["Bank"] == null)
                {
                    using (SqlConnection con = new SqlConnection(CS))
                    {

                        SqlDataAdapter adp1 = new SqlDataAdapter("SELECT * FROM dbo.Employees", con);
                        SqlDataAdapter adp2 = new SqlDataAdapter("SELECT * FROM dbo.Bank", con);

                        DataSet ds = new DataSet();

                        adp1.Fill(ds, "Employees");
                        adp2.Fill(ds, "Bank");

                        Cache["Employees"] = ds.Tables["Employees"];
                        Cache["Bank"] = ds.Tables["Bank"];

                        dataGridView2.DataSource = ds.Tables["Employees"];
                        dataGridView3.DataSource = ds.Tables["Bank"];
                        textBox1.Text = "Data Comes from the DataBase.";

                    }
                }
                else
                {
                    dataGridView2.DataSource = Cache["Employees"];
                    dataGridView3.DataSource = Cache["Bank"];
                    textBox1.Text = "Data Comes from the Cache Memory.";
                }
                
            }
            catch(Exception e )
            {
                MessageBox.Show("An Error is Occurred" + e.Message);

            }
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView3.DataSource = null;
            dataGridView2.DataSource = null;
            textBox1.Text = "";

            LoadData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView3.DataSource = null;
            dataGridView2.DataSource = null;
            textBox1.Text = "";
            LoadDataFromTwoTable();
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
