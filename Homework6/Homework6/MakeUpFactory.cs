using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework6
{
    internal static class MakeUpFactory
    {
        public static void Create<T>(T makeup) where T : MakeUp
        {
            makeup.MakeUpInfo();
        }
    }
}
