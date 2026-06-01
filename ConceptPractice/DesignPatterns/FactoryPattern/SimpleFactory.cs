using System;

namespace ConceptPractice.DesignPatterns.FactoryPattern
{
    /*
        =========================================================
                        FACTORY DESIGN PATTERN
        =========================================================

        Definition:
        Factory Pattern is a Creational Design Pattern used to
        create objects without exposing creation logic to client.

        Main Goal:
        Move object creation logic into a separate Factory class.

        ---------------------------------------------------------
        WHY USE FACTORY PATTERN?
        ---------------------------------------------------------

        Problem Without Factory:
        - Tight coupling
        - Repeated "new" keyword
        - Large if-else conditions
        - Difficult maintenance
        - Hard to extend

        Solution:
        Client asks Factory for object.
        Factory decides which object to create.

        ---------------------------------------------------------
        REAL LIFE EXAMPLE
        ---------------------------------------------------------

        Restaurant Kitchen:
        Customer orders food.
        Kitchen prepares food.
        Customer doesn't know cooking process.

        Factory works the same way.

        ---------------------------------------------------------
        SIMPLE FACTORY
        ---------------------------------------------------------

        Concept:
        One factory class creates all objects based on input.

        Best Use Case:
        - Small applications
        - Limited object types
        - Centralized creation logic

        Advantages:
        + Cleaner code
        + Centralized object creation
        + Reduces duplicate code

        Disadvantages:
        - Factory becomes large
        - Violates Open/Closed Principle
        - Must modify factory for new types

        ---------------------------------------------------------
        FLOW
        ---------------------------------------------------------

        Client
           ↓
        Factory
           ↓
        Concrete Object

        ---------------------------------------------------------
        KEY INTERVIEW POINT
        ---------------------------------------------------------

        Factory Pattern provides:
        - Loose Coupling
        - Encapsulation
        - Better Maintainability
        - Better Scalability

        ---------------------------------------------------------
        IMPORTANT UNDERSTANDING
        ---------------------------------------------------------

        Without Factory:
            Car car = new Car();

        With Factory:
            IVehicle vehicle = VehicleFactory.CreateVehicle("car");

        Client only asks for object.
        Factory controls object creation.

        ---------------------------------------------------------
        TYPES OF FACTORY PATTERNS
        ---------------------------------------------------------

        1. Simple Factory
           → One factory creates all objects

        2. Factory Method
           → Subclasses decide object creation

        3. Abstract Factory
           → Creates families of related objects

        4. Static Factory
           → Static methods create objects

        =========================================================
    */

    public class SimpleFactory
    {
        // Common contract for all vehicles
        public interface IVehicle
        {
            void Drive();
        }

        // Concrete Product
        public class Car : IVehicle
        {
            public void Drive()
            {
                Console.WriteLine("Driving Car");
            }
        }

        // Concrete Product
        public class Bike : IVehicle
        {
            public void Drive()
            {
                Console.WriteLine("Driving Bike");
            }
        }

        // Concrete Product
        public class Truck : IVehicle
        {
            public void Drive()
            {
                Console.WriteLine("Driving Truck");
            }
        }

        // Factory class responsible for object creation
        public class VehicleFactory
        {
            public static IVehicle CreateVehicle(string type)
            {
                if (type == "car")
                    return new Car();

                if (type == "bike")
                    return new Bike();

                if (type == "truck")
                    return new Truck();

                throw new Exception("Invalid Vehicle Type");
            }
        }

        public static void Run()
        {
            // Client asks factory for object
            IVehicle vehicle = VehicleFactory.CreateVehicle("car");

            vehicle.Drive();
        }
    }
}