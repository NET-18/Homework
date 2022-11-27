using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp4
{
    internal class Vagon : IComparable<Vagon>
    {
        public int NumberOfAxes { get; set; }
        public int LengthByCoupling { get; set; }
        public int Tonnage { get; set; }
        public string Type { get; set; }
        public int Value { get; set; }
        public Vagon() 
        {
            NumberOfAxes = 4;
            LengthByCoupling = 12_000;
            Tonnage = 60;
            Type = "";
            Value = 0;
        }

        public int CompareTo(Vagon? obj)
        {
            if (obj is null) throw new ArgumentException("Некорректное значение параметра");
            return Type.CompareTo(obj.Type);
        }
    }
}
