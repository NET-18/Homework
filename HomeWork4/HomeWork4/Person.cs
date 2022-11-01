using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork4
{
    internal class Person
    {
        //KОНСТРУКТОРЫ
        public Person(string name, int age, string surName) //Параметры или аргументы конструктора в данном случае
        {
            Name = name;
            Age = age;
            SurName = surName;
        }
        public virtual void print()
        {
            Console.WriteLine(Name);
        }

        //СВОЙСТВА
        public string Name { get; set; }
        public int Age { get; set; }
        public string SurName { get; set; }

    }
}
