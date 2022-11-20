using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework_16._11._2022
{
    internal class WeaponFactory
    {
        public static T Create<T>(int maxLoad) where T : Weapon, new()
        {
            var result = new T()
            {
                RateOfFire = 1,
                Load = 0,
                MaxLoad = maxLoad
            };
            return result;
        }
   
    }
}
