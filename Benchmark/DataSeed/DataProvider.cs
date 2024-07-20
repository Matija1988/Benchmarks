using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benchmark.DataSeed
{
    public static class DataProvider
    {
        public static List<Person> GeneratePersons(int count)
        {
            var faker = new Faker<Person>()
                .RuleFor(p => p.Id, f => f.IndexFaker)
                .RuleFor(p => p.FirstName, f => f.Name.FirstName())
                .RuleFor(p => p.LastName, f => f.Name.LastName())
                .RuleFor(p => p.Email, f => f.Internet.Email())
                .RuleFor(p => p.Username, f => f.Internet.UserName())
                .RuleFor(p => p.Password, f => f.Internet.Password());

            return faker.Generate(count);

        }

     
    }
}
