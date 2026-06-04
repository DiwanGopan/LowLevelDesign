using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ConceptPractice.DesignPatterns.FactoryPattern.AbstractFactoryPattern;

namespace ConceptPractice.DesignPatterns.FactoryPattern
{
    /*
        =========================================================
                    ABSTRACT FACTORY DESIGN PATTERN
        =========================================================

        Definition:
        Abstract Factory Pattern is a Creational Design Pattern
        used to create families of related or dependent objects
        without specifying their concrete classes.

        ---------------------------------------------------------
        MAIN IDEA
        ---------------------------------------------------------

        Factory Method creates ONE product.

        Abstract Factory creates MULTIPLE RELATED PRODUCTS.

        The factory ensures that related objects belong
        to the same family.

        ---------------------------------------------------------
        FACTORY METHOD VS ABSTRACT FACTORY
        ---------------------------------------------------------

        Factory Method:
            Creates one product.

            Example:
            CarFactory → Car

        Abstract Factory:
            Creates a family of products.

            Example:
            SportsFactory
                → Sports Seat
                → Sports Steering

        ---------------------------------------------------------
        REAL LIFE EXAMPLE
        ---------------------------------------------------------

        Car Manufacturing Packages

        Sports Package:
            - Sports Seat
            - Sports Steering

        Luxury Package:
            - Luxury Seat
            - Luxury Steering

        The factory guarantees that matching products
        are created together.

        ---------------------------------------------------------
        FLOW
        ---------------------------------------------------------

        Client
           ↓
        Abstract Factory
           ↓
        Concrete Factory
           ↓
        Related Products

        Example:

        SportsFactory
             ↓
        SportsSeat
        SportsSteering

        ---------------------------------------------------------
        KEY COMPONENTS
        ---------------------------------------------------------

        1. Abstract Products
           → ISeat
           → ISteering

        2. Concrete Products
           → SportsSeat
           → SportsSteering
           → LuxurySeat
           → LuxurySteering

        3. Abstract Factory
           → IVehicleFactory

        4. Concrete Factories
           → SportsFactory
           → LuxuryCarFactory

        ---------------------------------------------------------
        WHY USE ABSTRACT FACTORY?
        ---------------------------------------------------------

        Problem:
        Related objects can become mixed.

        Example:
            Sports Seat
            Luxury Steering

        Such combinations may be invalid.

        Solution:
        Factory creates complete product families.

        ---------------------------------------------------------
        ADVANTAGES
        ---------------------------------------------------------

        + Ensures consistency between products
        + Follows Open/Closed Principle
        + Loose coupling
        + Easy to switch entire product families
        + Scalable architecture

        ---------------------------------------------------------
        DISADVANTAGES
        ---------------------------------------------------------

        - Many interfaces/classes
        - Increased complexity
        - More setup code

        ---------------------------------------------------------
        BEST USE CASES
        ---------------------------------------------------------

        Use when:

        - Multiple related objects exist
        - Product families must stay consistent
        - Cross-platform applications

        Examples:
        - Windows UI Factory
        - Mac UI Factory
        - Database Providers
        - Vehicle Packages
        - Theme Systems

        ---------------------------------------------------------
        INTERVIEW POINT
        ---------------------------------------------------------

        Factory Method:
            Creates one object.

        Abstract Factory:
            Creates families of related objects.

        Factory Method uses:
            Inheritance

        Abstract Factory uses:
            Composition

        ---------------------------------------------------------
        IMPORTANT UNDERSTANDING
        ---------------------------------------------------------

        SportsFactory creates:

            SportsSeat
            SportsSteering

        LuxuryCarFactory creates:

            LuxurySeat
            LuxurySteering

        Client never directly creates products.

        Client only interacts with the factory.

        ---------------------------------------------------------
        QUICK MEMORY TRICK
        ---------------------------------------------------------

        Simple Factory
            → One factory creates everything

        Factory Method
            → One factory creates one product

        Abstract Factory
            → One factory creates multiple
              related products

        =========================================================
    */

    public class AbstractFactoryPattern
    {
        // Abstract Product A
        public interface ISeat
        {
            void Type();
        }

        // Abstract Product B
        public interface ISteering
        {
            void Type();
        }

        // Sports Product Family
        public class SportsSeat : ISeat
        {
            public void Type()
            {
                Console.WriteLine("Sports Seat");
            }
        }

        // Sports Product Family
        public class SportsStreering : ISteering
        {
            public void Type()
            {
                Console.WriteLine("Sports Steering");
            }
        }

        // Luxury Product Family
        public class LuxurySea : ISeat
        {
            public void Type()
            {
                Console.WriteLine("Luxury Seat");
            }
        }

        // Luxury Product Family
        public class LuxurySteering : ISteering
        {
            public void Type()
            {
                Console.WriteLine("Luxury Steering");
            }
        }

        // Abstract Factory
        public interface IVehicleFactory
        {
            ISeat CreateSeat();
            ISteering CreateSteering();
        }

        // Creates Sports product family
        public class SportsFactory : IVehicleFactory
        {
            public ISeat CreateSeat()
            {
                return new SportsSeat();
            }

            public ISteering CreateSteering()
            {
                return new SportsStreering();
            }
        }

        // Creates Luxury product family
        public class LuxuryCarFactory : IVehicleFactory
        {
            public ISeat CreateSeat()
            {
                return new LuxurySea();
            }

            public ISteering CreateSteering()
            {
                return new LuxurySteering();
            }
        }

        public static void Run()
        {
            // Switch factory to change entire product family
            IVehicleFactory factory = new SportsFactory();

            ISeat seat = factory.CreateSeat();
            ISteering steering = factory.CreateSteering();

            seat.Type();
            steering.Type();
        }
    }
}