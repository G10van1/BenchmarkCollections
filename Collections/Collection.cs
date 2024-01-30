using System.Diagnostics;
using System.Text;

namespace BenchmarkCollections.Collections
{
    internal abstract class Collection : ICollection
    {
        private StringBuilder log = new StringBuilder();
        public string GetLog() { return log.ToString(); }
        protected abstract bool useIndex();
        protected abstract void Create(int[] array);
        protected abstract void Search(int numberWanted);
        protected abstract void Remove(int numberWanted);
        protected abstract void Insert(int numberWanted);

        (long, string) ICollection.TestPerformance(int[] array, int indexNumberWanted)
        {
            log.AppendLine(this.GetType().ToString().Split('.')[2]);            
            int numberWanted = useIndex() ? indexNumberWanted : array[indexNumberWanted];
            Stopwatch stopwatch = Stopwatch.StartNew();
            Create(array);
            Search(numberWanted);
            Remove(numberWanted);
            Insert(numberWanted);
            stopwatch.Stop();
            Log("Total ", stopwatch.ElapsedMilliseconds);
            return (stopwatch.ElapsedMilliseconds, GetLog());
        }

        protected void Log(string operation, long time)
        {
            log.AppendLine($"     {operation}:{time.ToString().PadLeft(11, ' ')} ms");
        }
    }
}
