using ConsoleApp1;
using System;

namespace ConsoleApp1
{

    public class Person
    {
        private string _name;
        private string _surname;
        public int _intage;
        private string _gender;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Surname
        {
            get { return _surname; }
            set { _surname = value; }
        }

        public string Gender
        {
            get { return _gender; }
            set { _gender = value; }
        }

        public string Age
        {
            get
            {
                if (_intage < 0)
                {
                    return "Недопустимое значение";
                }
                else
                {
                    return _intage.ToString();
                }
            }

        }
        public void PersonOutput()
        {
            Console.Write($"{Surname} {Name} {Gender}, ему {Age} лет.\n");
        }
        public virtual void Virtual()
        {

            Console.WriteLine($"\nШёл как то паренёк по имени {Name} и умер в свои {_intage}.(((((");
        }
    }

    public class Student : Person
    {

        private string _university;
        public int _course;
        private string _faculty;
        public string University
        {
            get { return _university; }
            set { _university = value; }
        }
        public string Faculty
        {
            get { return _faculty; }
            set { _faculty = value; }
        }
        public string Course
        {
            get
            {
                if (_course <= 0 || _course >= 7)
                {
                    return "ОШИБКА!";
                }
                else
                {
                    return _course.ToString();
                }
            }
        }
        public void StudentOutput()
        {
            Console.WriteLine($"Студент {Surname} {Name}, тот ещё {Gender}, в свои {_intage} года, учится в {University} на факультете {Faculty} на {_course} курсе.\n");
        }
        public override void Virtual()
        {
            Name = "Санёк";
            base.Virtual();
        }
    }

    public class Employee : Person
    {
        private string _job;
        private double _salarymonth;
        private double _experience;

        public string Job
        {
            get { return _job; }
            set { _job = value; }
        }
        public double Salarymonth
        {
            get { return _salarymonth; }
            set { _salarymonth = value; }
        }
        public double Experience
        {
            get { return _experience; }
            set { _experience = value; }
        }
        public void EmployeeOutput()
        {
            Console.WriteLine($"Работник получает зарплату {Salarymonth}$, хоть и имеет лишь {Experience} года опыта работы. Он получает эти бабки за работы {Job}, а ты получаешь так на заводе?\n");
        }
        public override void Virtual()
        {
            base.Virtual();
        }

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person { Name = "Sasha", Surname = "Bobko", Gender = "Supermen", _intage = 24 };
            person.PersonOutput();

            Student student = new Student { Name = "Sanya", Surname = "Babik", Gender = "Supermen", _intage = 24, _course = 3, Faculty = "PSF", University = "BNTU" };
            student.PersonOutput();
            student.StudentOutput();

            Employee employee = new Employee { Name = "Sanya", Surname = "Babik", Gender = "Supermen", _intage = 24, Job = "двроником в IT", Salarymonth = 650, Experience = 3 };
            employee.PersonOutput();
            employee.EmployeeOutput();

            Person[] arr = new Person[] { person, student, employee };
            foreach (Person p in arr)
            {
                p.Virtual();
            }
        }
    }
}