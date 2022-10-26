using System;
using System.ComponentModel;
using System.Runtime.ExceptionServices;

namespace HW_1
{
    internal class Program
    {
        static void Main()
        {
            int el_num = 0;
            var isUncorrect = false;
            
            // приглашение пользователя к вводу кол-ва элементов
            do
            {
                Console.WriteLine("Enter amount of number:");
                if (!int.TryParse(Console.ReadLine(), out el_num) || el_num <= 1)
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
            
            // инициализация массива
            int[] numbers = new int[el_num];

            // приглашение пользователя к выбору варианта заполнения массива
            int in_op;
            do
            {
                Console.WriteLine("Do you want to enter number by youself or random? [0 - Yourself, 1 - Random]");
                if (!int.TryParse(Console.ReadLine(), out in_op) || in_op>1 || in_op<0)
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

            // где-нибудь написать бы метод, который убирал бы из массива повторяющиеся более 2-ух раз числа, но и так пойдет     
            // ручный / рандомный ввод исходных чисел
            switch (in_op)
            {
                case 0:
                    Console.WriteLine($"Enter {el_num} number:");

                    // заполение массива чисел
                    for (int i = 0; i < el_num; i++)
                    {
                        numbers[i] = Convert.ToInt32(Console.ReadLine()); // дядя, вводи числа небольшие, форматирование полетит в тар-тарары
                    }

                    callfuncs(numbers, el_num);
                    break;

                case 1:

                    Random rnd = new Random();

                    // заполение массива случайными числами
                    for (int i = 0; i < el_num; i++)
                    {
                        numbers[i] = rnd.Next(-500, 500);
                        // вывод полученных чисел
                        Console.WriteLine("{0, 4}) {1}", i+1,numbers[i]);
                    }
                    callfuncs(numbers, el_num);
                    break;
            }
           
        }
            
        // метод вызова методов сложения вычитания умножения деления
        static void callfuncs(int[] nums, int el_num)
        {
            Console.WriteLine("\nAddition:\n");
            Add(nums, el_num);

            Console.WriteLine("\nSubstraction:\n");
            Sub(nums, el_num);

            Console.WriteLine("\nMiltiplication:\n");
            Multi(nums, el_num);

            Console.WriteLine("\nDivision:\n");
            Div(nums, el_num);
        }

        // метод сложения чисел
        static void Add(int[] nums, int el_num)
        {
            int count = 0;
            // перебор массива чисел
            for (int i = 0; i < el_num; i++)
            {
                // перебор массива чисел после выбранного
                for (int j = i+1; j < el_num; j++)
                {
                    
                    // форматированный вывод результата операции сложения 2-ух чисел
                    Console.Write("| {0, 4} + {1,4} = {2, 5} |", nums[i], nums[j], nums[i]+nums[j]);
        
                    if (++count % 4 == 0) Console.WriteLine();

                }
            }
            if (count % 4 != 0) Console.WriteLine();
        }

        static void Sub(int[] nums, int el_num)
        {
            // перебор массива чисел
            for (int i = 0; i < el_num; i++)
            {
                // перебор массива чисел после выбранного
                for (int j = i + 1; j < el_num; j++)
                {
                    // форматированный вывод результата операции вычитание 2-ух чисел
                    Console.Write("| {0, 4} - {1,4} = {2, 4} |", nums[i], nums[j], nums[i] - nums[j]);
                    Console.WriteLine("| {0, 4} - {1,4} = {2, 4} |", nums[j], nums[i], nums[j] - nums[i]);
                }
            }
        }

        static void Multi(int[] nums, int el_num)
        {
            int count = 0;
            // перебор массива чисел
            for (int i = 0; i < el_num; i++)
            {
                // перебор массива чисел после выбранного
                for (int j = i + 1; j < el_num; j++)
                {

                    // форматированный вывод результата операции умножения 2-ух чисел
                    Console.Write("| {0, 4} * {1,4} = {2, 7} |", nums[i], nums[j], nums[i] * nums[j]);

                    if (++count % 4 == 0) Console.WriteLine();
                }
            }
            if (count % 4 != 0) Console.WriteLine();
        }

        static void Div(int[] nums, int el_num)
        {
          
            // перебор массива чисел
            for (int i = 0; i < el_num; i++)
            {
                // перебор массива чисел относительно выбранного
                for (int j = i + 1; j < el_num; j++)
                {
                    // форматированный вывод результата операции деления 2-ух чисел
                    Console.Write("| {0, 4} / {1,4} = {2, 8:f4} |", nums[i], nums[j], (double)nums[i] / nums[j]);
                    Console.WriteLine("| {0, 4} / {1,4} = {2, 8:f4} |", nums[j], nums[i], (double)nums[j] / nums[i]);

                }
            }
        }


    }
}