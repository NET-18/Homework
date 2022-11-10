namespace Homework3
{
    public class Person
    {

        public string? Name { get; set; }
        public string? Surname { get; set; }
        public int Age { get; set; }
        public string? Sex { get; set; }
    }
    public class Employee
    {
        private int salary;
        private int raisePercent;
        private int experience;

        public Person _person { get; set; }
        public string? Job { get; set; }
        public string? Company { get; set; }
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

    public class Student
    {
        public string? University { get; set; }
        public int Course { get; set; }
        public bool Expelled { get; set; } = false;
        public Person _person { get; set; }
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
            employee._person = person;
            employee._person.Name = "Alex";
            employee._person.Surname = "King";
            employee._person.Age = 23;
            employee._person.Sex = "female";
            employee.Job = "BDM";
            employee.Company = "Onde";
            employee.Experience = 5;
            employee.Salary = 2000;

            Console.WriteLine("Salary increase percentage:");
            employee.RaisePercent = Convert.ToInt32(Console.ReadLine());
            salaryRaise = employee.Salary + employee.RaisePercent * (employee.Salary / 100);
            PrintEmployeeInfo(employee);
            Console.WriteLine("Future salary: ");
            Console.WriteLine($"{salaryRaise}$");


            Student student = new Student();
            student._person = person;
            student._person.Name = "John";
            student._person.Surname = "Green";
            student._person.Age = 21;
            student._person.Sex = "male";
            student.University = "BSU";
            student.Course = 3;
            PrintStudentInfo(student);
        }
        private static void PrintPersonInfo(Person person)
        {
            Console.WriteLine($"Person Info: {person.Name} {person.Surname}, {person.Age} years old, {person.Sex}");
        }

        private static void PrintEmployeeInfo(Employee employee)
        {
            StatusEmployee(employee);
            Console.WriteLine($"Employee Info: {employee._person.Name} {employee._person.Surname}, {employee._person.Age} years old, {employee._person.Sex}, Employee is a {employee.Job} at {employee.Company}, monthly salary: {employee.Salary}$, working experience: {employee.Experience} years");
            if (employee.Fired)
            {
                Console.WriteLine("Employee is fired.");
                return;
            }
        }


        private static void PrintStudentInfo(Student student)
        {
            StatusStudent(student);
            Console.WriteLine($"Student Info: {student._person.Name} {student._person.Surname}, {student._person.Age} years old, {student._person.Sex}, Student is studying at {student.University}, {student.Course} course");
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
