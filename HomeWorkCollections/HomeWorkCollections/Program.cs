using System.Threading.Channels;
using HomeWorkCollections;

class Program
{
    public static void Main(string[] args)
    {
        MyList<int> myListOne = new MyList<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9};
        MyList<double> myListTwo = new MyList<double>(new[] { 1.1, 2.2, 3.3, 4.4, 5.5, 6.6, 7.7, 8.8, 9.9 });
        MyList<bool> myListThree = new MyList<bool>(6);
        
        Console.WriteLine("Count of elements in myListOne: {0}\nCapacity in myListOne: {1}", myListOne.Count, myListOne.Capacity);
        Console.WriteLine();
        
        Console.WriteLine("Count of elements in myListTwo: {0}\nCapacity in myListTwo: {1}", myListTwo.Count, myListTwo.Capacity);
        Console.WriteLine();
        
        Console.WriteLine("Count of elements in myListThree: {0}\nCapacity in myListThree: {1}", myListThree.Count, myListThree.Capacity);
        Console.WriteLine();

        foreach (var item in myListOne)
        {
            Console.Write(item + " ");
        }

        Console.WriteLine("\nMethod Remove for myListOne. If removed - print new list, else print message that there is no such element.");
        if (myListOne.Remove(3))
        {
            foreach (var item in myListOne)
            {
                Console.Write(item + " ");
            }
        }
        else
        {
            Console.WriteLine("There is no such element.");
        }

        Console.WriteLine();
        for (var i = 0; i < myListTwo.Count; i++)
        {
            myListTwo[i] -= 1.0;
            Console.Write(myListTwo[i] + " ");
        }
        
        Console.WriteLine("\n\nMethod Remove for myListTwo. If removed - print new list, else print message that there is no such element.");
        if (myListTwo.Remove(8.9))
        {
            foreach (var item in myListTwo)
            {
                Console.Write(item + " ");
            }
        }
        else
        {
            Console.WriteLine("There is no such element.");
        }

        for (var i = 0; i < myListThree.Capacity; i++)
        {
            if (i % 2 == 0)
            {
                myListThree.Add(true);
                continue;
            }

            myListThree.Add(false);
        }

        Console.WriteLine();
        foreach (var item in myListThree)
        {
            Console.Write(item + " ");
        }

        Console.WriteLine("\nMethod Clear: ");
        myListOne.Clear();
        if (myListOne.Count == 0)
        {
            Console.WriteLine("List is empty.");
        }

        Laptop laptop1 = new Laptop(1100, "M1", 512, null, 8, 1.29f, "Mac OS", true, 13.3f,
            "IPS", "Apple Macbook Air", "Midnight blue");
        Laptop laptop2 = new Laptop(1250, "Intel core i7", 256, 1028, 16, 1.56f, "Windows", false, 15.6f,
            "IPS", "Dell", "Grey");
        Laptop laptop3 = new Laptop(900, "AMD Ryzen 5", 256, 512, 16, 2.2f, "Linux", false, 14.2f,
            "TN+Film", "HP", "Blue");
        Laptop laptop4 = new Laptop(1500, "M1", 1028, null, 16, 1.44f, "Mac OS", true, 14.5f,
            "IPS", "Apple Macbook Pro", "Space grey");
        
        List<Laptop> listOfLaptops = new List<Laptop>() { laptop2, laptop3, laptop4, laptop1 };

        Console.WriteLine("\nBefore sort: ");
        foreach (var item in listOfLaptops)
        {
            Console.WriteLine();
            Console.WriteLine(item);
        }
        
        listOfLaptops.Sort();
        
        Console.WriteLine("\nAfter sorted: ");
        foreach (var item in listOfLaptops)
        {
            Console.WriteLine();
            Console.WriteLine(item);
        }
    }
}