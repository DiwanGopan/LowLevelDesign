using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptPractice.DesignPatterns.FactoryPattern
{
    public class FactoryMethodPattern
    {
        public interface IVehicle
        {
            void Drive();
        }

        // Products
        public class Car : IVehicle
        {
            public void Drive()
            {
                Console.WriteLine("Driving Car");
            }
        }

        public class Bike : IVehicle
        {
            public void Drive()
            {
                Console.WriteLine("Driving Bike");
            }
        }

        // Abstract Factory
        public abstract class VehicleFactory
        {
            public abstract IVehicle CreateVehicle();
        }

        // Concrete Factories
        public class CarFactory : VehicleFactory
        {
            public override IVehicle CreateVehicle()
            {
                return new Car();
            }
        }

        public class BikeFactory : VehicleFactory
        {
            public override IVehicle CreateVehicle()
            {
                return new Bike();
            }
        }

        class Program
        {
            public static void Run()
            {
                VehicleFactory factory = new CarFactory();

                IVehicle vehicle = factory.CreateVehicle();

                vehicle.Drive();
            }
        }
    }
}
