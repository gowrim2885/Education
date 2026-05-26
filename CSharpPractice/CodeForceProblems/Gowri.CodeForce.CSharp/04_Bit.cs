
namespace Gowri.CodeForce.CSharp
{
    public class _04_Bit
    {
        public static void Find_Val_X() { 
            int X = 0;

            String value;
            
            int num = Convert.ToInt32(Console.ReadLine());
            string[] arr= new string[num];

            for (int i = 0; i < num; i++) {
                value = Console.ReadLine();
                arr[i] = value;
            }

            for (int i = 0; i < num; i++)
            {
                
                if (arr[i] == "X++")
                {
                    X++;
                }
                else if (arr[i] == "X--")
                {
                    X--;
                }
                else if (arr[i] == "++X")
                {
                    ++X;
                }
                else if (arr[i] == "--X")
                {
                    --X;
                }
            }

            Console.WriteLine(X);
        }
    }
}
