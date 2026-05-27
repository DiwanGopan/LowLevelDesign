using System;

namespace ConceptPractice.OOPS
{
    /*
    We know that real-world objects show inheritance relationships where we
    have a parent object and child object.

    Child objects have all the characteristics or behaviours that the parent has,
    plus some additional characteristics/behaviours.

    Example:
    - All cars have brand, model, start, stop, accelerate etc.
    - Manual cars have gear systems.
    - Electric cars have battery systems.

    We represent this scenario in programming using inheritance.

    Parent Class  -> Common properties and methods
    Child Classes -> Specialized properties and methods

    This provides:
    - Code Reusability
    - Better Organization
    - Real-world Modelling
    */

    // Parent Class
    public class Inheritance
    {
        class Car
        {
            // Protected → accessible inside child classes
            protected string brand;
            protected string model;
            protected bool isEngineOn;
            protected int currentSpeed;

            // Constructor
            public Car(string brand, string model)
            {
                this.brand = brand;
                this.model = model;

                isEngineOn = false;
                currentSpeed = 0;
            }

            // Common methods for all cars

            public void StartEngine()
            {
                isEngineOn = true;

                Console.WriteLine($"{brand} {model} : Engine started.");
            }

            public void StopEngine()
            {
                isEngineOn = false;
                currentSpeed = 0;

                Console.WriteLine($"{brand} {model} : Engine turned off.");
            }

            public void Accelerate()
            {
                if (!isEngineOn)
                {
                    Console.WriteLine($"{brand} {model} : Cannot accelerate! Engine is off.");
                    return;
                }

                currentSpeed += 20;

                Console.WriteLine($"{brand} {model} : Accelerating to {currentSpeed} km/h");
            }

            public void Brake()
            {
                currentSpeed -= 20;

                if (currentSpeed < 0)
                    currentSpeed = 0;

                Console.WriteLine($"{brand} {model} : Braking! Speed is now {currentSpeed} km/h");
            }
        }

        // Child Class → Inherits from Car
        class ManualCar : Car
        {
            // Specific to Manual Car
            private int currentGear;

            public ManualCar(string brand, string model)
                : base(brand, model)
            {
                currentGear = 0;
            }

            // Specialized method
            public void ShiftGear(int gear)
            {
                currentGear = gear;

                Console.WriteLine($"{brand} {model} : Shifted to gear {currentGear}");
            }
        }

        // Child Class → Inherits from Car
        class ElectricCar : Car
        {
            // Specific to Electric Car
            private int batteryLevel;

            public ElectricCar(string brand, string model)
                : base(brand, model)
            {
                batteryLevel = 100;
            }

            // Specialized method
            public void ChargeBattery()
            {
                batteryLevel = 100;

                Console.WriteLine($"{brand} {model} : Battery fully charged!");
            }
        }

        // Main Class

        public static void Run()
        {
            // Manual Car Object
            ManualCar myManualCar = new ManualCar("Suzuki", "WagonR");

            myManualCar.StartEngine();
            myManualCar.ShiftGear(1); // Specific to ManualCar
            myManualCar.Accelerate();
            myManualCar.Brake();
            myManualCar.StopEngine();

            Console.WriteLine("----------------------");

            // Electric Car Object
            ElectricCar myElectricCar = new ElectricCar("Tesla", "Model S");

            myElectricCar.ChargeBattery(); // Specific to ElectricCar
            myElectricCar.StartEngine();
            myElectricCar.Accelerate();
            myElectricCar.Brake();
            myElectricCar.StopEngine();

            Console.ReadLine();
        }
    }
}