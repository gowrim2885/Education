

using Microsoft.Data.SqlClient;

namespace StudentManagementSystem.Data
{
    internal class StudentData
    {
        private readonly string CS = @"Data Source=.;Initial Catalog=Gowri;User ID=sa;Password=Gowri@2212;Encrypt=False;";

        //StudentDataBase db = new StudentDataBase();
        public void AddStudent(string strName, int nAge, string strEmail, string strDepartment)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(CS))
                {
                    string insertQuery = "INSERT INTO Students(Name, Email, Age,Department) Values(@Name, @Email, @Age, @Department)";
                    SqlCommand cmd = new SqlCommand(insertQuery, con);

                    cmd.Parameters.AddWithValue("@Name", strName);
                    cmd.Parameters.AddWithValue("@Email", strEmail);
                    cmd.Parameters.AddWithValue("@Age", nAge);
                    cmd.Parameters.AddWithValue("@Department", strDepartment);

                    con.Open();
                    cmd.ExecuteNonQuery();

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }

        }
        public void DisplayStudent()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(CS))
                {
                    //string insertQuery = "INSERT INTO Students(StudentID, Name, Email, Age,Department) Values(@Id, @Name, @Email, @Age, @Department);";
                    string DisplayQuery = "SELECT * FROM Students";
                    SqlCommand cmd = new SqlCommand(DisplayQuery, con);

                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {

                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                int id = (int)reader["StudentID"];
                                string Name = reader["Name"].ToString();
                                string Email = reader["Email"].ToString();
                                int Age = (int) reader["Age"];
                                string Department = (string)reader["Department"];
                                Console.WriteLine($"ID: {id}, Username: {Name}, Email: {Email}, Age: {Age}, Department: {Department}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No data found.");
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }

        }

        public void UpdateStudentInformtion<T>(T newdata, string strColumnName, string strName)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(CS))
                {
                    string UpdateQuery = $"UPDATE Students SET {strColumnName} = @newdata WHERE Name = @Name";
                    SqlCommand cmd = new SqlCommand(UpdateQuery, con);

                    cmd.Parameters.AddWithValue("@newdata", newdata);
                    cmd.Parameters.AddWithValue("@Name", strName);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
        public void DeleteStudentInformation(int id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(CS))
                {
                    string DeleteQuery = "Delete from Students where StudentID = @ID";
                    SqlCommand cmd = new SqlCommand(DeleteQuery, con);

                    cmd.Parameters.AddWithValue("@ID", id);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }

        public int GetCount()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Students", con);
                    con.Open();
                    int total = (int)cmd.ExecuteScalar();
                    return total;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error Occure: " + ex);
                return 0;
            }
        }

        public void FilterdStudents()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Students WHERE Age <= 20", con);
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                int id = (int)reader["StudentID"];
                                string Name = (string)reader["Name"];
                                string Email = (string)reader["Email"];
                                int Age = (int)reader["Age"];
                                string Department = (string)reader["Department"];
                                Console.WriteLine($"ID: {id}, Username: {Name}, Email: {Email}, Age: {Age}, Department: {Department}");
                            }
                                
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Occure: " + ex);
            }
        }

    }
}
