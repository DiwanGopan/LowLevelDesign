using System;
using System.Collections.Generic;

namespace ConceptPractice.SOLIDPrinciples.OCP
{
    /*
     * ============================= OCP (Open Closed Principle) =============================
     * 
     * Definition:
     * "Software entities should be OPEN for Extension
     *  but CLOSED for Modification."
     * 
     * Meaning in LLD:
     * We should be able to add new features
     * WITHOUT changing existing tested code.
     * 
     * ---------------------------------------------------------------------------------------
     * OCP Violation in this Example:
     * 
     * ShoppingCartStorage class contains:
     * 
     * 1. SaveToSQLDatabase()
     * 2. SaveToMongoDatabase()
     * 3. SaveToFile()
     * 
     * Problem:
     * If tomorrow a new storage type comes like:
     * 
     * -> Firebase
     * -> PostgreSQL
     * -> Cloud Storage
     * -> Redis
     * 
     * Then we need to MODIFY the existing ShoppingCartStorage class.
     * 
     * This breaks OCP because:
     * Existing class is continuously changing.
     * 
     * ---------------------------------------------------------------------------------------
     * Why this is bad in LLD?
     * 
     * 1. Existing tested code can break
     * 2. Difficult maintenance
     * 3. Tight coupling
     * 4. Bigger classes over time
     * 5. Harder unit testing
     * 
     * Proper Solution:
     * Use interfaces/abstraction so new storage types
     * can be ADDED without modifying old code.
     * =======================================================================================
     */

    public class OCPViolated
    {
        // Product class representing an E-Commerce item
        public class Product
        {
            public string Name;
            public double Price;

            public Product(string name, double price)
            {
                Name = name;
                Price = price;
            }
        }


        /*
         * Responsibility:
         * Handles Shopping Cart business logic only
         */
        public class ShoppingCart
        {
            private List<Product> products = new List<Product>();


            // Add product into cart
            public void AddProduct(Product p)
            {
                products.Add(p);
            }


            // Return all products
            public List<Product> GetProducts()
            {
                return products;
            }


            // Calculate total cart price
            public double CalculateTotal()
            {
                double total = 0;

                foreach (Product p in products)
                {
                    total += p.Price;
                }

                return total;
            }
        }


        /*
         * Responsibility:
         * Prints invoice details
         */
        public class ShoppingCartPrinter
        {
            private ShoppingCart cart;

            public ShoppingCartPrinter(ShoppingCart cart)
            {
                this.cart = cart;
            }

            public void PrintInvoice()
            {
                Console.WriteLine("Shopping Cart Invoice:");

                foreach (Product p in cart.GetProducts())
                {
                    Console.WriteLine($"{p.Name} - Rs {p.Price}");
                }

                Console.WriteLine($"Total: Rs {cart.CalculateTotal()}");
            }
        }


        /*
         * OCP Violated Here
         * 
         * Every new storage type requires modifying this class.
         */
        public class ShoppingCartStorage
        {
            private ShoppingCart cart;

            public ShoppingCartStorage(ShoppingCart cart)
            {
                this.cart = cart;
            }


            // Save into SQL Database
            public void SaveToSQLDatabase()
            {
                Console.WriteLine("Saving shopping cart to SQL DB...");
            }


            // Save into MongoDB
            public void SaveToMongoDatabase()
            {
                Console.WriteLine("Saving shopping cart to Mongo DB...");
            }


            // Save into File
            public void SaveToFile()
            {
                Console.WriteLine("Saving shopping cart to File...");
            }
        }



        public static void Run()
        {
            ShoppingCart cart = new ShoppingCart();

            cart.AddProduct(new Product("Laptop", 50000));
            cart.AddProduct(new Product("Mouse", 2000));


            // Print invoice
            ShoppingCartPrinter printer = new ShoppingCartPrinter(cart);
            printer.PrintInvoice();


            // Save into SQL DB
            ShoppingCartStorage db = new ShoppingCartStorage(cart);
            db.SaveToSQLDatabase();
        }
    }
}