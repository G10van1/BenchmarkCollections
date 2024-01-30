using System.Diagnostics;

namespace BenchmarkCollections.Collections
{
    internal class HashSet : Collection
    {
        private System.Collections.Generic.HashSet<int> hashset;

        protected override bool useIndex() { return false; }

        protected override void Create(int[] array)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            hashset = new HashSet<int>(array);
            stopwatch.Stop();
            Log("Create", stopwatch.ElapsedMilliseconds);
        }

        protected override void Search(int numberWanted)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            string notFound = "";
            if (hashset.FirstOrDefault(numberWanted) == null)
                notFound = " | Number not found";
            stopwatch.Stop();
            Log("Search", stopwatch.ElapsedMilliseconds);
            Console.Write(notFound);
        }

        protected override void Remove(int numberWanted)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            hashset.Remove(numberWanted);
            stopwatch.Stop();
            Log("Remove", stopwatch.ElapsedMilliseconds);
        }

        protected override void Insert(int numberWanted)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            hashset.Add(numberWanted);
            stopwatch.Stop();
            Log("Insert", stopwatch.ElapsedMilliseconds);
        }
    }
}
