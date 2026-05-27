using System;

namespace ConceptPractice.SOLIDPrinciples.ISP
{
    /*
     * ============================= ISP FOLLOWED =============================
     * 
     * ISP (Interface Segregation Principle):
     * 
     * "Clients should not be forced to depend
     *  on methods they do not use."
     * 
     * ----------------------------------------------------------------------------
     * Simple Meaning:
     * 
     * Instead of creating one large/fat interface,
     * create smaller and specific interfaces.
     * 
     * ----------------------------------------------------------------------------
     * In this solution:
     * 
     * Interfaces are properly separated:
     * 
     * 1. ITwoDimensionalShape
     *    -> Contains only Area()
     * 
     * 2. IThreeDimensionalShape
     *    -> Contains Area() + Volume()
     * 
     * ----------------------------------------------------------------------------
     * Class Responsibilities:
     * 
     * Square
     * -> Implements only 2D behavior
     * 
     * Rectangle
     * -> Implements only 2D behavior
     * 
     * Cube
     * -> Implements 3D behavior
     * 
     * ----------------------------------------------------------------------------
     * Why this follows ISP?
     * 
     * Because:
     * 
     * 1. No unnecessary methods
     * 2. No runtime exceptions
     * 3. No forced implementations
     * 4. Better abstraction design
     * 5. Classes depend only on required behavior
     * 
     * ----------------------------------------------------------------------------
     * Benefits in LLD:
     * 
     * 1. Loose coupling
     * 2. Clean interfaces
     * 3. Better scalability
     * 4. Easier maintenance
     * 5. Reusable abstractions
     * =================================================================================
     */

    public class ISPFollowed
    {
        /*
         * Interface for 2D Shapes
         * 
         * Contains only Area().
         */
        public interface ITwoDimensionalShape
        {
            double Area();
        }


        /*
         * Interface for 3D Shapes
         * 
         * Contains:
         * 1. Area()
         * 2. Volume()
         */
        public interface IThreeDimensionalShape
        {
            double Area();

            double Volume();
        }


        /*
         * Square
         * 
         * Implements only 2D shape behavior.
         */
        public class Square : ITwoDimensionalShape
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
        }


        /*
         * Rectangle
         * 
         * Implements only 2D shape behavior.
         */
        public class Rectangle : ITwoDimensionalShape
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
        }


        /*
         * Cube
         * 
         * Implements 3D shape behavior.
         */
        public class Cube : IThreeDimensionalShape
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
            ITwoDimensionalShape square = new Square(5);

            ITwoDimensionalShape rectangle = new Rectangle(4, 6);

            IThreeDimensionalShape cube = new Cube(3);


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
        }
    }
}