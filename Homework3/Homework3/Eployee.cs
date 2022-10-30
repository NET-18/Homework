﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework3
{
    internal class Eployee : Person
    {
        public Eployee(int wageInHour, int wageInMonth, int experienceInYears, string name, int age, string serName) : base(name, age, serName)
        {
            WageInMonth = wageInMonth;
            WageInHour = wageInHour;
            ExperienceInYears = experienceInYears;

        }

        public int WageInMonth { get; set; }
        public int WageInHour { get; set; }
        public int ExperienceInYears { get; set; }

        public void AddSalary(int number)
        {
            ExperienceInYears = ExperienceInYears + number;

        }
        public void DeleteEployee(Eployee eployee)
        {
            WageInHour = 0;
            ExperienceInYears = 0;
            WageInMonth = 0;
         
        }
        

    }
}
