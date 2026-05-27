using System;
using System.Collections.Generic;

namespace ConceptPractice.SOLIDPrinciples.SRP
{
    /*
     * ============================= SRP FOLLOWED =============================
     * 
     * SRP (Single Responsibility Principle):
     * "A class should have only ONE reason to change."
     * 
     * In Low Level Design (LLD), we divide responsibilities properly
     * so every class handles only one task.
     * 
     * Benefits:
     * 1. Easy Maintenance
     * 2. Better Readability
     * 3. Loose Coupling
     * 4. Reusability
     * 5. Easy Testing
     * 
     * -----------------------------------------------------------------------
     * In this example:
     * 
     * 1. ShoppingCart
     *    -> Handles cart business logic only
     * 
     * 2. ShoppingCartPrinter
     *    -> Handles invoice printing only
     * 
     * 3. ShoppingCartStorage
     *    -> Handles database operations only
     * 
     * Each class has ONLY ONE responsibility.
     * Therefore SRP is FOLLOWED.
     * =======================================================================
     */

    public class SRPFollowed
    {
        // Product class representing any item in E-Commerce
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
         * Only manages Shopping Cart operations
         */
        public class ShoppingCart
        {
            private List<Product> products = new List<Product>();


            // Adds product into cart
            public void AddProduct(Product p)
            {
                products.Add(p);
            }


            // Returns all cart products
            public List<Product> GetProducts()
            {
                return products;
            }


            // Calculates total cart amount
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
         * Only responsible for printing invoice
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
         * Responsibility:
         * Only responsible for database operations
         */
        public class ShoppingCartStorage
        {
            private ShoppingCart cart;

            public ShoppingCartStorage(ShoppingCart cart)
            {
                this.cart = cart;
            }

            public void SaveToDatabase()
            {
                Console.WriteLine("Saving shopping cart to database...");
            }
        }



        public static void Run()
        {
            ShoppingCart cart = new ShoppingCart();

            cart.AddProduct(new Product("Laptop", 50000));
            cart.AddProduct(new Product("Mouse", 2000));


            // Printing Invoice
            ShoppingCartPrinter printer = new ShoppingCartPrinter(cart);
            printer.PrintInvoice();


            // Saving cart into DB
            ShoppingCartStorage db = new ShoppingCartStorage(cart);
            db.SaveToDatabase();
        }
    }
}