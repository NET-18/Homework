using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_11
{
    internal class PaginationHelper<T>
    {
        private int _dataPerPage;
        private int _dataCount;
        private List<T> Data { get; set; }
        public PaginationHelper(List<T> data, int dataPerPage)
        {
            Data = data;
            _dataPerPage = dataPerPage;
            _dataCount = Data.Count;
        }
        public int PageCount() => 
            (_dataCount % _dataPerPage == 0) ? 
            (_dataCount / _dataPerPage) : (_dataCount / _dataPerPage + 1);
        public int ItemCount() => _dataCount;
        public int PageItemCount(int page)
        {

            if (page < 0 || page >= PageCount())
            {

                return -1;
            }
            else if (page + 1 < PageCount())
            {
                return _dataPerPage;
            }
            else
            {
                return _dataCount % _dataPerPage;
            }
        }
        public int PageIndex(int itemIndex)
        {
            if (itemIndex >= _dataCount || itemIndex < 0)
            {
                return -1;
            }
            else
            {
                return itemIndex / _dataPerPage;
            }
        }
    }
}
