using System.Collections;

namespace ConsoleApp
{
    internal class Garage<T> : IEnumerable<T>
    {
        private readonly T[] _vehicles;
        public int Capacity { get; }

        public Garage(int capacity)
        {
            Capacity = capacity;
            _vehicles = new T[capacity];
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in _vehicles)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
