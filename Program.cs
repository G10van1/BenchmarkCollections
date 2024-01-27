using BenchmarkCollections.Collections;
using System.Diagnostics;

namespace BenchmarkCollections
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine($"Comparing the time spent creating, searching, removing and inserting numbers in collections.\n");

            // Create an int array of SIZE elements with random values between 0 and MAX_VALUE, random a number to find in array
            const int SIZE = 15000000;
            const int MAX_VALUE = 5000000;
            int[] array = new ArraySimple(SIZE, MAX_VALUE, out int indexNumber).Array;

            // Measure time to find the number using different collections
            List<ICollection> collections = new List<ICollection>
            {
                new ArrayList(),
                new List(),
                new LinkedList(),
                new Dictionary(),
                new SortedList(),
                new SortedDictionary()
            };

            // Add more classes to other collections if necessary
            foreach (var collection in collections)
            {
                collection.TestPerformance(array, indexNumber);
            }
        }
    }    
}