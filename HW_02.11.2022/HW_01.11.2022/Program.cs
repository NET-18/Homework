namespace HW_01._11._2022
{
    class Person
    {
        public string _name { get; set; }
        public string _surname { get; set; }
        public int _age { get; set; }
        public void PersonInfo()
        {
            Console.WriteLine();
            Console.WriteLine($"{_name} {_surname} is {_age} years old");
        }
        public virtual void PrintVirtual()
        {
            Console.WriteLine();
            Console.WriteLine($"{_name} is good {_name}");
        }
    }
    class Student:Person
    {
        public string _university { get; set; }
        public string _department { get; set; }
        public int _course { get; set; }
        public void StudentInfo()
        {
            Console.WriteLine($"He is study at {_university} in {_department} on {_course}");
        }
        public override void PrintVirtual()
        {
            base.PrintVirtual();
        }

    }
    class Employee:Person
    {
        public string _job { get; set; }
        public int _salary { get; set; }
        public int _exp { get; set; }
        public void EmployeeInfo()
        {
            Console.WriteLine($"Make his {_job} very well and got a salary {_salary}");
        }
        public override void PrintVirtual()
        {
            base.PrintVirtual();
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person { _age = 20, _name = "Josh", _surname = "KZ" };
            person.PersonInfo();

            Student student = new Student { _name = "Tom", _surname = "pip", _age = 18, _course = 4, _department = "OPTIK", _university = "BNTU" };
            student.PersonInfo();
            student.StudentInfo();

            Employee employee = new Employee { _name = "Dima", _surname = "Mur", _age = 33, _exp = 8, _job = "Kon`", _salary = 1000 };
            employee.PersonInfo();
            employee.EmployeeInfo();

            Person[] arr = new Person[] { person, student, employee };
            foreach(Person i in arr)
            {
                i.PrintVirtual();
            }

        }
    }
}