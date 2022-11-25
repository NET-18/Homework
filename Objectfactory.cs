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

                        
            foreach (var item in myType.GetProperties())
            {
                int value4 = rnd.Next(0, 20);
                item?.SetValue(result, value4);
            }
            
            return result;

        }
    }
}

