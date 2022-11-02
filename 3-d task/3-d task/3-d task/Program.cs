
namespace _3_d_task

{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person[] people = Array.Empty<Person>();
            while (true) 
            {
                switch (ShowMenu())
                {
                    case 1:
                        Array.Resize(ref people, people.Length + 1);
                        people[people.Length - 1] = AddStudents();
                        break;    
                    case 2:
                        Array.Resize(ref people, people.Length + 1);
                        people[people.Length - 1] = AddEmployers();
                        break;
                    case 3:
                        ShowArray(people);
                        break;
                    case 4:
                        people = DeletePerson(people);
                        break;
                    case 5:
                        people = RaiseSalary(people);
                        break;
                    case 6:
                        return;
                    default:
                        return;
                }
                
            }
            
        }

         static int ShowMenu()
        {
            Console.WriteLine("\n1.Add Student\n2.Add Employee\n3.Show All\n4.Delete Person\n5.Add Salary\n6.Exit");
            int choice;
            return choice = Convert.ToInt32(Console.ReadLine());
        }

        static void ShowArray(Person[] people)
        {
            int i = 1;
            foreach (Person person in people)
            {
                Console.WriteLine(i);
                person.Print();
                i++;
            }
        }

        static Person[] DeletePerson(Person[] people) 
        {
            ShowArray(people);
            Console.WriteLine("\nWhich person you want to delete? ");
            int choice = Convert.ToInt32(Console.ReadLine());
            if (choice == people.Length) { Array.Resize(ref people, people.Length - 1); }
            else
            {
                for (int i = choice - 1; i < (people.Length - 1); i++)
                {
                    people[i] = people[i + 1];
                }
                Array.Resize(ref people, people.Length - 1);
            }
            return people;
        }

        static Person AddEmployers() 
        {
            Console.WriteLine("\nEnter salary... ");
            double salary = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("\nEnter exp... ");
            double experience = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("\nEnter name... ");
            string name = Console.ReadLine();

            Console.WriteLine("\nEnter age... ");
            int age = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\nEnter surname... ");
            string surname = Console.ReadLine();

            Person employer = new Employee(salary, experience, name, surname, age);
            return employer;       
        }

        static Person AddStudents()
        {
            Console.WriteLine("\nEnter course... ");
            int course = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\nEnter department... ");
            string department = Console.ReadLine();

            Console.WriteLine("\nEnter name... ");
            string name = Console.ReadLine();

            Console.WriteLine("\nEnter age... ");
            int age = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\nEnter surname... ");
            string surname = Console.ReadLine();

            Person student = new Student(course, department, name, surname, age);
            return student;
        }

        public static Person[] RaiseSalary(Person[] people) 
        {
            foreach (Person person in people) 
            {
                //как дать компилятору понять, какой объект Person в массиве имеет ссылку в хипе именно на Employee а не на Student?
            }
            return people;
        }
    }
}