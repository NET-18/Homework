namespace Homework3
{
    public class Person
    {
        private string name;
        private string surname;
        private string age;
        private string sex;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public string Surname
        {
            get
            {
                return surname;
            }
            set
            {
                surname = value;
            }
        }
        public int Age { get; set; }
        public string Sex
        {
            get
            {
                return sex;
            }
            set
            {
                sex = value;
            }
        }
    }
    public class Employee : Person
    {
        private string job;
        private int salary;
        private int raisePercent;
        private int experience;

        public string Job
        {
            get
            {
                return job;
            }
            set
            {
                job = value;
            }
        }
        public int Experience
        {
            get
            {
                return experience;
            }
            set
            {
                experience = value;
            }
        }
        public int Salary
        {
            get
            {
                return salary;
            }
            set
            {
                salary = value;
            }
        }

        public int RaisePercent
        {
            get
            {
                return raisePercent;
            }
            set
            {
                raisePercent = value;
            }
        }

        public bool Fired { get; set; } = false;
    }

    public class Student : Person
    {
        private string university;
        public string University
        {
            get
            {
                return university;
            }
            set
            {
                university = value;
            }
        }
        public int Course { get; set; }
        public bool Expelled { get; set; } = false;
    }

    internal class Program
    {
        public static int salaryRaise;

        static void Main(string[] args)
        {
            Person person = new Person();
            person.Name = "Lyubov";
            person.Age = 27;
            person.Surname = "Knyazeva";
            person.Sex = "female";
            PrintPersonInfo(person);

            Employee employee = new Employee();
            employee.Name = "Alex";
            employee.Surname = "King";
            employee.Age = 23;
            employee.Sex = "female";
            employee.Job = "BDM";
            employee.Experience = 5;
            employee.Salary = 2000;

            Console.WriteLine("Salary increase percentage:");
            employee.RaisePercent = Convert.ToInt32(Console.ReadLine());
            salaryRaise = employee.Salary + employee.RaisePercent * (employee.Salary / 100);
            PrintEmployeeInfo(employee);
            Console.WriteLine($"{salaryRaise}$");
            StatusEmployee(employee);

            Student student = new Student();
            student.Name = "John";
            student.Surname = "Green";
            student.Age = 21;
            student.Sex = "male";
            student.University = "BSU";
            student.Course = 3;
            PrintStudentInfo(student);
            StatusStudent(student);


        }
        private static void PrintPersonInfo(Person person)
        {
            Console.WriteLine($"Person Info: {person.Name} {person.Surname}, {person.Age} years old, {person.Sex}");
        }

        private static void PrintEmployeeInfo(Employee employee)
        {
            Console.WriteLine($"Employee Info: {employee.Name} {employee.Surname}, {employee.Age} years old, {employee.Sex},  ");
            if (employee.Fired)
            {
                Console.WriteLine("Employee is fired.");
                return;
            }
        }


        private static void PrintStudentInfo(Student student)
        {
            Console.WriteLine($"Student Info: {student.Name} {student.Surname}, {student.Age} years old, {student.Sex}, is studying at {student.University}, {student.Course} course");
            if (student.Expelled)
            {
                Console.WriteLine("Student is expelled.");
                return;
            }
        }

        private static void StatusEmployee(Employee employee)
        {
            employee.Fired = true;
        }

        private static void StatusStudent(Student student)
        {
            student.Expelled = true;
        }
    }
}