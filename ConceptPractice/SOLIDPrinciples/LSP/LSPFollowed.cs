using System;
using System.Collections.Generic;

namespace ConceptPractice.SOLIDPrinciples.LSP
{
    /*
     * ============================= LSP FOLLOWED =============================
     * 
     * LSP (Liskov Substitution Principle):
     * 
     * "Child classes should be replaceable with parent classes
     *  without changing the correctness of the program."
     * 
     * ----------------------------------------------------------------------------
     * In this solution, LSP is properly FOLLOWED.
     * 
     * Instead of forcing every account to support Withdraw(),
     * responsibilities are divided properly using interfaces.
     * 
     * ----------------------------------------------------------------------------
     * Interfaces:
     * 
     * 1. IDepositOnlyAccount
     *    -> Supports only Deposit()
     * 
     * 2. IWithdrawableAccount
     *    -> Supports Deposit() + Withdraw()
     * 
     * ----------------------------------------------------------------------------
     * Account Mapping:
     * 
     * SavingAccount
     * -> Deposit + Withdraw
     * 
     * CurrentAccount
     * -> Deposit + Withdraw
     * 
     * FixedTermAccount
     * -> Deposit only
     * 
     * ----------------------------------------------------------------------------
     * Why this follows LSP?
     * 
     * Because:
     * 
     * 1. No child class changes parent behavior
     * 2. No unsupported operations
     * 3. No runtime exceptions
     * 4. No type checking
     * 5. Client only works with supported behaviors
     * 
     * ----------------------------------------------------------------------------
     * Benefits in LLD:
     * 
     * 1. Proper abstraction
     * 2. Loose coupling
     * 3. Better scalability
     * 4. Clean inheritance hierarchy
     * 5. Easy maintenance and testing
     * =================================================================================
     */


    /*
     * Deposit Only Account Interface
     * 
     * Supports only deposit operation
     */
    public interface IDepositOnlyAccount
    {
        void Deposit(double amount);
    }


    /*
     * Withdrawable Account Interface
     * 
     * Extends Deposit interface
     * Supports:
     * 1. Deposit
     * 2. Withdraw
     */
    public interface IWithdrawableAccount : IDepositOnlyAccount
    {
        void Withdraw(double amount);
    }


    /*
     * Savings Account
     * Supports Deposit and Withdraw
     */
    public class SavingAccount : IWithdrawableAccount
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
    public class CurrentAccount : IWithdrawableAccount
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
     * Supports ONLY Deposit.
     * 
     * No unnecessary Withdraw() method.
     * Hence LSP is maintained.
     */
    public class FixedTermAccount : IDepositOnlyAccount
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
    }


    /*
     * Client Class
     * 
     * Works only with supported behaviors.
     * 
     * No exceptions.
     * No type checking.
     * No invalid assumptions.
     */
    public class BankClient
    {
        private List<IWithdrawableAccount> withdrawableAccounts;

        private List<IDepositOnlyAccount> depositOnlyAccounts;

        public BankClient(
            List<IWithdrawableAccount> withdrawableAccounts,
            List<IDepositOnlyAccount> depositOnlyAccounts)
        {
            this.withdrawableAccounts = withdrawableAccounts;

            this.depositOnlyAccounts = depositOnlyAccounts;
        }

        public void ProcessTransactions()
        {
            // Accounts supporting withdrawal
            foreach (IWithdrawableAccount acc in withdrawableAccounts)
            {
                acc.Deposit(1000);

                acc.Withdraw(500);
            }


            // Deposit-only accounts
            foreach (IDepositOnlyAccount acc in depositOnlyAccounts)
            {
                acc.Deposit(5000);
            }
        }
    }


    public class LSPFollowed
    {
        public static void Run()
        {
            List<IWithdrawableAccount> withdrawableAccounts =
                new List<IWithdrawableAccount>();

            withdrawableAccounts.Add(new SavingAccount());

            withdrawableAccounts.Add(new CurrentAccount());


            List<IDepositOnlyAccount> depositOnlyAccounts =
                new List<IDepositOnlyAccount>();

            depositOnlyAccounts.Add(new FixedTermAccount());


            BankClient client = new BankClient(
                withdrawableAccounts,
                depositOnlyAccounts
            );

            client.ProcessTransactions();
        }
    }
}