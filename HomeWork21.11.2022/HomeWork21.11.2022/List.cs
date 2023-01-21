using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork21._11._2022
{
    internal class List
    {
        public int capasity { get; set; }
        public int size { get; set; }
    }
    public interface IEnumerable
    {
        IEnumerator GetEnumerator();
    }
}
