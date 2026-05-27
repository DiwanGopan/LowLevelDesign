using System;

namespace ConceptPractice.SOLIDPrinciples.LSP.LSPRules.MethodRules
{
    /*
     * ============================= PRECONDITIONS RULE =============================
     * 
     * LSP Method Rule:
     * 
     * "Subclasses can weaken preconditions
     *  but cannot strengthen them."
     * 
     * ----------------------------------------------------------------------------
     * What is a Precondition?
     * 
     * A precondition is a condition that MUST be true
     * before a method executes successfully.
     * 
     * ----------------------------------------------------------------------------
     * In this example:
     * 
     * Parent Class Precondition:
     * 
     * -> Password length must be at least 8 characters
     * 
     * Child Class Precondition:
     * 
     * -> Password length must be at least 6 characters
     * 
     * ----------------------------------------------------------------------------
     * Why is this VALID?
     * 
     * Because:
     * 
     * Child class is LESS restrictive.
     * 
     * It accepts everything parent accepts
     * and even more inputs.
     * 
     * Therefore:
     * Preconditions are WEAKENED.
     * 
     * Hence LSP is followed.
     * 
     * ----------------------------------------------------------------------------
     * BAD Example:
     * 
     * Parent:
     * -> Minimum 6 characters
     * 
     * Child:
     * -> Minimum 12 characters
     * 
     * Problem:
     * Child becomes MORE restrictive.
     * 
     * Client passing valid parent input may fail.
     * 
     * This breaks LSP.
     * 
     * ----------------------------------------------------------------------------
     * Why this matters in LLD?
     * 
     * 1. Safe polymorphism
     * 2. Predictable behavior
     * 3. Better extensibility
     * 4. Stable inheritance hierarchy
     * 5. Reusable abstractions
     * =================================================================================
     */
    public class PreConditions
    {

        /*
         * Parent Class
         * 
         * Precondition:
         * Password must contain at least 8 characters.
         */
        public class User
        {
            public virtual void SetPassword(string password)
            {
                if (password.Length < 8)
                {
                    throw new ArgumentException(
                        "Password must be at least 8 characters long!"
                    );
                }

                Console.WriteLine("Password set successfully");
            }
        }


        /*
         * Child Class
         * 
         * Weakens the precondition.
         * 
         * Allows passwords with minimum 6 characters.
         * 
         * Therefore:
         * LSP is followed.
         */
        public class AdminUser : User
        {
            public override void SetPassword(string password)
            {
                if (password.Length < 6)
                {
                    throw new ArgumentException(
                        "Password must be at least 6 characters long!"
                    );
                }

                Console.WriteLine("Password set successfully");
            }
        }



        public static void Run()
        {
            /*
             * Parent reference holding Child object.
             * 
             * This works correctly because:
             * Child class accepts broader inputs.
             */
            User user = new AdminUser();


            // Works fine:
            // AdminUser allows shorter passwords.
            user.SetPassword("Admin1");
        }
    }
}