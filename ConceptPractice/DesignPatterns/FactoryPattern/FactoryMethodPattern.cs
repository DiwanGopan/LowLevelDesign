using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptPractice.DesignPatterns.FactoryPattern
{
    /*
        =========================================================
                    FACTORY METHOD DESIGN PATTERN
        =========================================================

        Definition:
        Factory Method Pattern is a Creational Design Pattern
        where subclasses decide which object to create.

        ---------------------------------------------------------
        MAIN IDEA
        ---------------------------------------------------------

        Instead of one large factory using if-else conditions,
        each product has its own factory class.

        Object creation is delegated to subclasses.

        ---------------------------------------------------------
        SIMPLE FACTORY VS FACTORY METHOD
        ---------------------------------------------------------

        Simple Factory:
            One factory creates all objects.

        Factory Method:
            Separate factory for each product.

        ---------------------------------------------------------
        WHY FACTORY METHOD?
        ---------------------------------------------------------

        Problem in Simple Factory:
        - Large if-else conditions
        - Factory grows bigger
        - Violates Open/Closed Principle

        Solution:
        Create separate factory classes.

        ---------------------------------------------------------
        REAL LIFE EXAMPLE
        ---------------------------------------------------------

        Vehicle Manufacturing Plants:

        CarFactory   → Creates Car
        BikeFactory  → Creates Bike

        Each factory knows only its own product.

        ---------------------------------------------------------
        FLOW
        ---------------------------------------------------------

        Client
           ↓
        Concrete Factory
           ↓
        Concrete Product

        ---------------------------------------------------------
        KEY COMPONENTS
        ---------------------------------------------------------

        1. Product Interface
           → Common contract

        2. Concrete Products
           → Actual implementations

        3. Abstract Factory
           → Declares factory method

        4. Concrete Factories
           → Create specific products

        ---------------------------------------------------------
        ADVANTAGES
        ---------------------------------------------------------

        + Follows Open/Closed Principle
        + Easy to extend
        + Removes large if-else blocks
        + Better maintainability
        + Loose coupling

        ---------------------------------------------------------
        DISADVANTAGES
        ---------------------------------------------------------

        - More classes
        - Slightly more complex
        - Increased code structure

        ---------------------------------------------------------
        BEST USE CASE
        ---------------------------------------------------------

        Use when:
        - New product types are added frequently
        - System should be scalable
        - Object creation varies by subclass

        ---------------------------------------------------------
        IMPORTANT UNDERSTANDING
        ---------------------------------------------------------

        Simple Factory:
            VehicleFactory.CreateVehicle("car")

        Factory Method:
            CarFactory factory = new CarFactory();

        In Factory Method,
        subclass decides object creation.

        ---------------------------------------------------------
        INTERVIEW POINT
        ---------------------------------------------------------

        Factory Method uses:
        - Inheritance
        - Polymorphism
        - Abstraction

        Main Goal:
        Delegate object creation to child classes.

        =========================================================
    */

    public class FactoryMethodPattern
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

        // Abstract Factory declares factory method
        public abstract class VehicleFactory
        {
            public abstract IVehicle CreateVehicle();
        }

        // Concrete Factory creates Car object
        public class CarFactory : VehicleFactory
        {
            public override IVehicle CreateVehicle()
            {
                return new Car();
            }
        }

        // Concrete Factory creates Bike object
        public class BikeFactory : VehicleFactory
        {
            public override IVehicle CreateVehicle()
            {
                return new Bike();
            }
        }


        public static void Run()
        {
            // Client works with factory abstraction
            VehicleFactory factory = new CarFactory();

            IVehicle vehicle = factory.CreateVehicle();

            vehicle.Drive();
        }

    }
}