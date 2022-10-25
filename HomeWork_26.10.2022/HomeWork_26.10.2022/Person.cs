namespace HM_26_10_2022;

public class Person
{
    public int age;
    public string name;
    public string surname;

    public Person()
    {
        this.age = 20;
        this.name = "Sergey";
        this.surname = "Yushkevich";
    }
    public Person(int age, string name, string surname)
    {
        this.age = age;
        this.name = name;
        this.surname = surname;
    }
}