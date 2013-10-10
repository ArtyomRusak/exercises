using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HashTableLib
{
    public class HashTableArray<TKey, TValue>
    {
        private HashTablePairArray<TKey, TValue>[] _array;

        public HashTableArray(int capacity)
        {
            _array = new HashTablePairArray<TKey, TValue>[capacity];
        }

        public void Add(TKey key, TValue value)
        {
            int index = GetIndex(key);
            var pairs = _array[index];
            if (pairs == null)
            {
                pairs = new HashTablePairArray<TKey, TValue>();
                _array[index] = pairs;
            }

            _array[index].Add(key, value);
        }

        public bool Remove(TKey key)
        {
            int index = GetIndex(key);
            var pairs = _array[index];
            if (pairs != null)
            {
                return pairs.Remove(key);
            }

            return false;
        }

        public TValue GetValue(TKey key)
        {
            int index = GetIndex(key);
            var pairs = _array[index];
            if (pairs != null)
            {
                return pairs.GetValue(key);
            }

            return default(TValue);
        }

        private int GetIndex(TKey key)
        {
            return Math.Abs(key.GetHashCode() % Capacity);
        }

        public int Capacity
        {
            get
            {
                return _array.Length;
            }
        }

        public IEnumerable<TKey> Keys
        {
            get
            {
                return from pairArray in _array where pairArray != null 
                       from item in pairArray.Items select item.Key;
            }
        }

        public IEnumerable<TValue> Values
        {
            get
            {
                return from pairArray in _array where pairArray != null
                       from item in pairArray.Items select item.Value;
            }
        }
    }
}
