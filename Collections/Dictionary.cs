using System.Diagnostics;

namespace BenchmarkCollections.Collections
{
    internal class Dictionary : Collection
    {
        private System.Collections.Generic.Dictionary<int, int> dictionary;

        protected override bool useIndex() { return true; }
        private int valueWanted = 0;

        protected override void Create(int[] array)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            dictionary = new Dictionary<int, int>();
            for (int i = 0; i < array.Length; i++)
                dictionary.Add(i, array[i]);
            stopwatch.Stop();
            Log("Create", stopwatch.ElapsedMilliseconds);
        }

        protected override void Search(int numberWanted)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            string notFound = "";
            if (!dictionary.TryGetValue(numberWanted, out int valueFound))
                notFound = " | Number not found";
            valueWanted = valueFound;
            stopwatch.Stop();
            Log("Search", stopwatch.ElapsedMilliseconds);
            Console.Write(notFound);
        }

        protected override void Remove(int numberWanted)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            dictionary.Remove(numberWanted);
            stopwatch.Stop();
            Log("Remove", stopwatch.ElapsedMilliseconds);
        }

        protected override void Insert(int numberWanted)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            dictionary.Add(numberWanted, valueWanted);
            stopwatch.Stop();
            Log("Insert", stopwatch.ElapsedMilliseconds);
        }
    }
}
