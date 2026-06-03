using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs
{
    public class Bank
    {
        public decimal amount;
        public decimal balance;

        public Bank(decimal amount, decimal balance)
        {
            this.amount = amount;
            this.balance = balance;
        }

        public void Withdraw()
        {
            balance -= amount;
        }
        public void Deposite()
        {
            balance += amount;
        }
        public decimal GetBalance()
        {
            return this.balance;
        }
        
    }
    public class Transaction
    {
        public static void MainMethod()
        {
            Console.WriteLine("Enter the Amount: ");
            decimal dAmt = Convert.ToDecimal(Console.ReadLine());
          
            Console.WriteLine("Enter the Balance Amount: ");
            decimal dBal = Convert.ToDecimal(Console.ReadLine());



            Bank obj = new Bank(dAmt, dBal);

            
            obj.Withdraw();
            Console.WriteLine(obj.GetBalance());
        }
    }
}
