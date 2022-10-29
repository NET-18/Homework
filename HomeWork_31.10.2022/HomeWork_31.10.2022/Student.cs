namespace HomeWork_31_10_2022;

public class Student
{
    private short _course;
    private short _group;
    private Person _person;

    public string? University { get; set; }
    public string? Faculty { get; set; }
    public string? Department { get; set; }
    public int Energy { get; private set; } = 100;
    public bool Expellede { get; set; } = false;
    
    public short Course
    {
        get => this._course;
        set
        {
            if (value < 1 || value > 6)
            {
                throw new ArgumentException("Course cannot be less than zero or more than 6.", nameof(_course));
            }

            this._course = value;
        }
    }

    public short Group
    {
        get => this._group;
        set
        {
            if (value < 0 || value > 25)
            {
                throw new ArgumentException("Course cannot be less than zero or more than 25.", nameof(this._group));
            }

            this._group = value;
        }
    }

    public Person Person
    {
        get => this._person;
        set
        {
            if (value.Age < 8)
            {
                throw new ArgumentException("You are alien. I am scared.", nameof(_person.Age));
            }

            this._person = (Person)value.Clone();
        }
    }
    public Student(Person person, string? university, string faculty, short course, string department, short group)
    {
        if (person.Age < 8)
        {
            throw new ArgumentException("You are alien. I am scared.", nameof(person.Age));
        }
        
        this._person = (Person)person.Clone();
        this.Course = course;
        this.University = university;
        this.Faculty = faculty;
        this.Department = department;
        this.Group = group;
    }

    public void GoToLesson()
    {
        this.Energy -= 10;
    }

    public void MakeHomeWorkForOneSubject()
    {
        this.Energy -= 5;
    }
    
    public void RestOneDay()
    {
        this.Energy += 15;
    }
}