using System;
using System.Xml.Linq;

namespace ConsoleApp10
{
    internal class Program
    {
        public class Person
        {
            public string _name;
            public string _surname;
            public int _age;
        }
        public class Student
        {
            public Person person;
            public string _university;
            public string _department;
            public int _course;
        }
        public class Employee
        {
            public Person person1;
            public string _job;
            public string _salary;
            public string _exp;
        }
        static void Main(string[] args)
        {
            Person p = new Person()
            {
                _name = "name",
                _surname = "surname",
                _age = 18,
            };
            Student s = new Student()
            {
                person = p,
                _university = "university",
                _department = "department",
                _course = 4,
            };
            Employee e = new Employee()
            {
                person1 = p,
                _job = "job",
                _salary="salary",
                _exp="exp",
            };
            Console.WriteLine($"{p._name} {p._surname} is {p._age} years old.");
            Console.WriteLine($"{p._name} {p._surname} is study at {s._university} on {s._department} in {s._course}.");
            Console.WriteLine($"{p._name} {p._surname} have a {e._job} with big {e._exp} and good {e._salary}.");
        }
    }
}