using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TMS_Sixth_App
{
    internal class HelperFactory
    {
        public void Create<T>(T animal) where T : Animal
        {
            animal.Name = Console.ReadLine();
            Console.WriteLine(animal.Name);
            
            animal.MaxRunSpeed = 20;
            Console.WriteLine(animal.MaxRunSpeed);
        }
    }
}
