using System.Diagnostics;

namespace BenchmarkCollections.Collections
{
    internal class ArrayList : Collection
    {
        private System.Collections.ArrayList arrayList;

        protected override bool useIndex() { return false; }

        protected override void Create(int[] array)
        {
            Console.WriteLine("ArrayList");
            Stopwatch stopwatch = Stopwatch.StartNew();
            arrayList = new System.Collections.ArrayList(array);
            stopwatch.Stop();
            Log("Create", stopwatch.ElapsedMilliseconds);
        }

        protected override void Search(int numberWanted)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            int index = arrayList.IndexOf(numberWanted);
            stopwatch.Stop();
            Log("Search", stopwatch.ElapsedMilliseconds);
        }

        protected override void Remove(int numberWanted)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            arrayList.Remove(numberWanted);
            stopwatch.Stop();
            Log("Remove", stopwatch.ElapsedMilliseconds);
        }

        protected override void Insert(int numberWanted)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            arrayList.Add(numberWanted);
            stopwatch.Stop();
            Log("Insert", stopwatch.ElapsedMilliseconds);
        }
    }
}
