using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTableLib
{
    public class HashTable<TKey, TValue>
    {
        private int _count;
        private HashTableArray<TKey, TValue> _array; 

        public int Count
        {
            get
            {
                return _count;
            }
        }

        public HashTable(int capacity)
        {
            if (capacity < 1)
            {
                throw new Exception("Wrong value of capacity");
            }
            _array = new HashTableArray<TKey, TValue>(capacity);
        }

        public void Add(TKey key, TValue value)
        {
            _array.Add(key, value);
            _count++;
        }

        public bool Remove(TKey key)
        {
            var check = _array.Remove(key);
            if (check)
            {
                _count--;
            }
            return check;
        }

        public TValue GetValue(TKey key)
        {
            return _array.GetValue(key);
        }

        public TValue this[TKey key]
        {
            get
            {
                return _array.GetValue(key);
            }
        }

        public IEnumerable<TKey> Keys
        {
            get
            {
                return _array.Keys;
            }
        }

        public IEnumerable<TValue> Values
        {
            get
            {
                return _array.Values;
            }
        } 
    }
}
