using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gowri.Lab.CSharp
{
    public class CollectionPractice
    {
        public static void CallAllCollection()
        {
            Console.WriteLine("===== LIST =====");
            ListExample.ListDemo();

            Console.WriteLine("\n===== DICTIONARY =====");
            DictionaryExample.DictionaryDemo();

            Console.WriteLine("\n===== STACK =====");
            StackExample.StackDemo();

            Console.WriteLine("\n===== QUEUE =====");
            QueueExample.QueueDemo();

            Console.WriteLine("\n===== HASHSET =====");
            HashSetExample.HashSetDemo();

            Console.WriteLine("\n===== SORTEDLIST =====");
            SortedListExample.SortedListDemo();
        }
    }
    class ListExample
    {
        public static void ListDemo()
        {
            List<int> list = new List<int>();

            // ADD
            list.Add(10);
            list.AddRange(new int[] { 20, 30, 40 });
            list.Insert(1, 15); // insert at index

            // ACCESS
            Console.WriteLine(list[0]); // index
            Console.WriteLine(list.Contains(20)); // check exists
            Console.WriteLine(list.IndexOf(30));

            // REMOVE
            list.Remove(20);
            list.RemoveAt(0);
            list.Clear(); // remove all

            // OTHER
            list.AddRange(new int[] { 5, 2, 8 });
            list.Sort();
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
            list.Reverse();

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }

    }
    class DictionaryExample
    {
        public static void DictionaryDemo()
        {
            Dictionary<int, string> dict = new Dictionary<int, string>();

            // ADD
            dict.Add(1, "Ram");
            dict[2] = "John"; // another way

            // ACCESS
            Console.WriteLine(dict[1]);
            dict.TryGetValue(2, out string value);
            Console.WriteLine(value);

            // CHECK
            Console.WriteLine(dict.ContainsKey(1));
            Console.WriteLine(dict.ContainsValue("Ram"));

            // REMOVE
            dict.Remove(1);

            // LOOP
            foreach (var item in dict)
            {
                Console.WriteLine(item.Key + " - " + item.Value);
            }

            // OTHER
            dict.Clear();
        }
    }

    class StackExample
    {
        public static void StackDemo()
        {
            Stack<int> stack = new Stack<int>();

            // ADD
            stack.Push(10);
            stack.Push(20);
            stack.Push(30);

            // ACCESS
            Console.WriteLine(stack.Peek());

            // REMOVE
            Console.WriteLine(stack.Pop());

            // CHECK
            Console.WriteLine(stack.Contains(20));

            // LOOP
            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }

            // OTHER
            Console.WriteLine(stack.Count);
                stack.Clear();
            }
        }
    
    class QueueExample
    {
        public static void QueueDemo()
        {
            Queue<int> queue = new Queue<int>();

            // ADD
            queue.Enqueue(10);
            queue.Enqueue(20);
            queue.Enqueue(30);

            // ACCESS
            Console.WriteLine(queue.Peek());

            // REMOVE
            Console.WriteLine(queue.Dequeue());

            // CHECK
            Console.WriteLine(queue.Contains(20));

            // LOOP
            foreach (var item in queue)
            {
                Console.WriteLine(item);
            }

            // OTHER
            Console.WriteLine(queue.Count);
            queue.Clear();
        }
    }

    class HashSetExample
    {
        public static void HashSetDemo()
        {
            HashSet<int> set = new HashSet<int>();

            // ADD
            set.Add(10);
            set.Add(20);
            set.Add(10); // duplicate ignored

            // CHECK
            Console.WriteLine(set.Contains(20));

            // REMOVE
            set.Remove(10);

            // SET OPERATIONS
            HashSet<int> set2 = new HashSet<int> { 20, 30 };

            // common
            set.IntersectWith(set2);
            foreach (var item in set)
            {
                Console.WriteLine(item);
            }

            // combine
            set.UnionWith(set2);
            foreach (var item in set)
            {
                Console.WriteLine(item);
            }
            
        
            set.ExceptWith(set2);      // remove common
            foreach (var item in set)
            {
                Console.WriteLine(item);
            }

            // OTHER
            Console.WriteLine(set.Count);
            set.Clear();
        }
    }
    class SortedListExample
    {
        public static void SortedListDemo()
        {
            SortedList<int, string> sorted = new SortedList<int, string>();

            // ADD
            sorted.Add(3, "C");
            sorted.Add(1, "A");
            sorted.Add(2, "B");

            // ACCESS
            Console.WriteLine(sorted[1]); // by key
            Console.WriteLine(sorted.Keys[0]);   // by index
            Console.WriteLine(sorted.Values[0]);

            // CHECK
            Console.WriteLine(sorted.ContainsKey(2));
            Console.WriteLine(sorted.ContainsValue("B"));

            // REMOVE
            sorted.Remove(2);

            // LOOP (sorted automatically)
            foreach (var item in sorted)
            {
                Console.WriteLine(item.Key + " - " + item.Value);
            }

            // OTHER
            Console.WriteLine(sorted.Count);
            sorted.Clear();
        }
    }
    
}
