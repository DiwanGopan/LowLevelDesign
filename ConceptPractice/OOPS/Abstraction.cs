using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Text;

namespace ConceptPractice.OOPS
{
    public class Abstraction
    {
        /*
            Car Interface --> Acts as an interface for the outside world to operate the car.
            This interface tells 'WHAT' all it can do rather than 'HOW' it does that.

            Since this is an interface, we cannot directly create objects of this.
            We need to implement it first, and then that child class will have the responsibility
            to provide implementation details of all the methods in the interface.

            In our real-world example of a Car, imagine you sitting in the car and being able
            to operate the car (StartEngine, Accelerate, Brake, ShiftGear) just by pressing
            pedals/buttons/steering wheel etc. You don't need to know how these things work,
            and also they are hidden under the hood.

            This interface 'ICar' denotes that (pedals/buttons/steering wheel etc).
        */
        private interface ICar
        {
            void StartEngine();
            void ShiftGear(int gear);
            void Accelerate();
            void Brake();
            void StopEngine();
        }

        /*
            This is a Concrete class (A class that provides implementation details
            of an interface/abstract class).

            Now anyone can make an object of 'SportsCar' and can assign it to
            'ICar' reference. (See Main method for this)

            In our real-world example of a Car, as you cannot have a real car
            by just having its body only (all these buttons or pedals),
            you need to have the actual implementation of 'What' happens
            when we press these buttons.

            'SportsCar' class denotes that actual implementation.

            Hence we can conclude, to denote a real-world car in programming
            we created 2 classes:
            1. One to denote all the user-interface like pedals, buttons,
               steering wheel etc ('ICar' interface).
            2. Another one to denote the actual car with all the implementations
               of these buttons ('SportsCar' class).
        */
        private class SportsCar : ICar
        {
            string brand;
            string model;
            bool isEngineOn = false;
            int currentSpeed = 0;
            int currentGear = 0;

            public SportsCar(string brand, string model)
            {
                this.brand = brand;
                this.model = model;
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
                Console.WriteLine($"{brand} {model} : Shifted to gear {currentGear}.");
            }

            public void Accelerate()
            {
                if (!isEngineOn)
                {
                    Console.WriteLine($"{brand} {model} : Engine is off! Cannot Accelerate.");
                    return;
                }

                currentSpeed += 20;
                Console.WriteLine($"{brand} {model} : Accelerating to {currentSpeed} km/h");

            }

            public void Brake()
            {
                currentSpeed -= 20;
                if (currentSpeed < 0) currentSpeed = 0;
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

        public static void Run()
        {
            ICar myCar = new SportsCar("Ford", "Mustang");

            myCar.StartEngine();
            myCar.ShiftGear(1);
            myCar.Accelerate();
            myCar.ShiftGear(2);
            myCar.Accelerate();
            myCar.Accelerate();
            myCar.Brake();
            myCar.StopEngine();
        }
    }
}
