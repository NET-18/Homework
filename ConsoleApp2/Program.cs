namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var helper = new PaginationHelper(new string[] { "a", "b", "c", "d", "e", "f" }, 4);

            var i = helper.PageIndex(1);
            var j = helper.PageItemCount(2);
            var k = helper.page_count;
            var z = helper.item_count;

            Console.WriteLine("PageIndex= {0} ,PageItemCount= {1}, page_count= {2}, item_count= {3}", i, j, k, z);
        }
    }
}