namespace BenchmarkCollections.Collections
{
    internal interface ICollection
    {
        (long, string) TestPerformance(int[] array, int indexNumberWanted);
    }
}
