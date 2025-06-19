
namespace ConsoleApp
{
    internal interface IGarage<T> where T : Spot
    {
        int Capacity { get; }
        T[] Spots { get; }

        IEnumerator<T> GetEnumerator();
    }
}