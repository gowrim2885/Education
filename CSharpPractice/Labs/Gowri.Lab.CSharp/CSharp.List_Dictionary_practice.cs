namespace Gowri.Gowri.Labs.CSharp
{
    internal class ListOrDictionary
    {
        public static void ListDictoperations()
        {

            Console.WriteLine("--------------------LIST---------------------------");
            List<int> nums = new List<int>();
            nums.Add(10);
            nums.Add(20);
            nums.AddRange(new[] { 30, 40, 60, 70, 20, 10 });

            Console.WriteLine("Number of elements " + nums.Count);
            nums.Insert(2, 10);//Insert(index, value);
            foreach (var n in nums)
            {
                Console.WriteLine(n);
            }
            Console.WriteLine("Number of elements " + nums.Count);

            nums.RemoveAt(0);//using index value
            nums.Remove(10);
            foreach (var n in nums)
            {
                Console.WriteLine(n);
            }
            Console.WriteLine("Capacity of the list is " + nums.Capacity);


            Console.WriteLine("--------------------DICTIONARY---------------------------");
            Dictionary<int, string> user = new Dictionary<int, string>();
            user.Add(1, "Abi");
            user[2] = "Banu";

            foreach (var (id, name) in user)
            {
                Console.WriteLine($"{id} : {name}");
            }

            if (user.ContainsKey(1))
            {
                Console.WriteLine("User exists");
            }

            user[3] = "Charu";

            if (user.TryGetValue(2, out string foundName))
            {
                Console.WriteLine($"Found: {foundName}");
            }

        }
    }
}
