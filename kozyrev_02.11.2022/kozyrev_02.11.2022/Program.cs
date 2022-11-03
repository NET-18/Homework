namespace kozyrev_02._11._2022
{
   
      
        public class Person
        {
            protected string name;
            protected string surname;
            protected int age;

            public string Name { get; set; }
            public string Surname { get; set; }
            public int Age { get; set; }
            public virtual void Print()
            {
                Console.WriteLine(Name);
                Console.WriteLine(Surname);
                Console.WriteLine(Age);
            }

        }
        public class Student : Person
        {
            private int numgroup;
            private string speciality;
            public int Numgroup { get; set; }
            public string Speciality { get; set; }
            public bool Expelled { get; set; } = false;
            public override void Print()
            {
                base.Print();
                Console.WriteLine(Numgroup);
                Console.WriteLine(Speciality);
            }
        }
        public class Employee : Person
        {
            private string post;
            private int wages;
            private int percent;
            private double upwages;
            public string Post { get; set; }
            public int Wages { get; set; }
            public int Percent { get; set; }
            public double UpWages { get; set; }
            public bool Fired { get; set; } = false;
            public override void Print()
            {
                base.Print();
                Console.WriteLine(Post);
                Console.WriteLine(Wages);
            }

        }
        internal class Program
        {
            static void Main(string[] args)
            {
                Person person = new Person();
                person.Name = "Evgeny";
                person.Surname = "Kozyrev";
                person.Age = 30;
                person.Print();
                Console.WriteLine("");

                Student student = new Student();
                student.Name = person.Name;
                student.Surname = person.Surname;
                student.Age = person.Age;
                student.Numgroup = 1234;
                student.Speciality = "Информационные технологии";
                student.Print();
                Console.WriteLine("");


                Employee employee = new Employee();
                employee.Name = person.Name;
                employee.Surname = person.Surname;
                employee.Age = person.Age;
                employee.Post = "Инженер";
                employee.Wages = 1500;
                employee.Percent = 13;
                employee.Print();
                Console.WriteLine("");

                employee.UpWages = employee.Wages + employee.Percent * (employee.Wages / 100);
                Console.WriteLine($"Зароботная плата после поднятия " + employee.UpWages);


            }

            //private static void StatusStudent(Student student)
            //{
            //    student.Expelled = true;

            //}
            //private static void StatusEmployee(Employee employee)
            //{
            //    employee.Fired = true;

            //}

        }
    }
