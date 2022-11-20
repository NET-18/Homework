using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS_Seventh_App
{
    internal class MyNewClass : IComparable
    {
        public int Number { get; set; }
        public MyNewClass(int number) 
        {
            Number = number;
        }

        public int CompareTo(object? obj)
        {
            MyNewClass myNewClass= obj as MyNewClass;
            if (Number < myNewClass.Number)
                return -1;
            else if (Number > myNewClass.Number)
                return 1;
            else 
                return 0;
        }
    }
}
