namespace ConsoleApp6
{
    internal class Program
    {
        public class Person
        {
            public string _name;
            public string _surname;
            public int _age;
            public Person()
            {
                _name = "pip";
                _surname = "Mur";
                _age = 14;
            }
            public Person(string name, string surname, int age)
            {
                _name = name;
                _surname = surname;
                _age = age;
            }
        }
        static void Main(string[] args)
        {
            Person josh = new Person("Josh", "Baleslava", 15);    
            Print(josh);
        }
        static void Print(Person person)
        {
            Console.WriteLine($"{person._surname} {person._name} is {person._age} years old");
        }
    }
}