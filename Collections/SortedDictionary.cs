using System.Diagnostics;

namespace BenchmarkCollections.Collections
{
    internal class SortedDictionary : Collection
    {
        private System.Collections.Generic.SortedDictionary<int, int> sortedDictionary;

        protected override bool useIndex() { return true; }
        private int valueWanted = 0;

        protected override void Create(int[] array)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            sortedDictionary = new SortedDictionary<int, int>();
            int count = 0;
            foreach (var item in array)
                sortedDictionary[count++] = item;
            stopwatch.Stop();
            Log("Create", stopwatch.ElapsedMilliseconds);
        }

        protected override void Search(int numberWanted)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            string notFound = "";
            if (!sortedDictionary.TryGetValue(numberWanted, out int valueFound))
                notFound = " | Number not found";
            valueWanted = valueFound;
            stopwatch.Stop();
            Log("Search", stopwatch.ElapsedMilliseconds);
            Console.Write(notFound);
        }

        protected override void Remove(int numberWanted)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            sortedDictionary.Remove(numberWanted);
            stopwatch.Stop();
            Log("Remove", stopwatch.ElapsedMilliseconds);
        }

        protected override void Insert(int numberWanted)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            sortedDictionary.Add(numberWanted, valueWanted);
            stopwatch.Stop();
            Log("Insert", stopwatch.ElapsedMilliseconds);
        }
    }
}
