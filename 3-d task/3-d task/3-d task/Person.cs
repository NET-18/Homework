
namespace _3_d_task
{
    internal class Person
    {
        private string _name;
        private string _surname;
        private int _age;

        public string Name { get { return _name; } set { _name = value; } }
        public string Surname { get { return _surname; } set { _surname = value; } }
        public int Age { get { return _age; } set { _age = value; } }

        public virtual void Print()
        {
            Console.WriteLine($" Person; Name:{Name} Surname:{Surname} Age:{Age}");
        }

        public Person(string name, string surname, int age)
        {
            Name = name;
            Surname = surname;
            Age = age;
        }
    }
}
