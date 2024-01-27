using System.Diagnostics;

namespace BenchmarkCollections.Collections
{
    internal class ArraySimple
    {
        private int[] array;
        public int[] Array { get { return array; } }

        public ArraySimple(int size, int maxValue, out int index)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            array = new int[size];
            Random random = new Random();

            for (int i = 0; i < size; i++)
            {
                array[i] = random.Next(maxValue + 1);
            }
            stopwatch.Stop();

            // Number to search
            index = random.Next(size + 1);

            Console.WriteLine($"Number to search:\n    Index: {index}\n    Value: {array[index]}\n");

            Console.WriteLine("Array");
            Console.WriteLine($"     Create:{stopwatch.ElapsedMilliseconds.ToString().PadLeft(11, ' ')} ms |  Inserted {size} elements.");
            TestArrayPerformance(array[index]);
        }

        public void TestArrayPerformance(int numberWanted)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            int index = System.Array.IndexOf(array, numberWanted);
            stopwatch.Stop();

            Console.WriteLine($"     Search:{stopwatch.ElapsedMilliseconds.ToString().PadLeft(11, ' ')} ms\n");
        }
    }
}
