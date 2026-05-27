using System;

namespace ConceptPractice.SOLIDPrinciples.LSP.LSPRules.SignatureRules
{
    /*
     * ============================= METHOD ARGUMENT RULE =============================
     * 
     * LSP Signature Rule:
     * 
     * "A child class method should allow the same or more general inputs as the parent method."
     * 
     * ----------------------------------------------------------------------------
     * Simple Meaning:
     * 
     * Child class should NOT restrict the input expected by the parent class.
     * 
     * ----------------------------------------------------------------------------
     * In C#:
     * 
     * Method overriding requires SAME method signature.
     * 
     * Example:
     * 
     * Parent:
     * print(string msg)
     * 
     * Child:
     * print(string msg)
     * 
     * Since both methods accept the SAME argument type,
     * LSP is maintained.
     * 
     * ----------------------------------------------------------------------------
     * Why this is important?
     * 
     * Client using Parent class should work properly even if Child object is substituted.
     * 
     * ----------------------------------------------------------------------------
     * Bad Example:
     * 
     * Parent:
     * print(object msg)
     * 
     * Child:
     * print(string msg)
     * 
     * Problem:
     * Child becomes more restrictive.
     * 
     * Client passing object may fail.
     * 
     * This breaks LSP.
     * 
     * ----------------------------------------------------------------------------
     * Benefits in LLD:
     * 
     * 1. Safe inheritance
     * 2. Predictable behavior
     * 3. Proper polymorphism
     * 4. Loose coupling
     * 5. Better maintainability
     * =================================================================================
     */

    public class MethodArgumentRule
    {
        /*
         * Parent Class
         * 
         * Accepts string argument
         */
        public class Parent
        {
            public virtual void Print(string msg)
            {
                Console.WriteLine($"Parent: {msg}");
            }
        }


        /*
         * Child Class
         * 
         * SAME method signature maintained.
         * 
         * Therefore:
         * LSP Signature Rule is followed.
         */
        public class Child : Parent
        {
            public override void Print(string msg)
            {
                Console.WriteLine($"Child: {msg}");
            }
        }


        /*
         * Client Class
         * 
         * Works with Parent abstraction.
         * 
         * Can safely use:
         * 1. Parent object
         * 2. Child object
         * 
         * without changing behavior expectations.
         */
        public class Client
        {
            private Parent p;

            public Client(Parent p)
            {
                this.p = p;
            }

            public void PrintMsg()
            {
                // Client expects string input support
                p.Print("Hello");
            }
        }



        public static void Run()
        {
            Parent parent = new Parent();

            Parent child = new Child();


            // Using Parent object
            //Client client = new Client(parent);


            // Using Child object
            Client client = new Client(child);


            client.PrintMsg();
        }
    }
}