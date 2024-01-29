using System.Diagnostics;

namespace BenchmarkCollections.Collections
{
    internal class SortedList : Collection
    {
        private System.Collections.Generic.SortedList<int, int> sortedList;

        protected override bool useIndex() { return true; }
        private int valueWanted = 0;

        protected override void Create(int[] array)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            sortedList = new SortedList<int, int>();
            int count = 0;            
            foreach (var item in array)
                sortedList[count++] = item;
            stopwatch.Stop();
            Log("Create", stopwatch.ElapsedMilliseconds);
        }

        protected override void Search(int numberWanted)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            string notFound = "";
            if (!sortedList.TryGetValue(numberWanted, out int valueFound))
                notFound = " | Number not found";
            valueWanted = valueFound;
            stopwatch.Stop();
            Log("Search", stopwatch.ElapsedMilliseconds);
            Console.Write(notFound);
        }

        protected override void Remove(int numberWanted)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            sortedList.Remove(numberWanted);
            stopwatch.Stop();
            Log("Remove", stopwatch.ElapsedMilliseconds);
        }

        protected override void Insert(int numberWanted)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            sortedList.Add(numberWanted, valueWanted);
            stopwatch.Stop();
            Log("Insert", stopwatch.ElapsedMilliseconds);
        }
    }
}
