namespace kozyrev_31._10._2022
{
    class Person
    {
        public string name;
        public string surname;
        public int age;

        public Person () 
        {
            name = "Евгений";
            surname = "Козырев";
            age = 30;
            Print();
        } 
        public void Print()
        {
            Console.WriteLine("Имя " + name);
            Console.WriteLine("Фамилия " + surname);
            Console.WriteLine("Возраст " + age);
        }
    }
    class Student
    {
        public string name;
        public string surname;
        public int age;
        public int numbergroup;
        public string speciality;

        public Student()
        {
            name = "Евгений";
            surname = "Козырев";
            age = 30;
            numbergroup = 1000;
            speciality = "Информационные технологии";
            Print();
        }
        public void Print()
        {
            Console.WriteLine("Имя " + name);
            Console.WriteLine("Фамилия " + surname);
            Console.WriteLine("Возраст " + age);
            Console.WriteLine("Номер группы " + numbergroup);
            Console.WriteLine("Специальность " + speciality);
        }
    }
        class Employee
        {
            public string name;
            public string surname;
            public int age;
            public int wages;
            public string post;

            public Employee ()
            {
                name = "Евгений";
                surname = "Козырев";
                age = 30;
                wages = 10000;
                post = "Инжинер";
                Print();
            }
            public void Print()
            {
                Console.WriteLine("Имя " + name);
                Console.WriteLine("Фамилия " + surname);
                Console.WriteLine("Возраст " + age);
                Console.WriteLine("Номер группы " + wages);
                Console.WriteLine("Специальность " + post);
            }

        }
    internal class Program
    {
        static void Main(string[] args)
        {
            Person firstperson = new Person();
            Console.WriteLine("");
            Student firststudent = new Student();
            Console.WriteLine("");
            Employee firstemployee = new Employee();
            Console.WriteLine("");


        }
        public static void Upwages (double percentage)
        {
            Console.WriteLine();
        }
    }
}