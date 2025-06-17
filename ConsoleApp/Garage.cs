using System.Collections;

namespace ConsoleApp
{
    internal class Garage<T> : IEnumerable<T> where T : Spot
    {
        private readonly T[] _spots;
        public int Capacity { get; }
        public T[] Spots => _spots;
        public bool IsFull => _spots.All(spot => spot.IsOccupied);
        public bool IsEmpty => _spots.All(spot => !spot.IsOccupied);

        public Garage(int capacity, Func<int, T> spotFactory)
        {
            Capacity = capacity;
            _spots = new T[capacity];

            for (int i = 0; i < capacity; i++)
            {
                _spots[i] = spotFactory(i + 1); // Create every Spot with a unique number starting from 1
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var spot in _spots)
            {
                yield return spot;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
