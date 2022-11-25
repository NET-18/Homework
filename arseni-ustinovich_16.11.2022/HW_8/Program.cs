namespace HW_8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var mySchool = new School();
            var myUniversity = new University();

            mySchool.Create();
            myUniversity.Create();

            Console.Clear();

            mySchool.Info();
            myUniversity.Info();
        }
    }
}