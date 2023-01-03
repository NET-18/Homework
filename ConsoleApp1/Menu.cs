using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Menu
    {
        public List<Drink> drinks { get; set; }
        public Menu (List<Drink> positions)
        {
            drinks = positions;
        }
    }
}
