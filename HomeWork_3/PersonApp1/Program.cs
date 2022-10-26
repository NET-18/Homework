namespace PersonApp1
{
    public class Person
    {
        public string _name;
        public string _surName;
        public int _age;


    }
    public class Program
    {

        static void Main(string[] args)
        {
            Person a = new Person();
            Console.Write("Введите свою фамилию: ");
            a._surName = Convert.ToString(Console.ReadLine());


            Console.Write("Введите свое имя: ");
            a._name = Convert.ToString(Console.ReadLine());

            Console.Write("Введите свой возраст: ");
            a._age = Convert.ToInt32(Console.ReadLine());

            OutPut(a);


        }
        static void OutPut(Person t)
        {

            Console.Write($"Вы {t._surName} {t._name} и вам {t._age} лет");
        }
    }
}