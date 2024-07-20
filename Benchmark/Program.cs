// See https://aka.ms/new-console-template for more information


using Benchmark.CollectionsBenchmark;
using Benchmark.Sortings;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;
using System.Text;


var results = BenchmarkRunner.Run<Collections>();


[MemoryDiagnoser]
public class Demo
{
    [Benchmark]
    public string GetFullStringNormally()
    {
        string output = "";

        for(int i = 0; i <10000 ; i++) 
        {
            output += i;
        }
        return output;
    }

    [Benchmark]
    public string GetFullStringWithStringBuilder() 
    { 
        StringBuilder output = new StringBuilder();

        for(int i = 0; i < 10000; i++) 
        {
            output.Append(i);
            
        }
        return output.ToString();
    }

}