using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace FirstTaskApplicationAutomatic
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = "results.txt";
            StreamWriter writer;
            List<long> ticks = new List<long>();
            int sizeOfArray = 0;
            int numberToFind;
            string number;
            Stopwatch watcher = new Stopwatch();
            int[] array;
            Random rand = new Random();
            Console.WriteLine("To exit programm input -1.");
            while (true)
            {
                Console.Write("Enter a size of array to search in: ");
                number = Console.ReadLine();

                try
                {
                    sizeOfArray = Convert.ToInt32(number);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    continue;
                }

                if (sizeOfArray == -1)
                {
                    break;
                }
                if (sizeOfArray <= 0)
                {
                    Console.WriteLine("Size must be greater than 0!");
                    continue;
                }

                array = new int[sizeOfArray];
                for (int i = 0; i < sizeOfArray; i++)
                {
                    array[i] = rand.Next(0, sizeOfArray);
                }
                Array.Sort(array);

                Console.WriteLine("Random numbers were inserted in array...");
                Console.WriteLine("Now input number between 0 and {0} to find it...(Push 'Enter' to exit)", sizeOfArray);

                ticks.Clear();

                int checker = 0;
                while (checker != 100)
                {
                    numberToFind = rand.Next(0, sizeOfArray);
                    watcher.Reset();
                    Console.WriteLine("Number to find - {0}", numberToFind);
                    watcher.Start();
                    int index = BinarySearch(array, sizeOfArray, numberToFind);
                    watcher.Stop();
                    if (index != -1 && index != -2)
                    {
                        Console.WriteLine("Number is placed at index = {0}, value = {1}", index, array[index]);
                        Console.WriteLine("Time to search = {0}", watcher.Elapsed);
                        ticks.Add(watcher.Elapsed.Ticks);
                        checker++;
                    }
                    else switch (index)
                    {
                        case -1:
                            continue;
                        case -2:
                            continue;
                    }
                }

                using (writer = new StreamWriter(name, true))
                {
                    writer.WriteLine("Array size - {0}, average time - {1}", sizeOfArray, ticks.Average());
                }
            }
        }

        static int BinarySearch(int[] array, int size, int variable)
        {
            int firstIndex = 0;
            int lastIndex = size - 1;
            int middle = firstIndex + (lastIndex - firstIndex) / 2;

            if ((array[firstIndex] > variable) || (array[lastIndex] < variable))
            {
                return -2;
            }
            while (firstIndex < lastIndex)
            {
                if (variable <= array[middle])
                {
                    lastIndex = middle;
                }
                else
                {
                    firstIndex = middle + 1;
                }
                middle = firstIndex + (lastIndex - firstIndex) / 2;
            }

            if (array[lastIndex] == variable)
            {
                return lastIndex;
            }
            else
            {
                return -1;
            }
        }
    }
}