
namespace _3_d_task
{
    internal class Student : Person
    {
        private int _course;
        private string _department;

        public int Course { get { return _course; } set { _course = value; } }
        public string Department { get { return _department; } set { _department = value; } }

        public Student(string name = "Unkonwn", string surname = "Unknown", int age = 0) : base(name, surname, age) { }

        public Student(int course, string department, string name, string surname, int age) : base(name, surname, age)
        {
            Course = course;
            Department = department;
        }

        public override void Print()
        {
            Console.WriteLine($" Student; Name:{Name} Surname:{Surname} Age:{Age}" +
               $" Course:{Course} Department:{Department}\n");
        }
    }
}
