using System;

namespace ConceptPractice.SOLIDPrinciples.LSP.LSPRules.SignatureRules
{
    /*
     * ============================= EXCEPTION RULE =============================
     * 
     * LSP Exception Rule:
     * 
     * "Child classes should throw fewer or narrower exceptions
     *  than the parent class."
     * 
     * ----------------------------------------------------------------------------
     * Simple Meaning:
     * 
     * Child class should NOT introduce:
     * 
     * 1. New unexpected exceptions
     * 2. Broader/general exceptions
     * 
     * because client code written for Parent
     * may not be prepared to handle them.
     * 
     * ----------------------------------------------------------------------------
     * Important Difference:
     * 
     * JAVA:
     * -> Has Checked Exceptions
     * -> Compiler enforces exception rules
     * 
     * C# / .NET:
     * -> NO Checked Exceptions
     * -> All exceptions are unchecked
     * -> Rules are maintained by design convention
     * 
     * ----------------------------------------------------------------------------
     * Common Exceptions in C# / .NET
     * 
     * System.Exception                     // Base Exception class
     * ├── System.SystemException
     * │   ├── ArithmeticException
     * │   │   ├── DivideByZeroException
     * │   │   └── OverflowException
     * │   │
     * │   ├── NullReferenceException
     * │   ├── IndexOutOfRangeException
     * │   ├── InvalidOperationException
     * │   ├── ArgumentException
     * │   │   ├── ArgumentNullException
     * │   │   └── ArgumentOutOfRangeException
     * │   │
     * │   ├── FormatException
     * │   ├── NotSupportedException
     * │   ├── IOException
     * │   │   ├── FileNotFoundException
     * │   │   └── DirectoryNotFoundException
     * │   │
     * │   └── TimeoutException
     * │
     * └── ApplicationException
     * 
     * ----------------------------------------------------------------------------
     * In this example:
     * 
     * Parent throws:
     * -> Exception
     * 
     * Child throws:
     * -> ArithmeticException
     * 
     * ArithmeticException is narrower/specific.
     * Therefore LSP is followed.
     * 
     * ----------------------------------------------------------------------------
     * Bad Example:
     * 
     * Parent throws:
     * -> ArithmeticException
     * 
     * Child throws:
     * -> Exception
     * 
     * Problem:
     * Child becomes broader and less predictable.
     * 
     * This breaks LSP.
     * 
     * ----------------------------------------------------------------------------
     * Benefits in LLD:
     * 
     * 1. Predictable error handling
     * 2. Stable inheritance hierarchy
     * 3. Safer polymorphism
     * 4. Better maintainability
     * 5. Reliable client behavior
     * =================================================================================
     */

    public class ExceptionRule
    {
        /*
         * Parent Class
         * 
         * Throws generic Exception
         */
        public class Parent
        {
            public virtual void GetValue()
            {
                throw new Exception("Parent error");
            }
        }


        /*
         * Child Class
         * 
         * Throws narrower exception:
         * ArithmeticException
         * 
         * Therefore:
         * LSP Exception Rule is followed.
         */
        public class Child : Parent
        {
            public override void GetValue()
            {
                throw new ArithmeticException("Child error");


                /*
                 * BAD PRACTICE EXAMPLE:
                 * Throwing broader/unexpected exceptions
                 * can violate LSP expectations.
                 * 
                 * throw new Exception("Child error");
                 */
            }
        }


        /*
         * Client Class
         * 
         * Works with Parent abstraction.
         * 
         * Client safely catches Exception,
         * so both Parent and Child objects work correctly.
         */
        public class Client
        {
            private Parent p;

            public Client(Parent p)
            {
                this.p = p;
            }

            public void TakeValue()
            {
                try
                {
                    p.GetValue();
                }
                catch (Exception e)
                {
                    Console.WriteLine(
                        $"Exception occurred: {e.Message}"
                    );
                }
            }
        }



        public static void Run()
        {
            Parent parent = new Parent();

            Child child = new Child();


            // Using Parent object
            Client client = new Client(parent);


            // Using Child object
            // Client client = new Client(child);


            client.TakeValue();
        }
    }
}