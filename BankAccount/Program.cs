// Areesh Nadeem
// Program: Bank Account System

using System;
using System.Collections.Generic;

public class Program
{
    static void Main(string[] args)
    {
        uint choice = 0;
        var accounts = new List<BankAccount>();

        // Main menu loop
        do
        {
            Console.WriteLine("********* Welcome to ARNAD Bank *********");
            Console.WriteLine("1. Register an Account");
            Console.WriteLine("2. Login");
            Console.WriteLine("3. Quit");
            Console.WriteLine("Enter your choice: ");

            // Input validation loop
            
            choice = Convert.ToUInt32(Console.ReadLine());
            if (choice < 1 || choice > 3) { 
                Console.WriteLine("Invalid number. Please try again."); 
                continue;
            }
            
            // Branch based on user's choice
            if (choice == 1) { RegisterAccount(accounts); }
            else if (choice == 2) { Login(accounts); }
            else { return; }

        } while (choice != 3);
    }


    // @brief: Registers a new bank account.
    // @param: "accounts" List of bank accounts to store the new account.
    static void RegisterAccount(List<BankAccount> accounts)
    {
        string firstName, lastName, username, password;
        double balance = -1;

        // Gather user information
        Console.WriteLine("Enter your first name: ");
        firstName = Console.ReadLine();
        Console.WriteLine("Enter your last name: ");
        lastName = Console.ReadLine();
        Console.WriteLine("Enter a username for your account: ");
        username = Console.ReadLine();
        Console.WriteLine("Create a strong password with:\n\t - At least 10 characters (min 2 being numbers) \n\t - At least 1 special character\n\t - At least 1 uppercase letter");
        password = Console.ReadLine();

        // Validate password and balance
        while (!CheckPassword(password))
        {
            Console.WriteLine("Password not valid, please try again: ");
            password = Console.ReadLine();
        }
        while (balance < 0)
        {
            Console.WriteLine("How much would you like to initially deposit?: ");
            balance = Convert.ToDouble(Console.ReadLine());
        }

        // Register the account
        Console.WriteLine("\n*****Registering an account...*****");
        BankAccount account = new BankAccount(firstName, lastName, username, password, balance);
        accounts.Add(account);
        Console.WriteLine($"Account created for {firstName} {lastName}\n");
    }


    // @brief Logs into an existing bank account.
    // @param "accounts" List of bank accounts to search for the user's account.
    static void Login(List<BankAccount> accounts)
    {
        Console.WriteLine("Enter your username: ");
        string username = Console.ReadLine();
        Console.WriteLine("Enter your password: ");
        string password = Console.ReadLine();

        // Search for the account with the provided username
        BankAccount account = accounts.Find(acc => acc.Username == username);

        // Check if the account exists and the password matches
        if (account != null && account.Password == password)
        {
            Console.WriteLine("\n*****Login successful!*****\n");
            LoginMenu(account);
        }
        else
        {
            Console.WriteLine("Invalid username or password. Please try again.");
        }
    }


    // @brief: Validates the password according to specified criteria.
    // @param: "password" The password to be validated.
    // @return: True if the password meets the criteria, false otherwise.
    public static bool CheckPassword(string password)
    {
        // Password must be at least 10 characters long, contain at least 1 special character, and 1 uppercase letter
        if (password.Length < 10) { return false; }
        bool specialChar = false;
        int numDigit = 0;
        bool upperCase = false;

        // Iterate through each character in the password and check password rules
        foreach (char charCurr in password)
        {
            if (char.IsDigit(charCurr)) { numDigit++; }
            else if (char.IsUpper(charCurr)) { upperCase = true; }
            else if (char.IsPunctuation(charCurr) || char.IsSymbol(charCurr)) { specialChar = true; }
        }

        // Return true if the password meets the criteria, otherwise false
        return (specialChar && numDigit >= 2 && upperCase);
    }


    // @brief: Displays a menu for logged-in users to view account info, deposit, withdraw, or quit.
    // @param: "account" The logged-in bank account.
    static void LoginMenu(BankAccount account)
    {
        uint choice = 0;

        // Logged-in user menu loop
        while (choice != 4)
        {
            Console.WriteLine("********* Welcome to ARNAD Bank *********");
            Console.WriteLine("1. View Account Info");
            Console.WriteLine("2. Deposit");
            Console.WriteLine("3. Withdraw");
            Console.WriteLine("4. Quit");
            Console.WriteLine("Enter your choice: ");

            choice = Convert.ToUInt16(Console.ReadLine());

            // Branch based on user's choice
            if (choice == 1) { account.ViewAccountInfo(); }
            else if (choice == 2)
            {
                Console.WriteLine("Enter the amount to deposit:");
                uint depositAmount = Convert.ToUInt32(Console.ReadLine());

                try
                {
                    account.Deposit(depositAmount);
                    Console.WriteLine($"\n*****Deposit successful. New balance: ${account.Balance}*****\n");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("\n*****Invalid amount. Please enter a valid number.*****\n");
                }
            }
            else if (choice == 3)
            {
                Console.WriteLine("Enter the amount to withdraw:");
                uint withdrawAmount = Convert.ToUInt32(Console.ReadLine());

                try
                {
                    account.Withdraw(withdrawAmount);
                    Console.WriteLine($"\n*****New balance: ${account.Balance}*****\n");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("\n*****Invalid amount. Please enter a valid number.*****\n");
                }
            }
            else if (choice == 4)
            {
                Console.WriteLine("\n*****Quitting...*****\n");
                return;
            }
            else
            {
                Console.WriteLine("Invalid choice. Please enter a valid number.");
                continue;
            }
        }
    }
}