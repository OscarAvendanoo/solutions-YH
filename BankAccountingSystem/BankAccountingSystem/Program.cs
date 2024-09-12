using System.Security.Principal;

namespace BankAccountingSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // List to store multiple accounts  (gtp ville ha static i början)
            List<Account> accounts = new List<Account>();
            // Create initial sample accounts (optional)
            

            bool systemRun = true;
            while (systemRun)
            {

                Console.WriteLine("\n--- Bank Account Management System ---");
                Console.WriteLine("1. Create New Savings Account");
                Console.WriteLine("2. Create New Current Account");
                Console.WriteLine("3. Deposit Money");
                Console.WriteLine("4. Withdraw Money");
                Console.WriteLine("5. Check Balance");
                Console.WriteLine("6. Apply Interest (Savings Accounts)");
                Console.WriteLine("7. Make a transaction.");
                Console.WriteLine("8. change PIN");
                Console.WriteLine("9. Exit");
                Console.Write("Select an option: ");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        {
                            var newSavingsAccount = CreateSavingsAccount();
                            accounts.Add(newSavingsAccount);
                        }
                        break;
                    case 2:
                            var newCurrentAccount = CreateCurrentAccount();
                            accounts.Add(newCurrentAccount);
                        
                         
                        break;
                    case 3:
                        Console.WriteLine("which account would you like to deposit? Type in the account number;");
                        int accountNumberDeposit = int.Parse(Console.ReadLine());
                        Console.WriteLine("enter your PIN;");
                        int accountPinDeposit = int.Parse(Console.ReadLine());
                        foreach (Account account in accounts)
                        {
                            if (account.AccountNumber == accountNumberDeposit)
                            {
                                if (accountPinDeposit == account.AccountPinNumber)
                                {
                                    DepositMoney(account);
                                }
                                else { Console.WriteLine("The account number and PIN does not match"); }
                                
                            }
                            

                        }     
                        
                        break;
                    case 4:
                        Console.WriteLine("which account would you like to withdraw from? Type in the account number;");
                        int accountNumberWithdraw = int.Parse(Console.ReadLine());
                        Console.WriteLine("enter your PIN;");
                        int accountPinWithdraw = int.Parse(Console.ReadLine());
                        foreach (Account account in accounts)
                        {
                            if (account.AccountNumber == accountNumberWithdraw)
                            {
                                if (accountPinWithdraw == account.AccountPinNumber)
                                {
                                    WithdrawMoney(account);
                                }
                                else { Console.WriteLine("The account number and PIN does not match"); }

                            }
                            

                        }

                        break;
                    case 5:
                        Console.WriteLine("whích account would you like to check the balance on?");
                        int accountNumberBalance = int.Parse(Console.ReadLine());
                        Console.WriteLine("enter your PIN;");
                        int accountPinBalance = int.Parse(Console.ReadLine());
               
                        
                        foreach (Account account in accounts)
                        {
                            if (account.AccountNumber == accountNumberBalance)
                            {
                                if (accountPinBalance == account.AccountPinNumber)
                                {
                                    CheckBalance(account);
                                }
                                else { Console.WriteLine("The account number and PIN does not match"); }

                            }
                            
                        }
                        break;

                    case 6:
                        Console.WriteLine("which account would you like to apply interest on?");
                        int accountNumberInterest = int.Parse(Console.ReadLine());
                        Console.WriteLine("enter your PIN;");
                        int accountPinInterest = int.Parse(Console.ReadLine());

                        // för att account ska skickas som parameter till ApplyInterest måste vi här använda Savingsaccount
                        // annars kommer account att skickas som ett object av typen Account och inte Savingsaccount
                        foreach (SavingsAccount account in accounts)
                        {
                            if (account.AccountNumber == accountNumberInterest)
                            {
                                if (account.AccountType == "savings account" )
                                {
                                    if (accountPinInterest == account.AccountPinNumber)
                                    {
                                        ApplyInterest(account);
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("the account must be a savings account.");
                                    Console.WriteLine();
                                }
                            }
                        }
                        break;
                    case 7:
                        Console.WriteLine("apply which account you would like to send money from;");
                        int transactionFrom = int.Parse(Console.ReadLine());
                        Console.WriteLine("apply which account you would like to send money to;");
                        int transactionTo = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter the PIN to your account;");
                        int transactionPin = int.Parse(Console.ReadLine());
                        foreach (Account account in accounts)
                        {
                            if (account.AccountNumber == transactionFrom)
                            {
                                if (transactionPin == account.AccountPinNumber)
                                {
                                    foreach (Account account2 in accounts)
                                    {
                                        if (transactionTo == account.AccountNumber)
                                        {  // ????
                                            sendMoney(account);
                                          // call transaction method, probably needs to be implemented in the Account class also. 
                                        }
                                    }
                                }
                                else { Console.WriteLine("The account number and PIN does not match"); }

                            }
                        }
                        break;
                    case 8:
                        break;
                    case 9:
                        Console.WriteLine("thank you for using our service");
                        systemRun = false;
                        break;
                    default:
                        Console.WriteLine("Something went wrong, choose a number between 1-7.");
                        break;

                }
            }
            // to be able to return an object of the type "SavingsAccount", it must be specified like below when creating the method
            static SavingsAccount CreateSavingsAccount()
            {
                Console.WriteLine("Creating a new Savings Account...");

                Console.WriteLine("Please give us your first and last name;");
                string accountHolder = Console.ReadLine();
                Console.WriteLine("Please chooce an account number with 8 digits;");
                int accountNumber = int.Parse(Console.ReadLine());
                Console.WriteLine("Please choose a PIN with 4 digits;");
                int accountPin = int.Parse(Console.ReadLine());
                Console.WriteLine("Please enter your intitial deposit;");
                decimal initialDeposit = decimal.Parse(Console.ReadLine());
                int interestRate = 5;

                SavingsAccount newSavingsaccount = new SavingsAccount(accountHolder, accountNumber, accountPin, initialDeposit, "savings account", interestRate);
                Console.WriteLine("Your savings account has successfully been created.");

                return newSavingsaccount;

            }

            static CurrentAccount CreateCurrentAccount()
            {
                Console.WriteLine("Creating a new current account...");

                Console.WriteLine("Please give us your first and last name;");
                string accountHolder = Console.ReadLine();
                Console.WriteLine("Please chooce an account number with 8 digits;");
                int accountNumber = int.Parse(Console.ReadLine());
                Console.WriteLine("Please choose a PIN with 4 digits;");
                int accountPin = int.Parse(Console.ReadLine());
                Console.WriteLine("Please enter your intitial deposit;");
                decimal initialDeposit = decimal.Parse(Console.ReadLine());
                decimal overDraftLimit = 20000;

                CurrentAccount newCurrentAccount = new CurrentAccount(accountHolder, accountNumber,accountPin, initialDeposit,"current account" ,overDraftLimit);
                Console.WriteLine("Your current account has successfully been created.");
                return newCurrentAccount;

            }

            static void DepositMoney(Account thisAccount)
            {
                Console.Write("Enter Amount to Deposit: ");
                int amount = int.Parse(Console.ReadLine());
                thisAccount.Deposit(amount);

            }
            static void WithdrawMoney(Account thisAccount)
            {
                Console.Write("Enter Amount to withdraw: ");
                int amount = int.Parse(Console.ReadLine());
                thisAccount.Withdraw(amount);
            }

            static void CheckBalance(Account thisAccount)
            {
                thisAccount.CheckBalance();
            }

            // För att ApplyInterest (som bara finns i classen Savingsaccount) ska kunna refereras till så måste parametern till funktionen nedan vara av typen Savingsaccount
            // om man gör som de andra funktionerna och istället anger bara "Account" kommer kontot (objectet) att lämnas som om det vore från classen "Account" endast och inte "Savingsaccount"
            static void ApplyInterest(SavingsAccount thisAccount)
            {
                thisAccount.ApplyInterest();
            }

            static void sendMoney(Account sendingAccount, Account recievingAccount)
            {
                Console.Write("Enter the amount you want to send: ");
                decimal amount = decimal.Parse(Console.ReadLine());
                
                //logic for making the transaction
            }

           

            




        }
    }
}
