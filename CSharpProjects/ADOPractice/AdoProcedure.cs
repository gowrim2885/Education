using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace DBConnection
{
    internal class AdoProcedure
    {
       private static string CS = "Data Source=.;Initial Catalog=Gowri;User ID=sa;Password=Gowri@2212;Encrypt=False";

        internal static void MainMethod()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("Select * FROM Students", con);
                    con.Open();
                    SqlDataReader Reader = cmd.ExecuteReader();

                    while (Reader.Read())
                    {
                        Console.WriteLine(Reader["StudentID"]);
                    }

                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error: "+ ex.Message);
            }

        }
        //Data Tables

        internal static void MainMethod2()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlDataAdapter adap = new SqlDataAdapter("SELECT * FROM Students", con);

                    DataTable dt = new DataTable();

                    adap.Fill(dt);

                    foreach (DataRow row in dt.Rows)
                    {
                        Console.WriteLine("StudentID: " + row["StudentID"]+ "Name: "+ row["Name"]+ "Age: "+ row["Age"]);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

        }
        //Dataset with stored procedure
        internal static void MainMethod3()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlDataAdapter adap = new SqlDataAdapter("PSGetStudents", con);
                    adap.SelectCommand.CommandType = CommandType.StoredProcedure;

                    DataSet ds = new DataSet();

                    adap.Fill(ds, "studentInfo");

                    foreach (DataRow row in ds.Tables["studentInfo"].Rows)
                    {
                        Console.WriteLine("StudentID: " + row["StudentID"] + 
                            "  Name: " + row["Name"] +
                            "  Age: " + row["Age"]+ 
                            "  Email: " + row["Email"]+ "  EnrollmentDate: " + row["EnrollmentDate"]);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

        }

        //DataTable DataColumns And DataRows
        internal static void MainMethod4()
        {
            try
            {
                DataTable table = new DataTable();

                DataColumn column1 = new DataColumn("BankID");
                column1.DataType = typeof(int);
                column1.Caption = "Back ID";
                table.Columns.Add(column1);


                DataColumn column2 = new DataColumn("Name");
                column2.DataType = typeof(string);
                column2.Caption = "Name";
                table.Columns.Add(column2);

                DataColumn column3 = new DataColumn("Balance");
                column3.DataType = typeof(decimal);
                column3.Caption = "Account Balance";
                table.Columns.Add(column3);

                table.PrimaryKey = new DataColumn[] { column1 };


                DataRow row1 = table.NewRow();
                row1[column1] = 1;
                row1[column2] = "Raju";
                row1[column3] = 1000000;
                table.Rows.Add(row1);

                DataRow row2 = table.NewRow();
                row2[column1] = 2;
                row2[column2] = "Banu";
                row2[column3] = 2000000;
                table.Rows.Add(row2);

                table.Rows.Add(3, "Kalai", 300000);

                foreach(DataRow row in table.Rows)
                {
                    Console.WriteLine("Bank ID: " + row[column1] +    " Name: " + row[column2] +  "  Balance: " + row[column3]);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

        }

        //Using Procedure with parameter 
        internal static void MainMethod5()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "InsertRecord";
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Name", "nithya");
                    cmd.Parameters.Add("@Email",SqlDbType.VarChar, 50).Value= "nithya@gmail.com";
                    SqlParameter param = new SqlParameter();
                    param.ParameterName = "@Age";
                    param.Value = 20;
                    param.SqlDbType = SqlDbType.Int;
                    cmd.Parameters.Add(param);
                    cmd.Parameters.AddWithValue("@Department", "AIDS");

                    con.Open();
                    cmd.ExecuteNonQuery();

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

        }

        //with output parameter in procedure
        internal static void MainMethod6()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "GetStudetnCount";
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter param = new SqlParameter();
                    param.SqlDbType = SqlDbType.Int;
                    param.Direction = ParameterDirection.Output;
                    param.ParameterName = "@result";

                    cmd.Parameters.Add(param);
                    con.Open();
                    cmd.ExecuteNonQuery();

                    int count = (int) param.Value;

                    Console.WriteLine(count);

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

        }

        internal static void MainMethod7()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(CS))
                {

                    SqlDataAdapter adap = new SqlDataAdapter("SELECT * FROM Students", con);
                    DataTable table = new DataTable();
                    adap.Fill(table);

                    DataView dv = new DataView(table);
                    dv.RowFilter = "Department='CSE'"; 

                    foreach(DataRowView rows in dv)
                    {
                        DataRow row = rows.Row;

                        Console.WriteLine("StudentID: " + row["StudentID"] +
                           "  Name: " + row["Name"] +
                           "  Age: " + row["Age"] +
                           "  Email: " + row["Email"] + "  EnrollmentDate: " + row["EnrollmentDate"]);
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

        }
    }
}

