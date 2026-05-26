
namespace Gowri.Labs.CSharp
{
    public static class StringPractice
    {
        public static void StrPractice()
        {
            Console.WriteLine("------------------------------------------");
            String s = "    Hello World !  ";
            Console.WriteLine(s);
            Console.WriteLine("Upper Case:" + s.ToUpper());
            Console.WriteLine("Lower Case:" + s.ToLower());
            // Removes white spaces.
            Console.WriteLine("Remove space:" + s.Trim());
            Console.WriteLine("Remove space at the end of the string:" + s.TrimEnd());
            Console.WriteLine("Remove space at the end of the string:" + s.TrimStart());
            // Extracts part of a string.
            Console.WriteLine(s.Substring(4, 5));
            // Checks if string contains a value.
            Console.WriteLine(s.Contains("World"));
            Console.WriteLine(s.StartsWith("H"));
            Console.WriteLine(s.EndsWith("!  "));
            // Check the index of the Element
            Console.WriteLine(s.IndexOf('l'));
            Console.WriteLine(s.LastIndexOf('l'));
            Console.WriteLine(s.Replace("!", "!!!"));

            String s2 = "A,b,c,d,e";
            Console.WriteLine("String 2---------" + s2);
            string[] letters = s2.Split(',');
            foreach (String lets in letters)
            {
                Console.WriteLine(lets);
            }

            String joinstr = string.Join(" ", letters);
            Console.WriteLine("Joined string  " + joinstr);
            // Case sensitive
            string s4 = "Hello";
            string s5 = "hello";
            Console.WriteLine(s4.Equals(s5));
            Console.WriteLine(string.Compare(s4, s5));

            string str = " ";

            Console.WriteLine(string.IsNullOrEmpty(str));
            Console.WriteLine(string.IsNullOrWhiteSpace(str));

            // Split, Join, Replace perform string immutability
            str = str.Replace(" ", "HI");
            Console.WriteLine(str);

            string a = "Apple";
            string b = "Banana";

            int result = a.CompareTo(b);
            Console.WriteLine(result);
        }
    }
}
