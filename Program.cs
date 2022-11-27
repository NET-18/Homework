using System;
using System.Diagnostics.CodeAnalysis;

namespace ConsoleApp4
{

    internal class Program
    {
        static void Main(string[] args)
        {
            var myCollection = new MyList<int>(new int[] { 1, 2, 3 });

            myCollection.Add(1);

            foreach (var item in myCollection)
            {
                Console.WriteLine(item);
            }

            myCollection.Clear();
            foreach (var item in myCollection)
            {
                Console.WriteLine(item);
            }

            var vagons = new List<Vagon>();

            var Ind_11_7038 = new Vagon()
            {
                Type = "Indoor",
                NumberOfAxes = 4,
                LengthByCoupling = 17_500,
                Tonnage = 68,
                Value = 150
            };
            var Ind_11_1807_01 = new Vagon()
            {
                Type = "Indoor",
                NumberOfAxes = 4,
                LengthByCoupling = 17_600,
                Tonnage = 67,
                Value = 158
            };
            
            var Ind_11_280 = new Vagon()
            {
                Type = "Indoor",
                NumberOfAxes = 4,
                LengthByCoupling = 17_500,
                Tonnage = 68,
                Value = 138
            };
            vagons.Add(Ind_11_280);
            var Pl_13_6719 = new Vagon()
            {
                Type = "Platform",
                NumberOfAxes = 4,
                LengthByCoupling = 14_600,
                Tonnage = 72,
                Value = 37
            };
            
            var Pl_2114_07 = new Vagon()
            {
                Type = "Platform",
                NumberOfAxes = 4,
                LengthByCoupling = 14_600,
                Tonnage = 66,
                Value = 120
            };
            
            var Gd_12_9837 = new Vagon()
            {
                Type = "Gondola",
                NumberOfAxes = 4,
                LengthByCoupling = 14_000,
                Tonnage = 70,
                Value = 88
            };
           
            var Gd_12_2153_01 = new Vagon()
            {
                Type = "Gondola",
                NumberOfAxes = 4,
                LengthByCoupling = 12_600,
                Tonnage = 70,
                Value = 88
            };

            vagons.Add(Gd_12_2153_01); 
            vagons.Add(Gd_12_9837);
            vagons.Add(Pl_2114_07);
            vagons.Add(Pl_13_6719);
            vagons.Add(Ind_11_1807_01);
            vagons.Add(Ind_11_7038);

            vagons.Sort();
            foreach (Vagon vagon in vagons)
            {
                Console.WriteLine($"{vagon.Type} - {vagon.Value}");
            }
        }
    }
}