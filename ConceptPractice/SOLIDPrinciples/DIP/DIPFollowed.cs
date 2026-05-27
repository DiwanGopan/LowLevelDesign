using System;

namespace ConceptPractice.SOLIDPrinciples.DIP
{
    /*
     * ============================= DIP FOLLOWED =============================
     * 
     * DIP (Dependency Inversion Principle):
     * 
     * "High-level modules should not depend on low-level modules.
     *  Both should depend on abstractions."
     * 
     * ----------------------------------------------------------------------------
     * Simple Meaning:
     * 
     * Business logic should depend on interfaces,
     * not concrete implementations.
     * 
     * ----------------------------------------------------------------------------
     * In this example:
     * 
     * High-Level Module:
     * -> UserService
     * 
     * Low-Level Modules:
     * -> MySQLDatabase
     * -> MongoDBDatabase
     * 
     * Abstraction:
     * -> IDatabase
     * 
     * ----------------------------------------------------------------------------
     * How DIP is Followed?
     * 
     * 1. UserService depends on IDatabase interface
     * 2. MySQLDatabase implements IDatabase
     * 3. MongoDBDatabase implements IDatabase
     * 
     * UserService no longer depends on concrete classes.
     * 
     * ----------------------------------------------------------------------------
     * Benefits in LLD:
     * 
     * 1. Loose coupling
     * 2. Easy database replacement
     * 3. Better scalability
     * 4. Easier unit testing
     * 5. Better maintainability
     * 
     * ----------------------------------------------------------------------------
     * If a new database comes:
     * 
     * -> PostgreSQL
     * -> Firebase
     * -> Oracle
     * 
     * We only create a new class implementing IDatabase.
     * 
     * Existing UserService code remains unchanged.
     * =================================================================================
     */

    public class DIPFollowed
    {
        /*
         * Abstraction
         * 
         * High-level and low-level modules
         * both depend on this interface.
         */
        public interface IDatabase
        {
            void Save(string data);
        }


        /*
         * Low-Level Module
         * 
         * MySQL implementation
         */
        public class MySQLDatabase : IDatabase
        {
            public void Save(string data)
            {
                Console.WriteLine(
                    $"Executing SQL Query: INSERT INTO users VALUES('{data}');"
                );
            }
        }


        /*
         * Low-Level Module
         * 
         * MongoDB implementation
         */
        public class MongoDBDatabase : IDatabase
        {
            public void Save(string data)
            {
                Console.WriteLine(
                    $"Executing MongoDB Function: db.users.insert({{name: '{data}'}})"
                );
            }
        }


        /*
         * High-Level Module
         * 
         * Depends only on abstraction (IDatabase)
         * instead of concrete classes.
         */
        public class UserService
        {
            private readonly IDatabase database;


            /*
             * Dependency Injection:
             * Database dependency is injected from outside.
             */
            public UserService(IDatabase database)
            {
                this.database = database;
            }


            public void StoreUser(string user)
            {
                database.Save(user);
            }
        }



        public static void Run()
        {
            /*
             * Injecting MySQL implementation
             */
            IDatabase sqlDb = new MySQLDatabase();

            UserService sqlService = new UserService(sqlDb);

            sqlService.StoreUser("Aditya");


            Console.WriteLine();


            /*
             * Injecting MongoDB implementation
             */
            IDatabase mongoDb = new MongoDBDatabase();

            UserService mongoService = new UserService(mongoDb);

            mongoService.StoreUser("Rohit");
        }
    }
}