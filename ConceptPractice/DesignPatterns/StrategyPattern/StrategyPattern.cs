using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptPractice.DesignPatterns.StrategyPattern
{

    /*
     
    ==============================
        STRATEGY DESIGN PATTERN
    ==============================

    Definition:
    Strategy Pattern defines a family of algorithms,
    encapsulates each one into separate classes,
    and makes them interchangeable at runtime.

    In simple words:
    Instead of writing many if-else conditions,
    we create separate classes for each behavior.

    ---------------------------------------------
    REAL-TIME EXAMPLE
    ---------------------------------------------

    We want to sort data.

    Different sorting algorithms:
    - Bubble Sort
    - Quick Sort
    - Merge Sort

    Task is SAME:
        "Sort the array"

    But behavior/algorithm changes.

    This is the perfect use case for Strategy Pattern.

    ---------------------------------------------
    WHY NOT USE IF-ELSE?
    ---------------------------------------------

    BAD APPROACH:

    if(sortType == "Bubble")
    {
        // Bubble Sort Logic
    }
    else if(sortType == "Quick")
    {
        // Quick Sort Logic
    }

    Problems:
    - Huge if-else blocks
    - Difficult maintenance
    - Violates Open/Closed Principle
    - Hard to test
    - Difficult to extend

    ---------------------------------------------
    STRATEGY PATTERN SOLUTION
    ---------------------------------------------

    1. Create common interface
    2. Create separate strategy classes
    3. Context class uses strategy
    4. Client changes strategy dynamically

    ---------------------------------------------
    FLOW
    ---------------------------------------------

    Client
       ↓
    SortContext
       ↓
    ISortStrategy
       ↓
    BubbleSort / QuickSort / MergeSort

    */

    public class StrategyPattern
    {

        // ============================================================
        // STEP 1:
        // STRATEGY INTERFACE
        // Common contract for all sorting algorithms
        // ============================================================


        public interface ISortStrategy
        {
            void Sort(List<int> numbers);
        }



        // ============================================================
        // STEP 2:
        // CONCRETE STRATEGIES
        // Different sorting algorithms
        // ============================================================


        public class BubbleSortStrategy : ISortStrategy
        {
            public void Sort(List<int> numbers)
            {
                Console.WriteLine("Sorting using Bubble Sort");


                // For demonstration, we'll just call the built-in sort method
                numbers.Sort();
                
                Console.WriteLine(string.Join(", ", numbers));
            }
        }

        public class QuickSortStrategy : ISortStrategy
        {
            public void Sort(List<int> numbers)
            {
                Console.WriteLine("Sorting using Quick Sort");

                // For demonstration, we'll just call the built-in sort method
                numbers.Sort();

                Console.WriteLine(string.Join(", ", numbers));
            }
        }

        public class MergedSortStrategy : ISortStrategy
        {
            public void Sort(List<int> numbers)
            {
                Console.WriteLine("Sorting using Merge Sort");

                // For demonstration, we'll just call the built-in sort method
                numbers.Sort();
                
                Console.WriteLine(string.Join(", ", numbers));
            }
        }


        // ============================================================
        // STEP 3:
        // CONTEXT CLASS
        // Uses strategy object
        // ============================================================


        public class SortContext
        {
            private ISortStrategy _sortStrategy;

            // Set strategy dynamically
            public void SetSortStrategy(ISortStrategy sortStrategy)
            {
                _sortStrategy = sortStrategy;
            }


            // Execute selected strategy
            public void Sort(List<int> numbers)
            {

                if (_sortStrategy == null)
                {
                    Console.WriteLine("No sorting strategy set.");
                    return;
                }


                _sortStrategy.Sort(numbers);
            }
        }


        // ============================================================
        // STEP 4:
        // CLIENT CODE
        // ============================================================

        public static void Run()
        {
            var numbers1 = new List<int> { 5, 2, 9, 1, 5, 6 };

            var numbers2 = new List<int> { 9, 27, 1, 14, 0, 11 };

            var numbers3 = new List<int> { 10, 32, 6, 1, 7, 17 };

            var context = new SortContext();

            // Use Bubble Sort
            context.SetSortStrategy(new BubbleSortStrategy());
            context.Sort(numbers1);

            // Use Quick Sort
            context.SetSortStrategy(new QuickSortStrategy());
            context.Sort(numbers2);

            // Use Merge Sort
            context.SetSortStrategy(new MergedSortStrategy());
            context.Sort(numbers3);

        }
    }
}
