using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benchmark.Search
{
    [MemoryDiagnoser]
    public class SearchMain
    {
        public Searches _searches { get; set; }

        int[] Numbers {  get; set; }
      
        public SearchMain ()
        {
            Numbers = PopulateArray();
            _searches = new Searches();
        }
      
        public int[] PopulateArray()
        {
           return Enumerable.Range(1, 1_000_000).ToArray();
        }

        [Params(333_333,777_777)]
        public int NumberToFind { get; set; }

        [Benchmark]
        public int LinearSearch()
        {
            var index = _searches.LinearSearch(Numbers, NumberToFind);

            return index;

        }

        [Benchmark]
        public int BinarySearch()
        {
            var index = _searches.BinarySearch(Numbers, NumberToFind);

            return index;

        }
        [Benchmark]
        public int BinarySearch_Native ()
        {
            var index = _searches.BinarySearch_Native(Numbers, NumberToFind);

            return index;
        }

    }
}
