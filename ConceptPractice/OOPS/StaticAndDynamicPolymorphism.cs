using System;

namespace ConceptPractice.OOPS
{
    public class StaticAndDynamicPolymorphism
    {
        // Base Car class
        abstract class Car
        {
            protected string brand;
            protected string model;
            protected bool isEngineOn;
            protected int currentSpeed;

            public Car(string brand, string model)
            {
                this.brand = brand;
                this.model = model;
                this.isEngineOn = false;
                this.currentSpeed = 0;
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

            // Abstract methods for polymorphism
            public abstract void Accelerate();          // Dynamic Polymorphism

            public abstract void Accelerate(int speed); // Static Polymorphism (Method Overloading)

            public abstract void Brake();               // Dynamic Polymorphism
        }

        class ManualCar : Car
        {
            private int currentGear;

            public ManualCar(string brand, string model) : base(brand, model)
            {
                currentGear = 0;
            }

            // Specialized method for Manual Car
            public void ShiftGear(int gear)
            {
                currentGear = gear;
                Console.WriteLine($"{brand} {model} : Shifted to gear {currentGear}");
            }

            // Overriding accelerate - Dynamic Polymorphism
            public override void Accelerate()
            {
                if (!isEngineOn)
                {
                    Console.WriteLine($"{brand} {model} : Cannot accelerate! Engine is off.");
                    return;
                }

                currentSpeed += 20;
                Console.WriteLine($"{brand} {model} : Accelerating to {currentSpeed} km/h");
            }

            // Overriding + Overloading accelerate
            public override void Accelerate(int speed)
            {
                if (!isEngineOn)
                {
                    Console.WriteLine($"{brand} {model} : Cannot accelerate! Engine is off.");
                    return;
                }

                currentSpeed += speed;
                Console.WriteLine($"{brand} {model} : Accelerating to {currentSpeed} km/h");
            }

            // Overriding brake
            public override void Brake()
            {
                currentSpeed -= 20;

                if (currentSpeed < 0)
                    currentSpeed = 0;

                Console.WriteLine($"{brand} {model} : Braking! Speed is now {currentSpeed} km/h");
            }
        }

        class ElectricCar : Car
        {
            private int batteryLevel;

            public ElectricCar(string brand, string model) : base(brand, model)
            {
                batteryLevel = 100;
            }

            // Specialized method for Electric Car
            public void ChargeBattery()
            {
                batteryLevel = 100;
                Console.WriteLine($"{brand} {model} : Battery fully charged!");
            }

            // Overriding accelerate
            public override void Accelerate()
            {
                if (!isEngineOn)
                {
                    Console.WriteLine($"{brand} {model} : Cannot accelerate! Engine is off.");
                    return;
                }

                if (batteryLevel <= 0)
                {
                    Console.WriteLine($"{brand} {model} : Battery dead! Cannot accelerate.");
                    return;
                }

                batteryLevel -= 10;
                currentSpeed += 15;

                Console.WriteLine($"{brand} {model} : Accelerating to {currentSpeed} km/h. Battery at {batteryLevel}%.");
            }

            // Overloading + Overriding accelerate
            public override void Accelerate(int speed)
            {
                if (!isEngineOn)
                {
                    Console.WriteLine($"{brand} {model} : Cannot accelerate! Engine is off.");
                    return;
                }

                if (batteryLevel <= 0)
                {
                    Console.WriteLine($"{brand} {model} : Battery dead! Cannot accelerate.");
                    return;
                }

                batteryLevel -= (10 + speed);
                currentSpeed += speed;

                Console.WriteLine($"{brand} {model} : Accelerating to {currentSpeed} km/h. Battery at {batteryLevel}%.");
            }

            // Overriding brake
            public override void Brake()
            {
                currentSpeed -= 15;

                if (currentSpeed < 0)
                    currentSpeed = 0;

                Console.WriteLine($"{brand} {model} : Regenerative braking! Speed is now {currentSpeed} km/h. Battery at {batteryLevel}%.");
            }
        }


        public static void Run()
        {
            Car myManualCar = new ManualCar("Ford", "Mustang");

            myManualCar.StartEngine();
            myManualCar.Accelerate();
            myManualCar.Accelerate();
            myManualCar.Brake();
            myManualCar.StopEngine();

            Console.WriteLine("----------------------");

            Car myElectricCar = new ElectricCar("Tesla", "Model S");

            myElectricCar.StartEngine();
            myElectricCar.Accelerate();
            myElectricCar.Accelerate(25);
            myElectricCar.Brake();
            myElectricCar.StopEngine();
        }
    }
}