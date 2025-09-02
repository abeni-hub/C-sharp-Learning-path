using System;
using System.Collections.Generic;

class BankAccount
{
    public int AccountNumber { get; private set; }
    public string Owner { get; private set; }
    private double balance;

    public BankAccount(int accountNumber, string owner, double initialBalance = 0)
    {
        AccountNumber = accountNumber;
        Owner = owner;
        balance = initialBalance;
    }

    public void Deposit(double amount)
    {
        if (amount > 0)
        {
            balance += amount;
            Console.WriteLine($"Deposited {amount}. New balance: {balance}");
        }
        else
        {
            Console.WriteLine("Invalid deposit amount.");
        }
    }

    public void Withdraw(double amount)
    {
        if (amount > 0 && amount <= balance)
        {
            balance -= amount;
            Console.WriteLine($"Withdrew {amount}. New balance: {balance}");
        }
        else
        {
            Console.WriteLine("Insufficient balance or invalid amount.");
        }
    }

    public void ShowBalance()
    {
        Console.WriteLine($"Account {AccountNumber} ({Owner}) Balance: {balance}");
    }
}

partial class Program
{
    static List<BankAccount> accounts = new List<BankAccount>();
    static int nextAccountNumber = 1001;

    static void Main()
    {
        Console.WriteLine("=== Simple Banking System ===");
        string choice;

        do
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Create Account");
            Console.WriteLine("2. Deposit");
            Console.WriteLine("3. Withdraw");
            Console.WriteLine("4. Check Balance");
            Console.WriteLine("5. Exit");
            Console.Write("Enter choice: ");
            choice = Console.ReadLine();

            switch (choice)
            {
                case "1": CreateAccount(); break;
                case "2": Deposit(); break;
                case "3": Withdraw(); break;
                case "4": CheckBalance(); break;
                case "5": Console.WriteLine("Goodbye!"); break;
                default: Console.WriteLine("Invalid choice"); break;
            }
        } while (choice != "5");
    }

    static void CreateAccount()
    {
        Console.Write("Enter account owner name: ");
        string owner = Console.ReadLine();
        BankAccount account = new BankAccount(nextAccountNumber++, owner);
        accounts.Add(account);
        Console.WriteLine($"Account created successfully. Account Number: {account.AccountNumber}");
    }

    static BankAccount FindAccount()
    {
        Console.Write("Enter account number: ");
        int accNum = int.Parse(Console.ReadLine());

        foreach (var acc in accounts)
        {
            if (acc.AccountNumber == accNum)
                return acc;
        }
        Console.WriteLine("Account not found.");
        return null;
    }

    static void Deposit()
    {
        var account = FindAccount();
        if (account != null)
        {
            Console.Write("Enter deposit amount: ");
            double amount = double.Parse(Console.ReadLine());
            account.Deposit(amount);
        }
    }

    static void Withdraw()
    {
        var account = FindAccount();
        if (account != null)
        {
            Console.Write("Enter withdrawal amount: ");
            double amount = double.Parse(Console.ReadLine());
            account.Withdraw(amount);
        }
    }

    static void CheckBalance()
    {
        var account = FindAccount();
        if (account != null)
        {
            account.ShowBalance();
        }
    }
}
