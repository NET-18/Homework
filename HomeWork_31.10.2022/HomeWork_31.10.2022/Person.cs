namespace HomeWork_31_10_2022;

public class Person: ICloneable
{
    private short _age;
    private short _height;
    private float _weight;
    private string? _gender;
    
    public string? Name { get; set; }
    public string? Surname { get; set; }
    
    public short Age
    {
        get => this._age;
        set
        {
            if (value < 0 || value > 120)
            {
                throw new ArgumentException("Age cannot be less than zero and more than 120", nameof(_age));
            }

            this._age = value;
        }
    }
    public short Height
    {
        get => this._height;
        set
        {
            if (value < 0 || value > 260)
            {
                throw new ArgumentException("Height cannot be less than zero and more than 260 cm", nameof(_height));
            }

            this._height = value;
        }
    }
    public float Weight
    {
        get => this._weight;
        set
        {
            if (value < 0 || value > 320)
            {
                throw new ArgumentException("Weight cannot be less than zero and more than 320 kg", nameof(_weight));
            }

            this._weight = value;
        }
    }

    public string? Gender
    {
        get => this._gender;
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(nameof(this._gender), "It's cannot be null or empty.");
            }
            
            if (!string.Equals(value?.ToLowerInvariant(), "male", StringComparison.OrdinalIgnoreCase) && !string.Equals(value?.ToLowerInvariant(), "female", StringComparison.OrdinalIgnoreCase))
            {
                throw new ArgumentException("It's not a gender stupid bitch!", nameof(this._gender));
            }

            this._gender = value;
        }
    }
    public Person() { }

    public Person(string? name, string? surname, short age, short height, float weight, string? gender)
    {
        this.Name = name;
        this.Surname = surname;
        this.Age = age;
        this.Height = height;
        this.Weight = weight;
        this.Gender = gender;
    }

    public void Eat()
    {
        this.Weight += 0.7f;
    }

    public void Poop()
    {
        this.Weight -= 0.5f;
    }

    public object Clone()
    {
        return new Person(Name, Surname, Age, Height, Weight, Gender);
    }
}