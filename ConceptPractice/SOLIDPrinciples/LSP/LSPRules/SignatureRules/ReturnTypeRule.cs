using System;

namespace ConceptPractice.SOLIDPrinciples.LSP.LSPRules.SignatureRules
{
    /*
     * ============================= RETURN TYPE RULE =============================
     * 
     * LSP Signature Rule:
     * 
     * "Subtype overridden method return type should be
     *  identical or narrower than the parent method return type."
     * 
     * This is called:
     * -> Return Type Covariance
     * 
     * ----------------------------------------------------------------------------
     * Simple Meaning:
     * 
     * Child class can return:
     * 
     * 1. Same return type
     * OR
     * 2. More specific/narrower return type
     * 
     * than the parent class.
     * 
     * ----------------------------------------------------------------------------
     * Example:
     * 
     * Parent Method:
     * Animal GetAnimal()
     * 
     * Child Method:
     * Dog GetAnimal()
     * 
     * Since Dog IS-A Animal,
     * this follows LSP.
     * 
     * ----------------------------------------------------------------------------
     * Why this is safe?
     * 
     * Client expecting Animal
     * can also work with Dog object
     * because Dog inherits Animal.
     * 
     * ----------------------------------------------------------------------------
     * Bad Example:
     * 
     * Parent:
     * Animal GetAnimal()
     * 
     * Child:
     * object GetAnimal()
     * 
     * Problem:
     * Child becomes broader/generalized.
     * Client expecting Animal behavior may fail.
     * 
     * This breaks LSP.
     * 
     * ----------------------------------------------------------------------------
     * Benefits in LLD:
     * 
     * 1. Safe polymorphism
     * 2. Flexible inheritance
     * 3. Reusable code
     * 4. Predictable behavior
     * 5. Better abstraction design
     * =================================================================================
     */
    public class ReturnTypeRule
    {

        /*
         * Base Animal Class
         * 
         * Represents generic animal behavior
         */
        public class Animal
        {
            // Common Animal methods can be added here
        }


        /*
         * Dog Class
         * 
         * Dog IS-A Animal
         * 
         * More specific/narrower type
         */
        public class Dog : Animal
        {
            // Dog specific methods can be added here
        }


        /*
         * Parent Class
         * 
         * Returns generic Animal type
         */
        public class Parent
        {
            public virtual Animal GetAnimal()
            {
                Console.WriteLine("Parent : Returning Animal instance");

                return new Animal();
            }
        }


        /*
         * Child Class
         * 
         * Returns Dog object.
         * 
         * Dog is a subtype of Animal.
         * 
         * Therefore LSP Return Type Rule is followed.
         */
        public class Child : Parent
        {
            public override Animal GetAnimal()
            {
                Console.WriteLine("Child : Returning Dog instance");

                return new Dog();
            }
        }


        /*
         * Client Class
         * 
         * Works with Parent abstraction.
         * 
         * Client expects Animal.
         * 
         * Both Parent and Child satisfy this contract.
         */
        public class Client
        {
            private Parent p;

            public Client(Parent p)
            {
                this.p = p;
            }

            public void TakeAnimal()
            {
                p.GetAnimal();
            }
        }



        public static void Run()
        {
            Parent parent = new Parent();

            Child child = new Child();


            // Using Child object
            Client client = new Client(child);


            // Using Parent object
            // Client client = new Client(parent);


            client.TakeAnimal();
        }
    }
}