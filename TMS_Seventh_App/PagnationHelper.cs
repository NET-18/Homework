using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TMS_Seventh_App
{
    internal class PagnationHelper<T>
    {
        // TODO: Complete this class

        /// <summary>
        /// Constructor, takes in a list of items and the number of items that fit within a single page
        /// </summary>
        /// <param name="collection">A list of items</param>
        /// <param name="itemsPerPage">The number of items that fit within a single page</param>
        int itemCount;
        int itemPerPage;
        IList<T> items;

        public PagnationHelper(IList<T> collection, int itemsPerPage)
        {
            itemCount = collection.Count;
            itemPerPage = itemsPerPage;
            items = collection;
        }

        /// <summary>
        /// The number of items within the collection
        /// </summary>
        public int ItemCount
        {
            get
            {
                return itemCount;
            }
        }

        /// <summary>
        /// The number of pages
        /// </summary>
        public int PageCount
        {
            get
            {
                int res = ItemCount / itemPerPage;
                if (ItemCount % itemPerPage != 0)
                {
                    return res+1;
                }
                return res; 
            }
        }

        /// <summary>
        /// Returns the number of items in the page at the given page index 
        /// </summary>
        /// <param name="pageIndex">The zero-based page index to get the number of items for</param>
        /// <returns>The number of items on the specified page or -1 for pageIndex values that are out of range</returns>
        public int PageItemCount(int pageIndex)
        {
            if (pageIndex >= PageCount)
            {
                return -1;
            }
            else if (pageIndex == PageCount - 1)
            {
                return items.Count % itemPerPage ;
            }
            else if (pageIndex <= -1)
            {
                return -1;
            }
            return itemPerPage;
        }

        /// <summary>
        /// Returns the page index of the page containing the item at the given item index.
        /// </summary>
        /// <param name="itemIndex">The zero-based index of the item to get the pageIndex for</param>
        /// <returns>The zero-based page index of the page containing the item at the given item index or -1 if the item index is out of range</returns>
        public int PageIndex(int itemIndex)
        {
            if(itemIndex >= items.Count || itemIndex <0)
            {
                return -1;
            }
            return itemIndex / itemPerPage;
        }
    }
}
