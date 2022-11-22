namespace TMS_Seventh_App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var helper = new PagnationHelper<char>(new List<char> { 
                  'a', 'b', 'c', 'd', 'e', 'f'
                , 'g', 'h', 'i', 'j', 'k', 'l'
                , 'm', 'n', 'o', 'p', 'r', 's'
                , 't', 'u', 'w', 'x', 'y', 'z'
            }, 10);
            Console.WriteLine(helper.PageCount); //should == 3
            Console.WriteLine(helper.ItemCount); //should == 24
            Console.WriteLine(helper.PageItemCount(-1)); //should == -1
            Console.WriteLine(helper.PageItemCount(2)); //should == 4

            // pageIndex takes an item index and returns the page that it belongs on
            Console.WriteLine(helper.PageIndex(5)); //should == 0 
            Console.WriteLine(helper.PageIndex(2)); //should == 0
            Console.WriteLine(helper.PageIndex(20)); //should == 2
            Console.WriteLine(helper.PageIndex(-10)); //should == -1
        }
    }
}