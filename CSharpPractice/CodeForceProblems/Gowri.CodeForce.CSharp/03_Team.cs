namespace Gowri.CodeForce.CSharp
{
    public class _03_Team
    {
        public static void FindTeamSolun()
        {
            int n = Convert.ToInt32(Console.ReadLine());

            int j;
            string user;
           
            int total = 0;

            for (int i = 0; i < n; i++)
            {
                int solution = 0;
                user = Console.ReadLine();
                
                for (j = 0; j < user.Length; j++)
                {

                    if (user[j] == '1')
                    {
                        //Console.WriteLine(user[j]); 
                        solution += 1;
                    }
                    else
                    {
                        continue;
                    }
                }

                if (solution >= 2)
                {
                    total = total + 1;
                }
            }
            Console.WriteLine(total);

        }
    }
}
