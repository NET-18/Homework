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
            this._age = age;
            this._name = name;
            this._surname = surname;
        }

        public Person()
        {
            this._age = 15;
            this._name = "Boleslava";
            this._surname = "Joash";
        }
    }
    
    internal class Program
    {
        
        static void MyOutput(Person A)
        {
            Console.WriteLine("{0} {1} is {2} years old", A._surname, A._name, A._age);
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