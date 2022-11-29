using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class PaginationHelper
    {
        public int page_count;
        public int item_count;
        public string[] data;
        public int[] pages;
        public int pageNum;

        public PaginationHelper()
        {
            pageNum = 0;
            page_count = 0;
            data = new string[pageNum];
            this.item_count = data.Length;
        }

        public PaginationHelper(string[] data, int num)
        {
            pageNum = num;
            this.data = data;
            item_count = data.Length;
            if ((item_count % num) > 0)
            {
                page_count = item_count / num + 1;
            }
            else if ((item_count % num) == 0)
            {
                page_count = item_count / num;
            }
            else
            {
                throw new ArgumentException();
            }

            var pages = new int[item_count];

            for (int i = 0; i < item_count; i++)
            {
                pages[i] = i / num;
            }
            this.pages = pages;
        }

        public int PageItemCount(int nItem)
        {
            int i = 0;
            foreach (var item in this.pages)
            {
                if (item == nItem)
                {
                    i++;
                }
            }
            if (nItem > (page_count-1))
            {
                i = -1;
            }
            return i;
        }

        public int PageIndex(int nItem)
        {
            
            if (nItem < 0 || nItem >= item_count)
            {
                return -1;
            }
            int i = pages[nItem];
            return i;
        }

    }
}
