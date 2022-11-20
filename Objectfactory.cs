using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework_16._11._2022
{
    internal class ObjectFactory
    {
        public static T Create<T>() where T : new()
        {
            var result = new T();

            Type myType = result.GetType();
            Random rnd = new Random();

            //int value = rnd.Next(10, 20);
            //var maxLoad = myType.GetProperty("MaxLoad");
            //maxLoad?.SetValue(result, value);

            //int value2 = rnd.Next(0, 20);
            //var load = myType.GetProperty("Load");
            //load?.SetValue(result, value2);

            //int value3 = rnd.Next(1, 5);
            //var rate = myType.GetProperty("RateOfFire");
            //rate?.SetValue(result, value3);
            
            foreach (var item in myType.GetProperties())
            {
                int value4 = rnd.Next(0, 20);
                item?.SetValue(result, value4);
            }
            
            return result;

        }
    }
}

