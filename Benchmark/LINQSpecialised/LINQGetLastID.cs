namespace Benchmark.LINQSpecialised;
using Benchmark.DataSeed;
using BenchmarkDotNet.Attributes;
using System.Collections.Immutable;

public class LINQGetLastID
{
    private List<Person> _personList;

    [Params(100, 1000, 10000, 100000)]
    public int Count;

    [GlobalSetup]
    public void Setup ()
    {
        _personList = DataProvider.GeneratePersons(Count);
    }

    [Benchmark]
    public void GetMax()
    {
       int maxId = _personList.Max(x => x.Id) + 1;
    }

    [Benchmark]
    public void GetLast()
    {
        var lastEntity = _personList.Last();
        int maxId = lastEntity.Id + 1;
    }

    [Benchmark]
    public void GetCountMinus1()
    {
        var lastEntity = _personList.Count - 1;
        int maxID = lastEntity + 1;
    }
}
