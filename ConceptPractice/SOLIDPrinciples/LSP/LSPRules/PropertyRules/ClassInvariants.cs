using System;

namespace ConceptPractice.SOLIDPrinciples.LSP.LSPRules.PropertyRules
{
    /*
     * ============================= CLASS INVARIANTS =============================
     * 
     * LSP Property Rule:
     * 
     * "Child classes should preserve the invariants
     *  defined by the parent class."
     * 
     * ----------------------------------------------------------------------------
     * What is an Invariant?
     * 
     * Invariant means:
     * 
     * A condition/property that must ALWAYS remain true
     * for an object throughout its lifetime.
     * 
     * ----------------------------------------------------------------------------
     * In this example:
     * 
     * Parent Class Invariant:
     * 
     * -> Balance can NEVER be negative
     * 
     * Parent class strictly enforces this rule.
     * 
     * ----------------------------------------------------------------------------
     * LSP Rule:
     * 
     * Child class can:
     * 
     * 1. Maintain the invariant
     * OR
     * 2. Strengthen the invariant
     * 
     * BUT
     * 
     * Child class should NEVER weaken/break it.
     * 
     * ----------------------------------------------------------------------------
     * Problem:
     * 
     * CheatAccount overrides Withdraw()
     * and allows negative balance.
     * 
     * This breaks parent class invariant:
     * 
     * -> balance >= 0
     * 
     * Therefore:
     * LSP is violated.
     * 
     * ----------------------------------------------------------------------------
     * Why this is dangerous in LLD?
     * 
     * 1. Invalid object state
     * 2. Unpredictable behavior
     * 3. Business rule violations
     * 4. Unsafe polymorphism
     * 5. Difficult debugging
     * 
     * ----------------------------------------------------------------------------
     * Real Problem:
     * 
     * Client expects:
     * 
     * BankAccount acc = new CheatAccount(100);
     * 
     * to maintain:
     * -> Non-negative balance
     * 
     * But child object violates this guarantee.
     * 
     * ----------------------------------------------------------------------------
     * Proper Solution:
     * 
     * Child classes must preserve
     * all important business invariants
     * defined by the parent class.
     * =================================================================================
     */
    public class ClassInvariants
    {

        /*
         * Parent Class
         * 
         * Invariant:
         * Balance should NEVER become negative.
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
             * Enforces invariant:
             * balance >= 0
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
         * Breaks parent invariant.
         */
        public class CheatAccount : BankAccount
        {
            public CheatAccount(double b) : base(b)
            {
            }


            /*
             * LSP BREAK!
             * 
             * Negative balance allowed.
             * 
             * Parent invariant violated.
             */
            public override void Withdraw(double amount)
            {
                balance -= amount;

                Console.WriteLine(
                    $"Amount withdrawn. Remaining balance is {balance}"
                );
            }
        }



        public static void Run()
        {
            BankAccount bankAccount = new BankAccount(100);

            bankAccount.Withdraw(100);


            /*
             * Problematic Example:
             * 
             * BankAccount acc = new CheatAccount(100);
             * acc.Withdraw(1000);
             * 
             * Remaining balance becomes negative.
             * 
             * Invariant broken.
             */
        }
    }
}