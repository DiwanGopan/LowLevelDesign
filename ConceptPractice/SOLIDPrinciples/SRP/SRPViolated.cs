using System;
using System.Collections.Generic;

namespace ConceptPractice.SOLIDPrinciples.SRP
{
    /*
     * ============================= SRP (Single Responsibility Principle) =============================
     * 
     * Definition:
     * A class should have ONLY ONE reason to change. i.e. a class should have only one responsibility.
     * 
     * In Low Level Design (LLD), SRP helps in:
     * 1. Better maintainability
     * 2. Easy debugging
     * 3. Reusable components
     * 4. Loose coupling
     * 5. Clean architecture
     * 
     * 
     * -----------------------------------------------------------------------------------------------
     * In this example, ShoppingCart VIOLATES SRP because it handles:
     * 
     * 1. Cart management
     *    -> Adding and storing products
     * 
     * 2. Business Logic
     *    -> Calculating total price
     * 
     * 3. Presentation Logic
     *    -> Printing invoice
     * 
     * 4. Database Responsibility
     *    -> Saving cart into database
     * 
     * Since multiple responsibilities exist in one class,
     * any change in invoice format or database logic can modify ShoppingCart.
     * 
     * Therefore SRP is violated.
     * ===============================================================================================
     */

    public class SRPViolated
    {
        // Product class representing an E-Commerce product
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
         * SRP Violated Here
         * ShoppingCart is handling multiple responsibilities.
         */
        public class ShoppingCart
        {
            private List<Product> products = new List<Product>();


            // Responsibility 1 -> Managing products in cart
            public void AddProduct(Product p)
            {
                products.Add(p);
            }

            public List<Product> GetProducts()
            {
                return products;
            }


            // Responsibility 2 -> Calculating total cart price
            public double CalculateTotal()
            {
                double total = 0;

                foreach (Product p in products)
                {
                    total += p.Price;
                }

                return total;
            }


            // Responsibility 3 -> Printing invoice
            // This should ideally be inside InvoicePrinter class
            public void PrintInvoice()
            {
                Console.WriteLine("Shopping Cart Invoice:");

                foreach (Product p in products)
                {
                    Console.WriteLine($"{p.Name} - Rs {p.Price}");
                }

                Console.WriteLine($"Total: Rs {CalculateTotal()}");
            }


            // Responsibility 4 -> Database operation
            // This should ideally be inside Repository/Database class
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

            cart.PrintInvoice();

            cart.SaveToDatabase();
        }
    }
}