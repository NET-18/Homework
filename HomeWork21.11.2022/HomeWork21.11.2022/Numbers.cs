using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork21._11._2022
{
    internal class Numbers : System.IComparable<int>
    {
        public int Bumbers;
        public Numbers(int bumbers)
        {
            Bumbers = bumbers;
        }
        public int CompareTo(int other)
        {
            throw new NotImplementedException();
        }
    }
}
