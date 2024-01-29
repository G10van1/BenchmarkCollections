using BenchmarkCollections.Collections;
using System.Diagnostics;
using System.Text;

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
            // Add more classes to other collections if necessary
            List<ICollection> collections = new List<ICollection>
            {
                new ArrayList(),
                new List(),
                new LinkedList(),
                new Dictionary(),
                new SortedList(),
                new SortedDictionary()
            };

            // Create array tasks
            Task<(long, string)>[] tasks = new Task<(long, string)>[collections.Count];

            // Launch tasks in parallel execution
            int i = 0;
            foreach (var collection in collections)
                tasks[i++] = Task.Run(() => collection.TestPerformance(array, indexNumber));

            // Wait for all tasks to complete
            Task.WaitAll(tasks);

            SortedDictionary<long, string> times = new SortedDictionary<long, string>();

            for (i = 0; i < collections.Count; i++)
            {                
                int count = 0;
                while (true)
                {
                    try
                    {
                        times.Add(tasks[i].Result.Item1 + count++, tasks[i].Result.Item2);
                        break;
                    }
                    catch (ArgumentException ex) { continue; }
                    catch (Exception ex) { Console.WriteLine(ex.Message); }
                }
            }

            foreach (var time in times)
                Console.WriteLine(time.Value);
        }
    }    
}