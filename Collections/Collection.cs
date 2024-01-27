namespace BenchmarkCollections.Collections
{
    internal abstract class Collection : ICollection
    {
        protected abstract bool useIndex();
        protected abstract void Create(int[] array);
        protected abstract void Search(int numberWanted);
        protected abstract void Remove(int numberWanted);
        protected abstract void Insert(int numberWanted);

        void ICollection.TestPerformance(int[] array, int indexNumberWanted)
        {
            int numberWanted = useIndex() ? indexNumberWanted : array[indexNumberWanted];
            Create(array);
            Search(numberWanted);
            Remove(numberWanted);
            Insert(numberWanted);
        }

        protected void Log(string operation, long time)
        {
            Console.WriteLine($"     {operation}:{time.ToString().PadLeft(11, ' ')} ms");
        }
    }
}
