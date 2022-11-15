using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework_16._11._2022
{
    internal class WeaponFactory
    {
        public static void Create<T>(T weapon) where T: Weapon
        {
            weapon.RateOfFire = 1;
            weapon.Load = 0;
            if (weapon is PistolMakarov)
            {
                weapon.MaxLoad = 8;
            }
            if (weapon is Kalash)
            {
                weapon.MaxLoad = 30;
            }
            weapon.DoStuff();
        }
    }
}
