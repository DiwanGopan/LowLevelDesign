using System;

namespace ConceptPractice.SOLIDPrinciples.LSP.LSPRules.PropertyRules
{
    /*
     * ============================= HISTORY CONSTRAINT =============================
     * 
     * LSP Property Rule:
     * 
     * "Subclass should not change the allowed state transitions
     *  or behavior history of the parent class."
     * 
     * ----------------------------------------------------------------------------
     * Simple Meaning:
     * 
     * If parent class allows some operation,
     * child class should NOT suddenly block it.
     * 
     * ----------------------------------------------------------------------------
     * In this example:
     * 
     * Parent Class:
     * BankAccount
     * 
     * allows:
     * -> Withdraw operation
     * 
     * Client expects all BankAccount objects
     * to support withdrawal.
     * 
     * ----------------------------------------------------------------------------
     * Problem:
     * 
     * FixedDepositAccount inherits BankAccount
     * BUT overrides Withdraw()
     * and completely blocks withdrawal.
     * 
     * This changes the original behavior/history
     * defined by the parent class.
     * 
     * Therefore:
     * LSP History Constraint is violated.
     * 
     * ----------------------------------------------------------------------------
     * Why this is dangerous in LLD?
     * 
     * 1. Client assumptions break
     * 2. Runtime failures occur
     * 3. Inheritance hierarchy becomes unsafe
     * 4. Polymorphism breaks
     * 5. Difficult maintenance
     * 
     * ----------------------------------------------------------------------------
     * Real Problem:
     * 
     * Client using BankAccount reference:
     * 
     * BankAccount acc = new FixedDepositAccount();
     * 
     * expects:
     * acc.Withdraw()
     * 
     * But child class blocks the operation.
     * 
     * ----------------------------------------------------------------------------
     * Proper Solution:
     * 
     * FixedDepositAccount should NOT inherit
     * from BankAccount if it cannot support
     * all parent behaviors.
     * 
     * OR
     * 
     * Use separate abstractions/interfaces.
     * =================================================================================
     */
    public class HistoryConstraint
    {

        /*
         * Parent Class
         * 
         * Allows withdrawal operation.
         */
        public class BankAccount
        {
            protected double balance;

            public BankAccount(double b)
            {
                if (b < 0)
                {
                    throw new ArgumentException(
                        "Balance can't be negative"
                    );
                }

                balance = b;
            }


            /*
             * History Constraint:
             * Withdraw operation is supported.
             */
            public virtual void Withdraw(double amount)
            {
                if (balance - amount < 0)
                {
                    throw new Exception("Insufficient funds");
                }

                balance -= amount;

                Console.WriteLine(
                    $"Amount withdrawn. Remaining balance is {balance}"
                );
            }
        }


        /*
         * Child Class
         * 
         * LSP Violation:
         * Parent allowed withdrawal,
         * child completely blocks it.
         */
        public class FixedDepositAccount : BankAccount
        {
            public FixedDepositAccount(double b) : base(b)
            {
            }


            /*
             * LSP BREAK!
             * 
             * Parent behavior changed.
             * 
             * Client expecting withdraw support
             * will now fail.
             */
            public override void Withdraw(double amount)
            {
                throw new Exception(
                    "Withdraw not allowed in Fixed Deposit"
                );
            }
        }



        public static void Run()
        {
            BankAccount bankAccount = new BankAccount(100);

            bankAccount.Withdraw(100);


            /*
             * Problematic Substitution:
             * 
             * BankAccount acc = new FixedDepositAccount(100);
             * acc.Withdraw(50);
             * 
             * This breaks client expectations.
             */
        }
    }
}