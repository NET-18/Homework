using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework6
{
    abstract class MakeUp
    {
        public abstract string Company { get; set; }
        public abstract string Color { get; set; }

        public abstract void MakeUpInfo();
    }
}
