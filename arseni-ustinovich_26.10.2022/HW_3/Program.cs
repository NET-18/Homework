using System.Xml.Linq;

namespace HW_3
{
    public class Person
    {
        public int _age;
        public string _name;
        public string _surname;

        public Person(int age, string name, string surname)
        {
            _age = age;
            _name = name;
            _surname = surname;
        }

        public Person()
        {
            _age = 15;
            _name = "Boleslava";
            _surname = "Joash";
        }
    }
    
    internal class Program
    {
        
        static void MyOutput(Person myPerson)
        {
            Console.WriteLine("{0} {1} is {2} years old", myPerson._surname, myPerson._name, myPerson._age);
        }

        static void Main(string[] args)
        {
            Person master = new Person(99, "Vasiliy", "Pupkin");
            MyOutput(master);

            master = new Person();
            MyOutput(master);
        }
    }
}