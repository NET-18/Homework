using HW25._01._2023.Models;
using HW25._01._2023.Persistance;
using Newtonsoft.Json;
using System;

namespace HW25._01._2023
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var context = new WeatherForecastDbContext();
            var master = new WeatherForecastDbHandler(context);

            ConsoleHelper.Init(master);
            ConsoleHelper.StartInfo();

            while (!ConsoleHelper.ReadCommand()){ }
        }
    }
}