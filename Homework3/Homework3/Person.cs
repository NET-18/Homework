﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Homework3
{
    public class Person
    {

        //KОНСТРУКТОРЫ
        public Person(string name, int age, string surName) //Параметры или аргументы конструктора в данном случае
        {
            Name = name;
            Age = age;
            SurName = surName;
        }

        //СВОЙСТВА
        public string Name { get; set; }
       
        
        public int Age { get; set; } 
        public string SurName { get; set; }

    }
}
