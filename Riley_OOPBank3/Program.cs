using System;

namespace Riley_MultiUser_Bank

{
    public class Bank
    {
        private decimal _balance;

        public Bank(decimal initialBalance)
        {
            _balance = initialBalance;
        }

        public void Deposit(decimal amount)
        {
            _balance += amount;
        }


    class Program
    {
        static void Main(string[] args)
        {
            Bank bank = new Bank(1000);

            while (true)
            {
                Console.WriteLine("1. Deposit");
                Console.WriteLine("2. Withdraw");
                Console.WriteLine("3. Check Balance");
                Console.WriteLine("4. Quit");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter deposit amount: ");
                        decimal depositAmount;
                        if (!decimal.TryParse(Console.ReadLine(), out depositAmount))
                        {
                            Console.WriteLine("Invalid input. Please enter a valid number.");
                            continue;
                        }
                        bank.Deposit(depositAmount);
                        Console.WriteLine($"Balance: {bank.Balance:C}");
                        break;
                    case "2":
                        Console.Write("Enter withdrawal amount: ");
                        decimal withdrawalAmount;
                        if (!decimal.TryParse(Console.ReadLine(), out withdrawalAmount))
                        {
                            Console.WriteLine("Invalid input. Please enter a valid number.");
                            continue;
                        }
                        bank.Withdraw(withdrawalAmount);
                        Console.WriteLine($"Balance: {bank.Balance:C}");
                        break;
                    case "3":
                        Console.WriteLine($"Balance: {bank.Balance:C}");
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }
}

