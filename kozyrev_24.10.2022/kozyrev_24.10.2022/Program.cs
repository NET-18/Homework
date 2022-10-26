namespace ConsoleApp3
{
    internal class Program
    {
        class Person
        {
            public string name;
            public string Surname;
            public int age;
        }
        static void Print(string result)
        {
            Console.WriteLine(result);
        }
        static void Main(string[] args)
        {
            Person josh = new Person();
            josh.name = "Josh";
            josh.Surname = "Boleslava";
            josh.age = 15;
            Console.WriteLine($"{josh.Surname} {josh.name} is {josh.age} years old");
        }
    }
}