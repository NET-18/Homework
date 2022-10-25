# Homework
using System;



namespace ConsoleApp1
{
    public class Person
    {   
        // Поля класса
        public string? name;
        public string? surname;
        public int age;

    }
    internal class Program
    {
        static void Main(string[]args)
        {
            Person person = new Person();          
            person.name = "Boleslava";
            person.surname = "Joash";
            person.age = 15;
            Console.WriteLine(person.name);
            Console.WriteLine(person.surname);
            Console.WriteLine(person.age);
        }
    }
}
