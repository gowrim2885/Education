using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Labs
{
    internal class Wallet
    {
        public static void Main()
        {
            Console.WriteLine("Main Method");

            List<Account> accounts = Wallet.CreateRandomAccount();

            Console.WriteLine("Total Balance amount" + accounts.Sum(acc=>acc.Balance));

            List<int> user = new List<int>();
            Wallet.GetAnyTwoAccount(user);
            int A = user[0];
            int B = user[1];

            Account accountA = accounts[A];
            Account accountB = accounts[B];
            
            AccountManager managerA = new AccountManager(accountA, accountB, 200);
            Thread T1 = new Thread(managerA.Transfer);
            T1.Name = "T1";

            AccountManager managerB = new AccountManager(accountB, accountA, 500);
            Thread T2 = new Thread(managerB.Transfer);
            T2.Name = "T2";


            T1.Start();
            T2.Start();

            T1.Join();
            T2.Join();

            Console.WriteLine("Main Ended");

            Console.WriteLine("Total Balance amount" + accounts.Sum(acc => acc.Balance));
        }

        public static void GetAnyTwoAccount(List<int> user)
        {
            
            Random random = new Random();
            int accountA = random.Next(0, 98);
            int accountB = accountA + 1;
            user.Add(accountA);
            user.Add(accountB); 

        }
        public static List<Account> CreateRandomAccount()
        {
            List<Account> accounts = [];
            for (int i=0; i<1000; i++)
            {
                accounts.Add(new Account(i + 1, 10000));
            }
            return accounts;
        }
    }
    public class Account
    {
        private int _id;
        private double _balance;
        public Account(int id , double balance)
        {
            this._id = id;
            this._balance = balance;
        }

        public double Balance
        {
            get { return _balance; }
        }
        public int ID
        {
            get { return _id; }
        }

        public void Withdrow(double amount)
        {
            _balance -= amount;
        }

        public void Deposite(double amount)
        {
            _balance += amount;
        }
    }
    
    
    public class AccountManager
    {
        Account _fromAccount;
        Account _ToAccount;
        double AmountToTransfer;
        public AccountManager(Account _fromAccount,Account  _toAccount,double Amount)
        {
            this._fromAccount = _fromAccount;
            this._ToAccount = _toAccount;
            this.AmountToTransfer = Amount;
        }

        public void Transfer()
        {
            Console.WriteLine(Thread.CurrentThread.Name+"try to lock Account "+ _fromAccount.ID.ToString());

            lock (_fromAccount)
            {
                Console.WriteLine(Thread.CurrentThread.Name + "  locked the Account  " + _fromAccount.ID.ToString());
                Console.WriteLine(Thread.CurrentThread.Name + " sleep 3 second");
                Thread.Sleep(3000);

                _fromAccount.Withdrow(AmountToTransfer);
                _ToAccount.Deposite(AmountToTransfer);

            }
        }
    }
}
