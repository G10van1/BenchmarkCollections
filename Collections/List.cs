using System.Diagnostics;

namespace BenchmarkCollections.Collections
{
    internal class List : Collection
    {
        private System.Collections.Generic.List<int> list;

        protected override bool useIndex() { return false; }

        protected override void Create(int[] array)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            list = new System.Collections.Generic.List<int>(array);
            stopwatch.Stop();
            Log("Create", stopwatch.ElapsedMilliseconds);
        }

        protected override void Search(int numberWanted)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            int index = list.IndexOf(numberWanted);
            stopwatch.Stop();
            Log("Search", stopwatch.ElapsedMilliseconds);
        }

        protected override void Remove(int numberWanted)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            list.Remove(numberWanted);
            stopwatch.Stop();
            Log("Remove", stopwatch.ElapsedMilliseconds);
        }

        protected override void Insert(int numberWanted)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            list.Add(numberWanted);
            stopwatch.Stop();
            Log("Insert", stopwatch.ElapsedMilliseconds);
        }
    }
}