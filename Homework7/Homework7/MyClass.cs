using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework7
{
    internal class MyClass : IComparable
    {
        private int count;

        public MyClass(int count)
        {
            this.count = count;
        }

        public int Count
        {
            get
            {
                return count;
            }
        }

        public int CompareTo(object? obj)
        {
            if (obj is MyClass obj1)
            {
                return Count.CompareTo(obj1.Count);
            }
            else
            {
                throw new ArgumentException("Incorrect parameter value");
            }
        }
    }
}
