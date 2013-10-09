using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTableLib
{
    public class HashTablePair<TKey, TValue>
    {
        public HashTablePair(TKey key, TValue value)
        {
            Value = value;
            Key = key;
        }

        public TKey Key { get; private set; }
        public TValue Value { get; private set; }
    }
}
