namespace TMS_Sixth_App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var animal = new HelperFactory();
            Cat cat = new Cat();
            Dog dog = new Dog();
            animal.Create(cat);
            animal.Create(dog);
        }
    }
}