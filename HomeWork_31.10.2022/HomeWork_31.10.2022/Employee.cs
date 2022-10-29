namespace HomeWork_31_10_2022;

using System.Runtime.CompilerServices;

public class Employee
{
   
    private decimal _monthlySalary;
    private short _experience;
    private Person _person;
    
    public string? PlaceOfWork { get; set; } 
    public string? Position { get; set; }
    public bool Expellede { get; set; } = false;

    public decimal MonthlySalary
    {
        get => this._monthlySalary;
        set
        {
            switch (value)
            {
                case <= 0.0m:
                    throw new ArgumentException("Salary cannot be not a positive!", nameof(this._monthlySalary));
                case < 150.0m:
                    throw new ArgumentException(
                        "It's very small salary(cannot be less than 150$). It's not normal. Change place of work or your manager!!",
                        nameof(this._monthlySalary));
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
                throw new ArgumentException("Experience cannot be negative number.", nameof(this._experience));
            }

            if (this._person.Age - value < 14)
            {
                throw new ArgumentException("You are slave. Sorry", nameof(this._experience));
            }

            this._experience = value;
        }
    }

    public Person Person
    {
        get => this._person;
        set
        {
            if (value.Age < 14)
            {
                throw new ArgumentException("You are slave. Sorry", nameof(_person.Age));
            }

            this._person = (Person)value.Clone();
        }
    }
    public Employee(Person person, string? placeOfWork, string? position, short experience, decimal monthlySalary)
    {
        if (person.Age < 14)
        {
            throw new ArgumentException("You are slave. Sorry", nameof(person.Age));
        }

        this._person = (Person)person.Clone();
        this.PlaceOfWork = placeOfWork;
        this.Position = position;
        this.Experience = experience;
        this.MonthlySalary = monthlySalary;
    }
}