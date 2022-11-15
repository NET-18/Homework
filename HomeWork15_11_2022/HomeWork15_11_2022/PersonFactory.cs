using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork15_11_2022
{
    internal class PersonFactory
    {
        public static void Procces<T>(T person) where T : Person
        {
            person.DoStuff();
        }

        public static T Clone<T>(T person) where T : Person, new()
        {
            var result = new T()
            {
                MaxSpeed = person.MaxSpeed,
                MinSpeed = person.MinSpeed,
            };
            return result;
        }
    }
}
