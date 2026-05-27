using System;
using System.Collections.Generic;

namespace ConceptPractice.SOLIDPrinciples.LSP
{
    /*
     * ============================= LSP FOLLOWED WRONGLY =============================
     * 
     * LSP (Liskov Substitution Principle):
     * 
     * "Child classes should be replaceable with parent classes
     *  without breaking application behavior."
     * 
     * ------------------------------------------------------------------------------
     * In this example, developer TRIED to fix LSP violation
     * by adding type checking:
     * 
     * if (acc is FixedTermAccount)
     * 
     * and skipping withdrawal manually.
     * 
     * ------------------------------------------------------------------------------
     * Why this is STILL WRONG?
     * 
     * 1. BankClient now knows about child class details
     *    -> Tight Coupling
     * 
     * 2. Every new account type requires modifying BankClient
     * 
     * Example:
     * -> SalaryAccount
     * -> CryptoAccount
     * -> LoanAccount
     * 
     * Again new IF conditions will be added.
     * 
     * ------------------------------------------------------------------------------
     * This breaks:
     * 
     * 1. LSP
     * 2. OCP (Open Closed Principle)
     * 
     * ------------------------------------------------------------------------------
     * Why this is bad in LLD?
     * 
     * 1. Client becomes tightly coupled
     * 2. Difficult scalability
     * 3. More conditional checks
     * 4. Difficult maintenance
     * 5. Hard to extend system
     * 
     * ------------------------------------------------------------------------------
     * Proper Solution:
     * 
     * Separate interfaces should be created:
     * 
     * -> IDepositable
     * -> IWithdrawable
     * 
     * So only accounts supporting withdrawal
     * implement withdrawal behavior.
     * =================================================================================
     */


    /*
     * Base Account Interface
     * 
     * Problem:
     * Forces all accounts to implement Withdraw()
     */
    public class LSPFollowedWrongly
    {
        public interface IAccount
        {
            void Deposit(double amount);

            void Withdraw(double amount);
        }


        /*
         * Savings Account
         * Supports deposit and withdrawal
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
         * Supports deposit and withdrawal
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
         * Does not support withdrawal
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


            // Still problematic
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
         * WRONG FIX:
         * Explicit type checking added.
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
                    acc.Deposit(1000);


                    /*
                     * WRONG APPROACH:
                     * Client should NOT check child types.
                     * 
                     * This creates tight coupling and breaks OCP.
                     */
                    if (acc is FixedTermAccount)
                    {
                        Console.WriteLine(
                            "Skipping withdrawal for Fixed Term Account."
                        );
                    }
                    else
                    {
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
        }



        public static void Run()
        {
            List<IAccount> accounts = new List<IAccount>();

            accounts.Add(new SavingAccount());
            accounts.Add(new CurrentAccount());
            accounts.Add(new FixedTermAccount());


            BankClient client = new BankClient(accounts);

            client.ProcessTransactions();
        }
    }
}