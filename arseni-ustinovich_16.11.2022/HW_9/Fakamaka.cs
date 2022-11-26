using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_9
{
    public class Fakamaka
    {
        public int Age { get; private set; }
        private int Ble { get; set; }
        public bool Cue { get; private set; }
        private bool Dye { get; set; }
        public string? Eye { get; private set; }

        public void PrintData()
        {
            Console.WriteLine($"Age - {Age}");
            Console.WriteLine($"Ble - {Ble}");
            Console.WriteLine($"Cue - {Cue}");
            Console.WriteLine($"Dye - {Dye}");
            Console.WriteLine($"Eye - {Eye}");
        }
    }
}
