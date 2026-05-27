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
     * before a method can execute successfully.
     * 
     * ----------------------------------------------------------------------------
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
     * Child class becomes LESS restrictive.
     * 
     * Parent accepts:
     * -> 8+ characters
     * 
     * Child accepts:
     * -> 6+ characters
     * 
     * Therefore child accepts broader input.
     * 
     * Hence:
     * LSP is FOLLOWED.
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
     * Client sending valid parent input may fail.
     * 
     * This breaks LSP.
     * 
     * ----------------------------------------------------------------------------
     * Benefits in LLD:
     * 
     * 1. Safe inheritance
     * 2. Predictable polymorphism
     * 3. Flexible child classes
     * 4. Stable client behavior
     * 5. Better extensibility
     * =================================================================================
     */


    /*
     * Parent Class
     * 
     * Precondition:
     * Password must be at least 8 characters.
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
     * LSP is maintained.
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


    public class PostConditions
    {
        public static void Run()
        {
            /*
             * Parent reference storing Child object.
             * 
             * Safe substitution because child
             * accepts broader input conditions.
             */
            User user = new AdminUser();


            // Works successfully
            user.SetPassword("Admin1");
        }
    }
}