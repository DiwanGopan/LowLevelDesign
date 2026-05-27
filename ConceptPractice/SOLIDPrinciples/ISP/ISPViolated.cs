using System;

namespace ConceptPractice.SOLIDPrinciples.ISP
{
    /*
     * ============================= ISP (Interface Segregation Principle) =============================
     * 
     * Definition:
     * 
     * "Clients should not be forced to depend on methods
     *  they do not use."
     * 
     * ----------------------------------------------------------------------------
     * Simple Meaning:
     * 
     * Large interfaces should be split into smaller,
     * specific interfaces.
     * 
     * A class should only implement methods
     * that are actually required.
     * 
     * ----------------------------------------------------------------------------
     * ISP Violation in this Example:
     * 
     * Interface:
     * -> IShape
     * 
     * contains:
     * 
     * 1. Area()
     * 2. Volume()
     * 
     * ----------------------------------------------------------------------------
     * Problem:
     * 
     * 2D Shapes like:
     * -> Square
     * -> Rectangle
     * 
     * DO NOT have volume.
     * 
     * But they are FORCED to implement:
     * -> Volume()
     * 
     * Therefore:
     * Unsupported/unused methods are added.
     * 
     * ----------------------------------------------------------------------------
     * Result:
     * 
     * Square and Rectangle throw:
     * -> NotSupportedException
     * 
     * This clearly indicates:
     * Interface design is incorrect.
     * 
     * ----------------------------------------------------------------------------
     * Why this is bad in LLD?
     * 
     * 1. Fat interfaces
     * 2. Unnecessary dependencies
     * 3. Runtime exceptions
     * 4. Poor abstraction design
     * 5. Difficult maintenance
     * 
     * ----------------------------------------------------------------------------
     * Proper Solution:
     * 
     * Separate interfaces:
     * 
     * -> I2DShape
     * -> I3DShape
     * 
     * So classes implement only relevant behaviors.
     * ===============================================================================================
     */

    public class ISPViolated
    {

        /*
         * Single interface for all shapes
         * 
         * ISP Violated:
         * 2D shapes are forced to implement Volume().
         */
        public interface IShape
        {
            double Area();

            double Volume();
        }


        /*
         * Square is a 2D shape
         * 
         * But forced to implement Volume().
         */
        public class Square : IShape
        {
            private double side;

            public Square(double s)
            {
                side = s;
            }

            public double Area()
            {
                return side * side;
            }


            /*
             * Unnecessary method
             * 
             * ISP Violation:
             * Square does not have volume.
             */
            public double Volume()
            {
                throw new NotSupportedException(
                    "Volume not applicable for Square"
                );
            }
        }


        /*
         * Rectangle is also a 2D shape
         * 
         * But forced to implement Volume().
         */
        public class Rectangle : IShape
        {
            private double length;

            private double width;

            public Rectangle(double l, double w)
            {
                length = l;

                width = w;
            }

            public double Area()
            {
                return length * width;
            }


            /*
             * Unnecessary method
             * 
             * ISP Violation:
             * Rectangle does not support volume.
             */
            public double Volume()
            {
                throw new NotSupportedException(
                    "Volume not applicable for Rectangle"
                );
            }
        }


        /*
         * Cube is a 3D shape
         * 
         * Volume operation is valid here.
         */
        public class Cube : IShape
        {
            private double side;

            public Cube(double s)
            {
                side = s;
            }

            public double Area()
            {
                return 6 * side * side;
            }

            public double Volume()
            {
                return side * side * side;
            }
        }


        public static void Run()
        {
            IShape square = new Square(5);

            IShape rectangle = new Rectangle(4, 6);

            IShape cube = new Cube(3);


            Console.WriteLine(
                $"Square Area: {square.Area()}"
            );

            Console.WriteLine(
                $"Rectangle Area: {rectangle.Area()}"
            );

            Console.WriteLine(
                $"Cube Area: {cube.Area()}"
            );

            Console.WriteLine(
                $"Cube Volume: {cube.Volume()}"
            );


            try
            {
                /*
                 * Runtime exception occurs because
                 * Square does not support Volume().
                 */
                Console.WriteLine(
                    $"Square Volume: {square.Volume()}"
                );
            }
            catch (NotSupportedException e)
            {
                Console.WriteLine(
                    $"Exception: {e.Message}"
                );
            }
        }
    }
}