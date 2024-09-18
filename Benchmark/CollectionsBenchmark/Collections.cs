using Benchmark.DataSeed;
using BenchmarkDotNet.Attributes;
using Microsoft.Diagnostics.Tracing.Parsers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benchmark.CollectionsBenchmark
{
    [MemoryDiagnoser]
    public class Collections
    {
        private List<Person> _personList;

        private ImmutableList<Person> _personsImmuList;

        private ImmutableArray<Person> _personImmutableArray;

        private Stack<Person> _personStack;

        [Params(100, 1000, 10000, 100000)]
        public int Count;

        
        public int _targetId; 


        [GlobalSetup]
        public void Setup ()
        {
            _personList = DataProvider.GeneratePersons(Count);
            _personsImmuList = DataProvider.GeneratePersons(Count).ToImmutableList();

            _personImmutableArray = DataProvider.GeneratePersons(Count).ToImmutableArray();

            _personStack = new Stack<Person>(DataProvider.GeneratePersons(Count));

            _targetId = Count / 2 + 11;
        }

        [Benchmark]
        public void BenchmarkList ()
        {
         

            foreach (var person in _personList)
            {
                var id = person?.Id + 1;
            }
         
        }

        [Benchmark]
        public void BenchmarkImmutableList ()
        {
         

            foreach (var person in _personsImmuList)
            {
                var id = person?.Id + 1;
            }
        }

        [Benchmark]
        public void BenchmarkStack()
        {
            foreach(var person in _personStack)
            {
                var id = person?.Id + 1;
            }
        }

        [Benchmark]
        public void BenchmarkImmutableArrayIteration ()
        {
            foreach (var person in _personImmutableArray)
            {
                var id = person.Id + 1;
            }
        }

        [Benchmark]

        public void BenchmarkFindByIdList () => _personList.Find(p=> p.Id == _targetId);
        [Benchmark]

        public void BenchmarkFindByIdFirstOrDefaultList () => _personList.FirstOrDefault(p => p.Id == _targetId);

        [Benchmark]
        public void BenchmarkFindByIdImmutableList () => _personsImmuList.Find(p => p.Id == _targetId);

        [Benchmark]
        public void BenchmarkFindByIdFirstOrDefaultImmutableList () => _personsImmuList.FirstOrDefault(p => p.Id == _targetId);

        [Benchmark]
        public void BenchmarkFindByIdImmutableArray () => _personImmutableArray.FirstOrDefault(p => p.Id == _targetId);


 

    }
}
