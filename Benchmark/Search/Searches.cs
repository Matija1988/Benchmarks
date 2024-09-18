using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benchmark.Search
{
 
    public  class Searches
    {
   
        public  int LinearSearch (int[] numbers, int numberToFind)
        {
          

            for (var i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == numberToFind)
                {
                    return i;
                }
            }

            return -1;
        }

        
        public  int BinarySearch (int[] numbers, int numberToFind)
        {
         
            int low = 0;
            int high = numbers.Length - 1;

        

            while (low <= high)
            {
                int mid = (low + high) / 2;

                if (numbers[mid] == numberToFind)
                {
                    return mid;
                }

                if (numberToFind < mid)
                {
                    high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }
               
            }
            return -1;
        }
        public int BinarySearch_Native (int[] numbers, int nubmerToFind)
        {
            var index = Array.BinarySearch(numbers, nubmerToFind);

            return index;
        }

    }
}
