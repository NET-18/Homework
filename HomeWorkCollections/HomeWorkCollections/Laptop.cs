namespace HomeWorkCollections;

public class Laptop : IComparable
{
    private decimal _cost;
    private int _ram;
    private float _weight;
    private float _diagonal;

    public string Product { get; set; }
    public string Color { get; set; }
    public string OS { get; set; }
    public string Processor { get; set; }
    public string ScreenTechnology { get; set; }
    public bool KeyboardBacklight { get; set; }
    public int SSD { get; }
    public int HDD { get; }
    public DriveType DriveType { get; }

    public decimal Cost
    {
        get => _cost;
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Cost cannot be less than zero.", nameof(Cost));
            }

            this._cost = value;
        }
    }
    
    public int RAM
    {
        get => _ram;
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Ram cannot be less than zero.", nameof(RAM));
            }

            this._ram = value;
        }
    }

    public float Weight
    {
        get => _weight;
        set
        {
            if (value < 0f || value > 5f)
            {
                throw new ArgumentException("Weight cannot be less than zero or more than 5 kg.", nameof(Weight));
            }

            this._weight = value;
        }
    }
    
    public float Diagonal
    {
        get => _diagonal;
        set
        {
            if (value < 9f || value > 22f)
            {
                throw new ArgumentException("Diagonal cannot be less than 9 or more than 22 inch.", nameof(Diagonal));
            }

            this._diagonal = value;
        }
    }

    public Laptop(int cost, string processor, DriveType driveType, Tuple<int, int> capacityOfStorage, int ram, float weight, string os,
        bool keyboardBacklight, float diagonal,
        string screenTechnology, string product, string color)
    {
        Cost = cost;
        Processor = processor;
        DriveType = driveType;
        SSD = capacityOfStorage.Item1;
        HDD = capacityOfStorage.Item2;
        RAM = ram;
        Weight = weight;
        OS = os;
        KeyboardBacklight = keyboardBacklight;
        Diagonal = diagonal;
        ScreenTechnology = screenTechnology;
        Product = product;
        Color = color;
    }
    
    public int CompareTo(object? obj)
    {
        if (obj is null)
        {
            throw new ArgumentNullException(nameof(obj), "Object is null.");
        }
        if (obj is not Laptop laptop)
        {
            throw new ArgumentException("It's not a laptop", nameof(obj));
        }
    
        return (int)(this._cost - laptop.Cost);
    }

    public override string ToString()
    {
        return $"Product: {Product}" +
               $"\nCost: {Cost}$" +
               $"\nProcessor: {Processor}" +
               $"\nOS: {OS}" +
               $"\nSSD: {((DriveType & DriveType.SSD) == DriveType.SSD ? SSD : 0)} gb" +
               $"\nHDD: {((DriveType & DriveType.HDD) == DriveType.HDD ? HDD : 0)} gb" +
               $"\nRAM: {RAM} gb" +
               $"\nWeight: {Weight} kg" +
               $"\nDiagonal: {Diagonal} inch" +
               $"\nScreen Technology: {ScreenTechnology}" +
               $"\nColor: {Color}" +
               $"\nKeyboard backlight: {KeyboardBacklight}";
    }
}