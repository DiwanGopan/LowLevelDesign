using System;

namespace ConceptPractice.SOLIDPrinciples.DIP
{
    /*
     * ============================= DIP (Dependency Inversion Principle) =============================
     * 
     * Definition:
     * 
     * "High-level modules should not depend on low-level modules.
     *  Both should depend on abstractions."
     * 
     * Also:
     * 
     * "Abstractions should not depend on details.
     *  Details should depend on abstractions."
     * 
     * ----------------------------------------------------------------------------
     * Simple Meaning:
     * 
     * Business logic should NOT directly depend
     * on specific implementations.
     * 
     * Instead:
     * Use interfaces/abstractions.
     * 
     * ----------------------------------------------------------------------------
     * In this Example:
     * 
     * High-Level Module:
     * -> UserService
     * 
     * Low-Level Modules:
     * -> MySQLDatabase
     * -> MongoDBDatabase
     * 
     * ----------------------------------------------------------------------------
     * DIP Violation:
     * 
     * UserService directly creates:
     * 
     * -> MySQLDatabase
     * -> MongoDBDatabase
     * 
     * This creates:
     * 
     * -> Tight Coupling
     * 
     * ----------------------------------------------------------------------------
     * Problems:
     * 
     * If tomorrow database changes to:
     * 
     * -> PostgreSQL
     * -> Firebase
     * -> Oracle
     * 
     * Then UserService must be modified.
     * 
     * This violates:
     * 
     * 1. DIP
     * 2. OCP
     * 
     * ----------------------------------------------------------------------------
     * Why this is bad in LLD?
     * 
     * 1. Tight coupling
     * 2. Difficult testing
     * 3. Poor scalability
     * 4. Difficult maintenance
     * 5. Hard dependency replacement
     * 
     * ----------------------------------------------------------------------------
     * Proper Solution:
     * 
     * Create an abstraction/interface:
     * 
     * -> IDatabase
     * 
     * Then:
     * 
     * MySQLDatabase and MongoDBDatabase
     * implement that interface.
     * 
     * UserService should depend only on abstraction.
     * ===============================================================================================
     */


    public class DIPViolated
    {
        /*
         * Low-Level Module
         * 
         * MySQL specific implementation
         */
        public class MySQLDatabase
        {
            public void SaveToSQL(string data)
            {
                Console.WriteLine(
                    $"Executing SQL Query: INSERT INTO users VALUES('{data}');"
                );
            }
        }


        /*
         * Low-Level Module
         * 
         * MongoDB specific implementation
         */
        public class MongoDBDatabase
        {
            public void SaveToMongo(string data)
            {
                Console.WriteLine(
                    $"Executing MongoDB Function: db.users.insert({{name: '{data}'}})"
                );
            }
        }


        /*
         * High-Level Module
         * 
         * DIP Violated:
         * Directly depends on concrete classes.
         */
        public class UserService
        {
            /*
             * Tight Coupling:
             * UserService directly creates database objects.
             */
            private readonly MySQLDatabase sqlDb = new MySQLDatabase();

            private readonly MongoDBDatabase mongoDb = new MongoDBDatabase();


            /*
             * MySQL specific business logic
             */
            public void StoreUserToSQL(string user)
            {
                sqlDb.SaveToSQL(user);
            }


            /*
             * MongoDB specific business logic
             */
            public void StoreUserToMongo(string user)
            {
                mongoDb.SaveToMongo(user);
            }
        }


        public static void Run()
        {
            UserService service = new UserService();

            service.StoreUserToSQL("Aditya");

            service.StoreUserToMongo("Rohit");
        }
    }
}