using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTableLib
{
    public class HashTablePairArray<TKey, TValue>
    {
        private List<HashTablePair<TKey, TValue>> _pairs;

        public void Add(TKey key, TValue value)
        {
            if (_pairs == null)
            {
                _pairs = new List<HashTablePair<TKey, TValue>>();
            }
            else
            {
                if (_pairs.Any(hashPair => hashPair.Key.Equals(key)))
                {
                    throw new ArgumentException("key");
                }
            }

            _pairs.Add(new HashTablePair<TKey, TValue>(key, value));
        }

        public bool Remove(TKey key)
        {
            bool check = false;
            foreach (var hashPair in _pairs.Where(hashPair => hashPair.Key.Equals(key)))
            {
                _pairs.Remove(hashPair);
                check = true;
            }

            return check;
        }

        public TValue GetValue(TKey key)
        {
            foreach (var hashPair in _pairs.Where(hashPair => hashPair.Key.Equals(key)))
            {
                return hashPair.Value;
            }

            return default(TValue);
        }

        public List<HashTablePair<TKey, TValue>> Items
        {
            get
            {
                return _pairs;
            }
        }
    }
}
