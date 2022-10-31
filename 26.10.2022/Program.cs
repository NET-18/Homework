namespace _26._10._2022
{
    public class Person
    {
        public string _name;
        public string _surname;
        public int _age;
        public Person()
        {
            _name = "name";
            _surname = "surname";
            _age = 31;
            Console.WriteLine("Initialization");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Person a = new Person();
            a._name = "Alex";
            a._surname = "Fisher";
            a._age = 31;
            Console.WriteLine($"This is {a._name} {a._surname}, he is {a._age} years old.");
        }
    }
}