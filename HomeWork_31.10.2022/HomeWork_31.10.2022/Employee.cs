namespace HomeWork_31_10_2022;

using System.Runtime.CompilerServices;

public class Employee : Person
{
   
    private decimal _monthlySalary;
    private short _experience;
    
    public string? PlaceOfWork { get; set; } 
    public string? Position { get; set; }
    public bool Expellede { get; set; } = false;

    public decimal MonthlySalary
    {
        get => this._monthlySalary;
        set
        {
            if (value < 150.0m)
            {
                throw new ArgumentException(
                    "It's very small salary(cannot be less than 150$). It's not normal. Change place of work or your manager!!",
                    nameof(MonthlySalary));
            }

            this._monthlySalary = value;
        }
    }

    public short Experience
    {
        get => this._experience;
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Experience cannot be negative number.", nameof(Experience));
            }

            if (this.Age - value < 14)
            {
                throw new ArgumentException("You are slave. Sorry", nameof(Experience));
            }

            this._experience = value;
        }
    }
    
    public Employee(Person person, string? placeOfWork, string? position, short experience, decimal monthlySalary) : base(person)
    {
        if (person.Age < 14)
        {
            throw new ArgumentException("You are slave. Sorry", nameof(person.Age));
        }

        this.PlaceOfWork = placeOfWork;
        this.Position = position;
        this.Experience = experience;
        this.MonthlySalary = monthlySalary;
    }
    
    public override void PrintType()
    {
        Console.WriteLine("I am employee.");
    }
}