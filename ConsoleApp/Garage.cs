﻿using System.Collections;
using System.Runtime.CompilerServices;
[assembly: InternalsVisibleTo("Tests")] // Allow unit tests to access internal members of this assembly


namespace ConsoleApp
{
    internal class Garage<T> : IEnumerable<T>, IGarage<T> where T : Spot
    {
        private readonly T[] _spots;
        public int Capacity { get; }
        public T[] Spots => _spots;

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
