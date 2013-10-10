using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HashTableLib;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            double i = 1835731;
            var a = i.GetHashCode();
            HashTable<double, string> hash = new HashTable<double, string>(20);
            hash.Add(1, "Hello");
            hash.Add(10, "Hello, Artyom!");
            hash.Add(i, "wfwf");

            var sdf = hash.Keys.ToList();

            Console.WriteLine(hash.GetValue(i));
        }
    }
}
