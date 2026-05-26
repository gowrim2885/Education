using Gowri.Lab.CSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gowri.Lab.CSharp
{
    public class Product
    {
        private string? name;
        private decimal price;
        private int quantity;
        List<Product> products = new List<Product>();

        public string Name
        {
            get { return name ?? "Unknown Product"; }
            set { name = value; }
        }
        public decimal Price
        {
            get { return price; }
            set { price = value; }
        }
        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }
        public Product()
        {
            name = "Unknown Product";
            price = 0;
            quantity = 0;
        }
        public Product(string name, decimal price, int quantity)
        {
            this.name = name;
            this.price = price;
            this.quantity = quantity;
        }

        public void AddProduct()
        {
            Console.Write("Enter Product Name: ");
            Name = Console.ReadLine();
            Console.Write("Enter Product Price: ");
            Price = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Enter Product Quantity: ");
            Quantity = Convert.ToInt32(Console.ReadLine());

            products.Add(this);
            Console.WriteLine($"\nProduct Added: \n Name: {Name}, \n Price: {Price}, \n Quantity: {Quantity}");
            Console.WriteLine("*** Prodect ADDED Successfully ***");
        }
            
        public void DisplayAllProduct()
        {
            foreach(var prod in products)
            {
                Console.WriteLine($"Product Name:\t {prod.name} Product Price: \t {prod.price} Product Quantity: \t {prod.quantity}");
            }
        }
        
        //public void FillterData()
        //{
        //    Func<decimal, bool> highcostProd = products => products.price > 100;
        //    var filteredProducts = products.FindAll(highcostProd);

        //    foreach (var prod in filteredProducts)
        //    {
        //        Console.WriteLine(prod.name);
        //    }
            
        //}
    }

    public class Store : Product
    {
        public static void MainMethod()
        {

            Console.WriteLine("Welcome to the Store!");
            Store s = new Store();
            while (true)
            {
                Console.Write("\n1. Add Product");
                Console.Write(" \t 2. Display all Products");
                Console.Write("\n 3. Fillter the product based on th eprice value");
                Console.Write(" \t 4. Exit");
                Console.WriteLine("Choose an option: ");
                string? choice = Console.ReadLine();
                if (choice == "1")
                {
                    Console.WriteLine("Now Enter the new Product Detail");
                    s.AddProduct();
                }
                else if (choice == "2")
                {
                    Console.WriteLine("*** Display All Prodects ***");
                    s.DisplayAllProduct();
                    break;
                }
                else if (choice == "3")
                {
                    //s.FillterData();
                    break;
                }
                else if (choice == "4")
                {
                    Console.WriteLine("Exiting the Store. Goodbye!");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid option. Please try again.");
                }
            }

        }
    }
}


