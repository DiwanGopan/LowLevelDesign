using System;

namespace ConceptPractice.OOPS
{
    public class Encapsulation
    {
        /*
        Encapsulation says 2 things:

        1. An object's characteristics and its behaviour are encapsulated together
           within that object.

        2. All the characteristics or behaviours are not for everyone to access.
           Object should provide data security.

        We follow the above 2 points in programming by:

        1. Creating a class that acts as a blueprint for object creation.
           Class contains all the characteristics (variables) and behaviours (methods)
           in one block, encapsulating them together.

        2. We introduce access modifiers (public, private, protected)
           to provide data security to class members.
        */

        private class SportsCar
        {
            // Private fields → Data Hiding
            private string brand;
            private string model;
            private bool isEngineOn;
            private int currentSpeed;
            private int currentGear;

            // New variable to explain Getters and Setters
            private string tyreCompany;

            // Constructor
            public SportsCar(string brand, string model)
            {
                this.brand = brand;
                this.model = model;

                isEngineOn = false;
                currentSpeed = 0;
                currentGear = 0;

                tyreCompany = "MRF";
            }

            // Getter Method
            public int GetSpeed()
            {
                return currentSpeed;
            }

            // Getter Method
            public string GetTyreCompany()
            {
                return tyreCompany;
            }

            // Setter Method
            public void SetTyreCompany(string tyreCompany)
            {
                this.tyreCompany = tyreCompany;
            }

            public void StartEngine()
            {
                isEngineOn = true;

                Console.WriteLine($"{brand} {model} : Engine starts with a roar!");
            }

            public void ShiftGear(int gear)
            {
                if (!isEngineOn)
                {
                    Console.WriteLine($"{brand} {model} : Engine is off! Cannot shift gear.");
                    return;
                }

                currentGear = gear;

                Console.WriteLine($"{brand} {model} : Shifted to gear {currentGear}");
            }

            public void Accelerate()
            {
                if (!isEngineOn)
                {
                    Console.WriteLine($"{brand} {model} : Engine is off! Cannot accelerate.");
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

            public void StopEngine()
            {
                isEngineOn = false;
                currentGear = 0;
                currentSpeed = 0;

                Console.WriteLine($"{brand} {model} : Engine turned off.");
            }
        }

        // Main Class

        public static void Run()
        {
            SportsCar mySportsCar = new SportsCar("Ford", "Mustang");

            mySportsCar.StartEngine();
            mySportsCar.ShiftGear(1);
            mySportsCar.Accelerate();
            mySportsCar.ShiftGear(2);
            mySportsCar.Accelerate();
            mySportsCar.Brake();
            mySportsCar.StopEngine();

            // ❌ Not Allowed because currentSpeed is private
            // mySportsCar.currentSpeed = 500;

            Console.WriteLine($"Current Speed of My Sports Car is {mySportsCar.GetSpeed()}");
            Console.WriteLine($"Tyre Company of Car is {mySportsCar.GetTyreCompany()}");

            Console.ReadLine();
        }
    }
}