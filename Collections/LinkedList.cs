using System.Collections.Generic;
using System.Diagnostics;

namespace BenchmarkCollections.Collections
{
    internal class LinkedList : Collection
    {
        private System.Collections.Generic.LinkedList<int> linkedList;
        private LinkedListNode<int> node; 

        protected override bool useIndex() { return false; }

        protected override void Create(int[] array)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            linkedList = new LinkedList<int>(array);
            stopwatch.Stop();
            Log("Create", stopwatch.ElapsedMilliseconds);
        }

        protected override void Search(int numberWanted)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            node = linkedList.Find(numberWanted);
            stopwatch.Stop();
            Log("Search", stopwatch.ElapsedMilliseconds);
        }

        protected override void Remove(int numberWanted)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            node = node.Previous;
            linkedList.Remove(numberWanted);
            stopwatch.Stop();
            Log("Remove", stopwatch.ElapsedMilliseconds);
        }

        protected override void Insert(int numberWanted)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            linkedList.AddAfter(node, numberWanted);
            stopwatch.Stop();
            Log("Insert", stopwatch.ElapsedMilliseconds);
        }
    }
}
