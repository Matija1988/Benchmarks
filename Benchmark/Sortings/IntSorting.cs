using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benchmark.Sortings
{
    [MemoryDiagnoser]
    public class IntSorting
    {

        public IntSorting()
        {
            Numbers = PopulateArray();
            Sorter = new IntSorts();
        }
        [Params(100, 250, 500, 1000, 10000, 100000, 1000000)]
        public int Count;


        public int[] Numbers { get; set; }

        public IntSorts Sorter { get; set; }

        public int[] PopulateArray()
        {
            Random Rnd = new Random();
            int[] numbers = new int[Count];

            for (int i = 0; i < Count; i++)
            {
                numbers[i] = Rnd.Next(-100000, 110000);
            }
            return numbers;
        }

        [Benchmark]
        public void Bubble()
        {
            Sorter.BubbleSort(Numbers);
        }
        [Benchmark]
        public void Insert()
        {
            Sorter.InsertSort(Numbers);
        }
        [Benchmark]
        public void Select()
        {
            Sorter.SelectionSort(Numbers);
        }

    }
}






