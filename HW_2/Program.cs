using System.ComponentModel.Design;
using System.Runtime.Intrinsics.X86;

namespace HW_2
{
    internal class Program
    {
        const int N = 1000;
        //интеграл ln(x+1)
        static void Main(string[] args)
        {
            // определение исходной функции через сокращенную запись метода
            static double f(double x) => Math.Log(x + 1);

            // приглашение к вводу пользователя
            Console.WriteLine("Enter range of integral - [x1;x2]");
            Console.WriteLine("x1:");
            double x1 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("x2:");
            double x2 = Convert.ToDouble(Console.ReadLine());

            // расчет интеграла по симпсону
            double M_Simpson = (f(x1) + 4 * f(x1 + x2 / 2) + f(x2)) * (x2 - x1) / 6;

            // расчет интеграла по кортесу
            double h = (x2 - x1) / N;

            double sum1 = 0, sum2 = 0;

            for (int k = 1; k < N; k++)
            {
                double xk = x1 + k * h;
                sum1 += f(xk);
            }

            for (int k = 1; k <= N; k++)
            {
                double xk = x1 + k * h;
                double xk_1 = x1 + (k - 1) * h;
                sum2 += f((xk + xk_1)/2);
            }

            double M_Cortes = h / 3 * (0.5 * (f(x1) + f(x2)) + sum1 + 2*sum2);
            
            // вывод резульатов
            Console.WriteLine("Simpson - {0, -10:f6}, Cortes - {1, -10:f6}", M_Simpson, M_Cortes);

        
        }

    }
}