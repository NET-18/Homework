namespace HomeWork_31_10_2022
{
    class Program
    {
        public static void Main(string[] args)
        {
            Person me = new Person("Sergey", "Yushkevich", 20, 176, 58.5f, "male");
            PrintInfoAboutPerson(me);
            Console.WriteLine();
            Student alsoMe = new Student(me, "BSU", "MMF", 4, "Algebra", 1);
            PrintInfoAboutStudent(alsoMe);
            Console.WriteLine();
            Employee meAsEmployee = new Employee(me, "Amazing company", "Middle .NET Developer", 3, 1200);
            PrintInfoAboutEmployee(meAsEmployee);
            Console.WriteLine();
            me.PrintType();
            Console.WriteLine();
            alsoMe.PrintType();
            Console.WriteLine();
            meAsEmployee.PrintType();
            Console.WriteLine();
        }
        
        private static void PrintInfoAboutPerson(Person person)
        {
            Console.WriteLine($"Name: {person.Name}");
            Console.WriteLine($"Surname: {person.Surname}");
            Console.WriteLine($"Age: {person.Age} years old");
            Console.WriteLine($"Height: {person.Height} cm");
            Console.WriteLine($"Weight: {person.Weight} kg");
            Console.WriteLine($"Gender: {person.Gender}");
        }

        private static void PrintInfoAboutStudent(Person person)
        {
            Console.WriteLine("Print info about student");
            PrintInfoAboutPerson(person);
        }

        private static void PrintInfoAboutEmployee(Person person)
        {
            Console.WriteLine("Print info about employee");
            PrintInfoAboutPerson(person);
        }

        private static void SalaryIncrease(Employee employee, short percent)
        {
            employee.MonthlySalary += (employee.MonthlySalary / 100) * percent;
        }

        private static void DismissEmployee(Employee employee)
        {
            employee.Expellede = true;
        }

        private static void DismissStudent(Student student)
        {
            student.Expellede = true;
        }
    }
}

