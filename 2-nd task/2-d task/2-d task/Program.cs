using System;


public struct Aboba
{
    public double x;
    public double y;
    public double z;

    public Aboba(double x, double y, double z) 
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }
}


public class Program 
{   
    public static void PrintPersonInfo(Person person)
    {
        Console.WriteLine($"{person.name} is {person.age} years old");
    }

    public static double GetDistance(Aboba aboba, Aboba aboba1) 
    {
        double distance = 0;

        distance = Math.Sqrt
        ((Math.Pow(aboba.x - aboba1.x, 2)) +
        (Math.Pow(aboba.y - aboba1.y, 2)) + 
        (Math.Pow(aboba.z - aboba1.z, 2)));
        
        return distance;
    }

    public static int Main()
    {
        Person person = new Person("Serhio", 15);
        PrintPersonInfo(person);
        Aboba aboba = new Aboba(2, 8, 9);
        Aboba aboba1 = new Aboba(4, 20, 6);
        Console.WriteLine($"Distance is {GetDistance(aboba,aboba1)}");       

        return 0;
    }
    
}
public class Person 
{
    public string name;
    public int age;

    public Person() { name = "Aboba"; age = 25;}

    public Person(string name, int age)
    {
        this.name = name;
        this.age = age;
    }
}
