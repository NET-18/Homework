using ORM;
using System;

namespace ConsoleApp4
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var manager = new DatabaseManager();
            var people = await manager.GetAllAsync<Person>();

            foreach (var person in people)
            {
                Console.WriteLine($"{person.Id} \t {person.Name} {person.SurName}" );
            }
            var countries = await manager.GetAllAsync<Country>();
            foreach (var country in countries)
            {
                Console.WriteLine($"{country.Id} \t {country.Name} ");
            }
        }
    }
}