using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADOPractice
{
    public class Transactions
    {
        private static string CS = "Data Source=.;initial Catalog=Gowri;USER ID=sa;Password=Gowri@2212;Encrypt=False;";
        public static void TransactionMethod()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(CS))
                {
                    con.Open();
                    SqlTransaction transaction = con.BeginTransaction();

                    try
                    {
                        SqlCommand cmd1 = new SqlCommand("Update Bank SET balance = balance - 500 where name = 'Gowri'", con, transaction);
                        int count1= (int)cmd1.ExecuteNonQuery(); 
                        
                        cmd1 = new SqlCommand("Update Bank SET balance = balance + 500 where name='Abi'", con, transaction);
                        int count2 = (int) cmd1.ExecuteNonQuery();
                        if((count1+count2) >= 2)
                        {

                            transaction.Commit();
                            Console.WriteLine("Transaction was commited");

                        }
                        else
                        {
                            transaction.Rollback();
                            Console.WriteLine("Transaction was rollbacked");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error Occur" + ex.Message);
                       
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Occur" + ex.Message);

            }

        }
    }
}
