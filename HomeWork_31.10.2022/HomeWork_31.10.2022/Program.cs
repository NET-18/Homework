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
            SalaryIncrease(meAsEmployee, 10);
            PrintInfoAboutEmployee(meAsEmployee);
            Console.WriteLine();
            DismissStudent(alsoMe);
            PrintInfoAboutStudent(alsoMe);
            Console.WriteLine();
            DismissEmployee(meAsEmployee);
            PrintInfoAboutEmployee(meAsEmployee);
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

        private static void PrintInfoAboutStudent(Student student)
        {
            Console.WriteLine("Print info about student");
            PrintInfoAboutPerson(student.person);
            if (student.Expellede)
            {
                Console.WriteLine("He/she is expelled.");
                return;
            }

            Console.WriteLine($"University: {student.University}");
            Console.WriteLine($"Faculty: {student.Faculty}");
            Console.WriteLine($"Course: {student.Course}");
            Console.WriteLine($"Group: {student.Group}");
            Console.WriteLine($"Department: {student.Department}");
            Console.WriteLine($"Energy: {student.Energy}%");
        }

        private static void PrintInfoAboutEmployee(Employee employee)
        {
            Console.WriteLine("Print info about employee");
            PrintInfoAboutPerson(employee.person);
            if (employee.Expellede)
            {
                Console.WriteLine("He/she is expelled.");
                return;
            }

            Console.WriteLine($"Place of work: {employee.PlaceOfWork}");
            Console.WriteLine($"Position: {employee.Position}");
            Console.WriteLine($"Monthly salary: {employee.MonthlySalary}$");
            Console.WriteLine($"Experience: {employee.Experience} years");
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

