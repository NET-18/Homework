using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework_16._11._2022
{
    internal class WeaponFactory
    {
        public static T Create<T>() where T : Weapon, new()
        {
            var result = new T()
            {
                RateOfFire = 1,
                Load = 0
            };
            if (result is PistolMakarov)
            {
                result.MaxLoad = 8;
            }
            if (result is AK47)
            {
                result.MaxLoad = 30;
            }
                return result;
        }
   
    }
}
