using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gowri.Lab.CSharp
{
    public class Customer
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public int Salary { get; set; }
    }

    public class DictionaryTest
    {
        public static void Main()
        {
            Dictionary<int, Customer> CustomerInfo = new Dictionary<int, Customer>();

            AddData(CustomerInfo);
            //CustomerInfo.Add(cust2.ID, cust2);  ---no duplicate value
            Console.WriteLine(CustomerInfo[1].Name);

            if (CustomerInfo.ContainsKey(2))
            {
                Console.WriteLine("The Key Is Present to remove this from the dcitionary");
                CustomerInfo.Remove(2);
            }

            if(CustomerInfo.TryGetValue(2, out Customer value))
            {
                Console.WriteLine(value.Name);
            }
            else
            {
                Console.WriteLine("Key not found");
            }

            Console.WriteLine("Count :"+ CustomerInfo.Count);

            foreach(var item in CustomerInfo)
            {
                Console.WriteLine(item.Key+" ---> "+item.Value.Name);
            }

            PerformLinqDictionary(CustomerInfo);


            CustomerInfo.Clear();

            ConvertArrayToDictionary();
        }
        public static void AddData(Dictionary<int, Customer> Customer)
        {
            Customer cust1 = new Customer { ID = 1, Name = "Raji", Salary = 10000 };
            Customer cust2 = new Customer { ID = 2, Name = "Bala", Salary = 20000 };
            Customer cust3 = new Customer { ID = 3, Name = "kala", Salary = 35500 };
            Customer cust4 = new Customer { ID = 4, Name = "kalai", Salary = 34000 };
            Customer cust5 = new Customer { ID = 5, Name = "abi", Salary = 30000 };
            Customer cust6 = new Customer { ID = 6, Name = "aarthi", Salary = 30000 };
            Customer cust7 = new Customer { ID = 7, Name = "anu", Salary = 30000 };
            Customer cust8 = new Customer { ID = 8, Name = "arun", Salary = 30000 };
            Customer cust9 = new Customer { ID = 9, Name = "arjun", Salary = 10000 };

            Customer.Add(cust1.ID, cust1);
            Customer.Add(cust2.ID, cust2);
            Customer.Add(cust3.ID, cust3);
            Customer.Add(cust4.ID, cust4);
            Customer.Add(cust5.ID, cust5);
            Customer.Add(cust6.ID, cust6);
            Customer.Add(cust7.ID, cust7);
            Customer.Add(cust8.ID, cust8);
            Customer.Add(cust9.ID, cust9);
        }
        public static void PerformLinqDictionary(Dictionary<int, Customer> CustomerInfo)
        {
            var person = CustomerInfo.Where(data => data.Value.Name == "arjun");

            foreach (var p in person)
            {
                Console.WriteLine($"Key: {p.Key}, Value: {p.Value.Name}");
            }

            //convert Dictionary into List
            var keyList = CustomerInfo.Keys.ToList();
            var values = CustomerInfo.Values.ToArray();

            foreach(var item in keyList)
            {
                Console.WriteLine(item);
            }
            foreach (var item in values)
            {
                Console.WriteLine(item.Name);
            }

        }
        public static void ConvertArrayToDictionary()
        {
            Person[] people = new Person[]
            {
                new Person { ID = 101, Name = "Malar" },
                new Person { ID = 102, Name = "Bala" },
                new Person { ID = 103, Name = "rani" }
            };

            Dictionary<int, Person> Persons = people.ToDictionary(p => p.ID);

            foreach (var values in Persons)
            {
                Console.WriteLine($"Key: {values.Key}, Name: {values.Value.Name}");

            }
        }
    }
    public class Person
    {
        public int ID { get; set; }
        public string? Name { get; set; }
    }
}


//dictionary
        //Add(key, value) 
        //ContainsKey
        //Remove(key)	
        //TryGetValue
        //Clear()	
        //Count	
        //Keys
        //Values


