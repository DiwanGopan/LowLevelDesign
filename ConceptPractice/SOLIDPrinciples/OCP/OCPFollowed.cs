using System;
using System.Collections.Generic;

namespace ConceptPractice.SOLIDPrinciples.OCP
{
    /*
     * ============================= OCP FOLLOWED =============================
     * 
     * Open Closed Principle (OCP):
     * 
     * "Software entities should be OPEN for Extension
     *  but CLOSED for Modification."
     * 
     * Meaning:
     * We should be able to ADD new functionality
     * without changing existing working code.
     * 
     * ----------------------------------------------------------------------------
     * In this example:
     * 
     * We created an interface:
     * -> IPersistence
     * 
     * Different storage implementations:
     * -> SQLPersistence
     * -> MongoPersistence
     * -> FilePersistence
     * 
     * Now if a new database comes:
     * -> Firebase
     * -> PostgreSQL
     * -> Redis
     * 
     * We ONLY create a new class implementing IPersistence.
     * 
     * Existing code remains unchanged.
     * 
     * Therefore OCP is FOLLOWED.
     * 
     * ----------------------------------------------------------------------------
     * Benefits in LLD:
     * 
     * 1. Easy feature extension
     * 2. Existing code stays safe
     * 3. Better scalability
     * 4. Loose coupling
     * 5. Easy testing and maintenance
     * =================================================================================
     */

    public class OCPFollowed
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


            // Calculate total cart amount
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
         * Prints invoice only
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
         * Abstraction for persistence/storage
         * 
         * New storage types can be added
         * without modifying existing classes.
         */
        public interface IPersistence
        {
            void Save(ShoppingCart cart);
        }


        /*
         * SQL Database implementation
         */
        public class SQLPersistence : IPersistence
        {
            public void Save(ShoppingCart cart)
            {
                Console.WriteLine("Saving shopping cart to SQL DB...");
            }
        }


        /*
         * MongoDB implementation
         */
        public class MongoPersistence : IPersistence
        {
            public void Save(ShoppingCart cart)
            {
                Console.WriteLine("Saving shopping cart to MongoDB...");
            }
        }


        /*
         * File Storage implementation
         */
        public class FilePersistence : IPersistence
        {
            public void Save(ShoppingCart cart)
            {
                Console.WriteLine("Saving shopping cart to a file...");
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


            // Different persistence implementations
            IPersistence db = new SQLPersistence();
            IPersistence mongo = new MongoPersistence();
            IPersistence file = new FilePersistence();


            // Save data
            db.Save(cart);       // SQL DB
            mongo.Save(cart);    // MongoDB
            file.Save(cart);     // File Storage
        }
    }
}