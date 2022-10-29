namespace PersonApp1
{
    public class Person
    {
        public string _name;
        public string _surname;
        public int _age;


        public Person()
        {
            _name = "Александр";
            _surname = "Бобко";
            _age = 14;
        }
        public Person(string name, string surname, int age)
        {
            this._name = name;
            this._surname = surname;
            this._age = age;
        }


    }
    public class Program
    {

        static void Main(string[] args)
        {
            Person a = new Person( "Александр", "Бобко", 24);
            OutPut(a);

        }
        static void OutPut(Person t)
        {

            Console.Write($"Вы {t._surname} {t._name} и вам {t._age} лет");
        }
    }
}