using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Labs
{

    public class Accounts
    {
        public int id;
        public int Balance;

        static Accounts[] accounts = new Accounts[100];
        static object locker = new object();
        static Random random = new Random();

        public static void Main()
        {
            Console.WriteLine("Main thread Started..");

            CreateAccounts();
            PrintToBalance();

            //SingleThreadTransfer();
            //MultiThreadTransfer();
            //MethodTwo();

            MethodThree();
            Console.WriteLine("Main thread Ended..");
        }
        public Accounts(int id, int Balance)
        {
            this.id = id;
            this.Balance = Balance;
        }

        public static void MethodTwo()
        {
            Thread t1 = new Thread(RandomTransfer);
            Thread t2 = new Thread(RandomTransfer);
            Thread t3 = new Thread(RandomTransfer);
            Thread t4 = new Thread(RandomTransfer);

            t1.Start();
            t2.Start();
            t3.Start();
            t4.Start();

            t1.Join();
            t2.Join();
            t3.Join();
            t4.Join();

            PrintToBalance();
        }
       
        public static void CreateAccounts()
        {
            for (int i = 0; i < 100; i++)
            {
                accounts[i] = new Accounts(i, 1000);
            }
        }

        public static void MethodThree()
        {
            int person1 = random.Next(0, 91);
            int person2 = person1 + 1;
            int person3 = person1 + 2;

            Thread t1 = new Thread(() => Transfer(accounts[person1], accounts[person2], 200));
            Thread t2 = new Thread(() => Transfer(accounts[person3], accounts[person2], 200));
            t1.Start();
            t2.Start();
            t1.Join();
            t2.Join();
            Console.WriteLine("Acc 1: " +accounts[1].Balance+"  Acc 2: "+ accounts[2].Balance +"  Acc3: " + accounts[3].Balance);
            PrintToBalance();

        }
        public static void RandomTransfer()
        {
            for (int i = 0; i < 1000; i++)
            {
                int fromIndex = random.Next(100);
                int toIndex = random.Next(100);

                int amount = random.Next(1, 100);

                Transfer(accounts[fromIndex], accounts[toIndex], amount);
            }
        }

        public static void PrintToBalance()
        {
            int total =0 ;
            foreach( var acc in accounts)
            {
                total += acc.Balance;
            }

            Console.WriteLine("Total balance in Bank :" + total );
        }
        public static void SingleThreadTransfer()
        {
            Accounts accA = new Accounts(3, 1000);
            Accounts accB = new Accounts(4, 1000);

            Transfer(accA, accB, 100);
            
            Console.WriteLine("A Balance:" + accA.Balance);
            Console.WriteLine("B Balance:" + accB.Balance);

            Transfer(accB, accA, 100);
            Console.WriteLine("A Balance:" + accA.Balance);
            Console.WriteLine("B Balance:" + accB.Balance);
        }
        public static void MultiThreadTransfer()
        {
            Accounts accA = new Accounts(1, 1000);
            Accounts accB = new Accounts(2, 1000);

            Thread t1 = new Thread(()=> Transfer(accA, accB, 200));
            Thread t2 = new Thread(() => Transfer(accB, accA, 200));

            t1.Start();
            t2.Start();

            t1.Join();
            t2.Join();

            Console.WriteLine("A Balance:" + accA.Balance);
            Console.WriteLine("B Balance:" + accB.Balance);
        }
        public static void Transfer(Accounts fromAccount, Accounts toAccount, int Amount)
        {
            lock (locker)
            {
                if (fromAccount.Balance >= Amount)
                {
                    fromAccount.Balance -= Amount;
                    Thread.Sleep(5000);
                    toAccount.Balance += Amount;
                }
            }

        }

    }


















    //internal class LocksAndMonitor
    //{
    //    private static double balance= 10000;
    //    public static void Main()
    //    {
    //        Thread T1 = new Thread(Withdraw);
    //        Thread T2 = new Thread(Withdraw);
    //        T1.Start();
    //        T2.Start();
            
    //    }
    //    public static void Withdraw()
    //    {
    //        Console.WriteLine("Before Balance" + balance);
    //        balance -= 100;
    //        Console.WriteLine("After Balance" + balance);
    //    }
    //}
}
