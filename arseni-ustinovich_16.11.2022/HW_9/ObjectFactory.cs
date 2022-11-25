using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HW_9
{
    public static class FakamakaFactory
    {
        public static void Create<T>(this T fakamaka) where T : class, new()
        {
            Type myType = typeof(T);

            PropertyInfo[] myProperties = myType.GetProperties(BindingFlags.Instance | BindingFlags.NonPublic |
                BindingFlags.Public | BindingFlags.Static);

            Random rnd = new Random();
            foreach (PropertyInfo property in myProperties) 
            {
                if (property.PropertyType == typeof(int))
                { 
                    property?.SetValue(fakamaka, rnd.Next(0,1000));
                }

                if (property.PropertyType == typeof(string))
                {
                    string text = "";
                    for (int i = 0; i < rnd.Next(0, 30); i++)
                    {
                        text += i.ToString();
                    }
                    property?.SetValue(fakamaka, text);
                }

                if (property.PropertyType == typeof(bool))
                {
                    if (rnd.Next(0, 2) == 1)
                    {
                        property?.SetValue(fakamaka, true);
                    }
                    else
                    {
                        property?.SetValue(fakamaka, false);
                    }
                    
                }
            }
        }

    }
}
