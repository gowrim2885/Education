namespace Gowri.Gowri.CSES.Gowri.CSES.Introductory_problems
{
    public class _03_Repetitions
    {
        public static void FindRepetitions() { 
            String name = Console.ReadLine();
            Console.WriteLine(name);

            int count = 1;
            Dictionary<char, int> result = new Dictionary<char, int>();

            int i = 1;
            while (i < (name.Length))
            {
                char prev = name[i - 1]; //Console.WriteLine("PREVIOUS   " + prev);
                char curr = name[i]; //Console.WriteLine("NEXT     "+curr);

                if (prev == curr)
                {
                    count++; 
                    Console.WriteLine("COUNT    " + count);
                    if (result.ContainsKey(prev))
                    {
                        result[prev] = count;
                    }
                    else
                    {
                        result.Add(prev, count);
                    }
                }
                else
                {
                    count = 1; 
                }

                i++;
            }

            //Console.WriteLine("Max count  "+count);
            int max = 0;
            foreach (var (key, value) in result)
            {    
                //Console.WriteLine($"{key}:{value}");

                if (value > max)
                {
                    max = value;
                }
            }

            
            Console.WriteLine("Output "+ max);


        }
    }

}