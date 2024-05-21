/*
 * Application: Multi-User Bank
 * Author: Blake Riley
 * Date: 5/20/2024
 * Description: This application simulates a bank that can handle multiple users. 
 * Each user can log in with their username and password, and then they can deposit, 
 * withdraw, and check their balance. The bank keeps track of its overall cash on hand.
 */


using System;

namespace Riley_MultiUser_Bank
{
    class Program
    {
        static void Main(string[] args)
        {
            Bank bank = new Bank();
            string loggedInUser = null;

            while (true)
            {
                if (loggedInUser == null)
                {
                    Console.Write("Enter username: ");
                    string username = Console.ReadLine();
                    Console.Write("Enter password: ");
                    string password = Console.ReadLine();

                    if (bank.Login(username, password))
                    {
                        loggedInUser = username;
                        Console.WriteLine($"Logged in as {loggedInUser}");
                    }
                    else
                    {
                        Console.WriteLine("Invalid username or password.");
                    }
                }
                else
                {
                    Console.WriteLine("1. Deposit");
                    Console.WriteLine("2. Withdraw");
                    Console.WriteLine("3. Check Balance");
                    Console.WriteLine("4. Logout");
                    Console.WriteLine("5. Quit");

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
                            bank.Deposit(loggedInUser, depositAmount);
                            Console.WriteLine($"Balance: {bank.GetBalance(loggedInUser):C}");
                            break;
                        case "2":
                            Console.Write("Enter withdrawal amount: ");
                            decimal withdrawalAmount;
                            if (!decimal.TryParse(Console.ReadLine(), out withdrawalAmount))
                            {
                                Console.WriteLine("Invalid input. Please enter a valid number.");
                                continue;
                            }
                            bank.Withdraw(loggedInUser, withdrawalAmount);
                            Console.WriteLine($"Balance: {bank.GetBalance(loggedInUser):C}");
                            break;
                        case "3":
                            Console.WriteLine($"Balance: {bank.GetBalance(loggedInUser):C}");
                            break;
                        case "4":
                            loggedInUser = null;
                            Console.WriteLine("Logged out.");
                            break;
                        case "5":
                            return;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
            }
        }
    }
}