namespace HomeWork2
{
  
    internal class Program
    {
         static void Main(string[] args)
         {
              Person person = new Person();
              person.Name = "Boleslava";
              person.surname = "Joash";
              person.age = 15;
              Console.WriteLine(person.Name);
              Console.WriteLine(person.surname);
              Console.WriteLine(person.age);
         }
       
    }
       
}