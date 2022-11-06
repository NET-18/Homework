namespace Homework3
{
    public class Person
    {

        public string? Name { get; set; }
        public string? Surname { get; set; }
        public int Age { get; set; }
        public string? Sex { get; set; }
    }
    public class Employee : Person
    {
        private int salary;
        private int raisePercent;
        private int experience;

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

    public class Student : Person
    {
        public string? University { get; set; }
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
            student.Name = "John";
            student.Surname = "Green";
            student.Age = 21;
            student.Sex = "male";
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
            Console.WriteLine($"Employee Info: {employee.Name} {employee.Surname}, {employee.Age} years old, {employee.Sex}, Employee is a {employee.Job} at {employee.Company}, monthly salary: {employee.Salary}$, working experience: {employee.Experience} years");
            if (employee.Fired)
            {
                Console.WriteLine("Employee is fired.");
                return;
            }
        }

        private static void PrintStudentInfo(Student student)
        {
            StatusStudent(student);
            Console.WriteLine($"Student Info: {student.Name} {student.Surname}, {student.Age} years old, {student.Sex}, Student is studying at {student.University}, {student.Course} course");
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
