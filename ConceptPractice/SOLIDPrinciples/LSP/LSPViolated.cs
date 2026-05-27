using System;
using System.Collections.Generic;

namespace ConceptPractice.SOLIDPrinciples.LSP
{
    /*
     * ============================= LSP (Liskov Substitution Principle) =============================
     * 
     * Definition:
     * "Objects of a parent class should be replaceable
     *  with objects of child classes WITHOUT breaking the program."
     * 
     * In simple words:
     * If class B is a child of class A,
     * then we should be able to use B wherever A is used
     * without unexpected behavior.
     * 
     * -----------------------------------------------------------------------------------------------
     * LSP Violation in this Example:
     * 
     * Interface Account contains:
     * 
     * 1. Deposit()
     * 2. Withdraw()
     * 
     * SavingAccount and CurrentAccount support both operations.
     * 
     * BUT:
     * FixedTermAccount DOES NOT support Withdraw().
     * 
     * Instead of properly supporting withdrawal,
     * it throws an exception.
     * 
     * -----------------------------------------------------------------------------------------------
     * Problem:
     * 
     * BankClient assumes ALL Account types can withdraw money.
     * 
     * But when FixedTermAccount is substituted,
     * the application behavior breaks.
     * 
     * This violates LSP.
     * 
     * -----------------------------------------------------------------------------------------------
     * Why this is bad in LLD?
     * 
     * 1. Unexpected runtime exceptions
     * 2. Poor extensibility
     * 3. Tight coupling
     * 4. Unstable inheritance hierarchy
     * 5. Difficult maintenance
     * 
     * Proper Solution:
     * Create separate interfaces for:
     * 
     * -> Depositable Accounts
     * -> Withdrawable Accounts
     * 
     * So every child class only implements
     * behaviors it actually supports.
     * ===============================================================================================
     */


    /*
     * Base Account Interface
     * 
     * Problem:
     * Every account is FORCED to implement Withdraw()
     * even if withdrawal is not supported.
     */
    public class LSPViolated
    {
        public interface IAccount
        {
            void Deposit(double amount);

            void Withdraw(double amount);
        }


        /*
         * Savings Account
         * Supports Deposit and Withdraw
         */
        public class SavingAccount : IAccount
        {
            private double balance;

            public SavingAccount()
            {
                balance = 0;
            }

            public void Deposit(double amount)
            {
                balance += amount;

                Console.WriteLine(
                    $"Deposited: {amount} in Savings Account. New Balance: {balance}"
                );
            }

            public void Withdraw(double amount)
            {
                if (balance >= amount)
                {
                    balance -= amount;

                    Console.WriteLine(
                        $"Withdrawn: {amount} from Savings Account. New Balance: {balance}"
                    );
                }
                else
                {
                    Console.WriteLine("Insufficient funds in Savings Account!");
                }
            }
        }


        /*
         * Current Account
         * Supports Deposit and Withdraw
         */
        public class CurrentAccount : IAccount
        {
            private double balance;

            public CurrentAccount()
            {
                balance = 0;
            }

            public void Deposit(double amount)
            {
                balance += amount;

                Console.WriteLine(
                    $"Deposited: {amount} in Current Account. New Balance: {balance}"
                );
            }

            public void Withdraw(double amount)
            {
                if (balance >= amount)
                {
                    balance -= amount;

                    Console.WriteLine(
                        $"Withdrawn: {amount} from Current Account. New Balance: {balance}"
                    );
                }
                else
                {
                    Console.WriteLine("Insufficient funds in Current Account!");
                }
            }
        }


        /*
         * Fixed Term Account
         * 
         * LSP Violated Here:
         * This account DOES NOT support withdrawal,
         * but still forced to implement Withdraw().
         */
        public class FixedTermAccount : IAccount
        {
            private double balance;

            public FixedTermAccount()
            {
                balance = 0;
            }

            public void Deposit(double amount)
            {
                balance += amount;

                Console.WriteLine(
                    $"Deposited: {amount} in Fixed Term Account. New Balance: {balance}"
                );
            }


            // LSP Violation
            // Child class changes expected behavior
            public void Withdraw(double amount)
            {
                throw new NotSupportedException(
                    "Withdrawal not allowed in Fixed Term Account!"
                );
            }
        }


        /*
         * Client Class
         * 
         * Assumes every account supports Withdraw().
         * This assumption breaks for FixedTermAccount.
         */
        public class BankClient
        {
            private List<IAccount> accounts;

            public BankClient(List<IAccount> accounts)
            {
                this.accounts = accounts;
            }

            public void ProcessTransactions()
            {
                foreach (IAccount acc in accounts)
                {
                    // All accounts support deposit
                    acc.Deposit(1000);


                    // Assumption:
                    // All accounts support withdrawal
                    // This breaks for FixedTermAccount
                    try
                    {
                        acc.Withdraw(500);
                    }
                    catch (NotSupportedException e)
                    {
                        Console.WriteLine($"Exception: {e.Message}");
                    }
                }
            }
        }



        public static void Run()
        {
            List<IAccount> accounts = new List<IAccount>();

            accounts.Add(new SavingAccount());
            accounts.Add(new CurrentAccount());
            accounts.Add(new FixedTermAccount());


            BankClient client = new BankClient(accounts);


            // Runtime issue occurs for FixedTermAccount
            client.ProcessTransactions();
        }
    }
}