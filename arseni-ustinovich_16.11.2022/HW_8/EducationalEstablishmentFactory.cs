using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HW_8
{
    public static class EducationalEstablishmentFactory
    {
        private static int StrToNum(string msg)
        {
            var isUncorrect = false;
            int result = 0;
            do
            {
                Console.WriteLine(msg);
                if (!int.TryParse(Console.ReadLine(), out result))
                {
                    Console.WriteLine("Fakamakaka, input error\n");
                    isUncorrect = true;
                }
                else
                {
                    isUncorrect = false;
                }
            }
            while (isUncorrect);
            
            return result;
        }        
        public static void Create<T>(this T eduEst) 
            where T : EducationalEstablishment
        {
            Console.WriteLine(typeof(T).Name);
            
            Console.WriteLine("Enter name of educational establishment!");
            eduEst.Name = Console.ReadLine();

            eduEst.StudentNumber = StrToNum("Enter students number!");

            eduEst.WorkersNumber = StrToNum("Enter workers number!");

            Console.WriteLine("Enter address of educational establishment!");
            eduEst.Address = Console.ReadLine();

            if (eduEst is School)
            {
                (eduEst as School).PregnantEnglishTeachersCount = StrToNum("Enter pregnant english teachers number!");
            }

            if (eduEst is University)
            {
                (eduEst as University).CountOfFaculty = StrToNum("Enter faculties number!");

                (eduEst as University).CountOfDorms = StrToNum("Enter dorms number!");
            }
        }
    }
}
