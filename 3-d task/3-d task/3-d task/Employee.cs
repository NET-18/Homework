using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_d_task
{
    internal class Employee : Person
    {
        private double _salary;
        private double _experience;

        public double Salary { get { return _salary; } set { _salary = value; } }
        public double Experience { get { return _experience; } set { _experience = value; } }

        public override void Print()
        {
            Console.WriteLine($" Employee; Name:{Name} Surname:{Surname} Ahe:{Age}" +
               $" Salary:{Salary} Experience:{Experience}\n");
        }

        public Employee(string name = "Unknown", string surname = "Unknown", int age = 0) : base(name, surname, age) { }

        public Employee(double salary, double experience, string name, string surname, int age) : base(name, surname, age)
        {
            Salary = salary;
            Experience = experience;
        }
    }
}
