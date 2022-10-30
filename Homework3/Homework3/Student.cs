using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework3
{
    internal class Student : Person 
    {
        public Student(string name, int age,string surName,int course, string department) 
            : base(name,age,surName)
        {
            Course = course; 
            Department = department;
        }

        public int Course { get; set; }
        public string Department { get; set; } 

        public void DeleteStudent(Student student)
        {
            Course = 0;
            Department = string.Empty;
        }
    }
    
}

