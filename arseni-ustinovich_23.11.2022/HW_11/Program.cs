namespace HW_11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var helper = new PaginationHelper<Char>(new List<Char>{ 
                'a', 'b', 'c', 'd', 'e', 'f',
                'g', 'h', 'i', 'g', 'k', 'l',
                'm', 'n', 'o', 'p', 'r', 's',
                't'
            }, 3);

            Console.WriteLine(helper.ItemCount()); // should == 19
            Console.WriteLine(helper.PageCount()); // should == 7
            Console.WriteLine(helper.PageItemCount(0));  // should == 3
            Console.WriteLine(helper.PageItemCount(6)); // should == 1
            Console.WriteLine(helper.PageItemCount(10));  // should == -1 since the page is invalid
            
            //  PageIndex takes an item index and returns the page that it belongs on
            Console.WriteLine(helper.PageIndex(9));  // should == 3 
            Console.WriteLine(helper.PageIndex(2)); // should == 0
            Console.WriteLine(helper.PageIndex(20)); // should == -1
            Console.WriteLine(helper.PageIndex(-10)); // should == -1 
        
        }
    }
}