using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountingSystem
{
    public class Account
    {
        // properties 

        public string AccountHolder { get; set; }
        public int AccountNumber { get; set; }
        protected decimal AccountBalance { get; set; }
        public int AccountPinNumber { get; set; }
        public string AccountType { get; set; }




        //contructor

        public Account(string accountHolder, int accountNumber, int pinNumber,  decimal initialBalance, string accountType)
        {
            this.AccountHolder = accountHolder;
            this.AccountNumber = accountNumber;
            this.AccountBalance = initialBalance;
            this.AccountPinNumber = pinNumber;
            this.AccountType = accountType;
        }

        //methods
        // virtual means that these methods can be overriden
        public virtual void Deposit(decimal amount)
        {
            AccountBalance += amount;
            Console.WriteLine($"You have deposited {amount}. And your account balance is {AccountBalance}");
        }
        public virtual void Withdraw(decimal amount)
        {
            if (AccountBalance >= amount)
            {
                AccountBalance -=amount;
                Console.WriteLine($"You have withdrawn {amount}. And your account balance is {AccountBalance}");
            }
            else { Console.WriteLine($"You do not have enough money on your account"); }
        }

        public void CheckBalance()
        {
            Console.WriteLine($"your account balance is {AccountBalance}");
        }
        // method for transaction between accounts
        public virtual void sendMoney(Account sendingAccount,Account recievingAccount, decimal amount)
        {

        }
        

    }
        // New class inherited from Account class
     public class SavingsAccount : Account
    {
        // extra property
        public decimal InterestRate { get; set; }
        

        // constructor for SavingsAccount objects   (chat gpt can ha gjort fel här, har skrivit så som jag tror då det inte ger errors och för att savingsaccount behöver 4 parametrar.)
        public SavingsAccount(string accountHolder, int accountNumber, int pinNumber, decimal initialBalance, string accountType, decimal interestRate) : base(accountHolder, accountNumber, pinNumber, initialBalance, accountType)
        {
            
            InterestRate = interestRate;

        }

        // methods

        public void ApplyInterest()
        {
            decimal interest = AccountBalance * InterestRate / 100;
            AccountBalance += interest;
            Console.WriteLine($"Interest applied. New balance: {AccountBalance}");
        }
    }
    // a new CurrentAccount class inherited from Account class
    public class CurrentAccount : Account
    {
        // extra property
        public decimal OverdraftLimit { get; set; }

        // constructor inherited from Account class but modified with overridelimit
        public CurrentAccount(string accountHolder, int accountNumber, int pinNumber, decimal initialBalance, string accountType, decimal overdraftLimit) : base(accountHolder, accountNumber, pinNumber, initialBalance, accountType)
        {
            OverdraftLimit = overdraftLimit;
        }
        //medthod that overrides the withdraw method from account class
        
        public override void Withdraw(decimal amount)
        {
            if(AccountBalance + OverdraftLimit >= amount)
            {
                AccountBalance -= amount;
                Console.WriteLine($"you have withdrawn {amount}. And your account balance is now {AccountBalance}");
            }
            else { Console.WriteLine("Overdraft limit exceeded"); }
        }
    }

}
