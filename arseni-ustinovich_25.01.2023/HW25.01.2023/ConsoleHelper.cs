using HW25._01._2023.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HW25._01._2023
{
    public static class ConsoleHelper
    {
        private static WeatherForecastDbHandler _handler;
        public static void Init(WeatherForecastDbHandler handler)
        {
            _handler = handler;
        }
        public static void StartInfo()
        {
            var startString = "0 - To read all data from DB;\n" +
                "1 - To read all weather forecast, which temperature more then [number].\n" +
                "2 - To read all weather forecast, which temperature less then [number].\n" +
                "add - to add weather forecast - date(f.e.: 03/01/2009 10:00 AM), \n\t\t\t\ttempC as number(f.e.: 10), summary as string(f.e.: rainy)\n" +
                "change - To change sample by Id. Write \"stop\" to finish changing fields. \n" +
                "delete - To delete sample by Id.\n" +
                "clear - To clear console.\n" +
                "exit - To shut down the app.\n";

            Console.WriteLine(startString);
        }
        public static bool ReadCommand()
        {
            Console.Write("> ");
            var command = Console.ReadLine();

            switch (command)
            {
                case "0":
                    ShowList(_handler.AllLines());
                    break;

                case "1":
                    Console.Write("Enter number: ");
                    int? number = ReadIntNumber();
                    if (number != null)
                    {
                        ShowList(_handler.TempMoreThan((int)number));
                    }
                    break;

                case "2":
                    Console.Write("Enter number: ");
                    number = ReadIntNumber();
                    if (number != null)
                    {
                        ShowList(_handler.TempLessThan((int)number));
                    }
                    break;

                case "clear":
                    Console.Clear();
                    ConsoleHelper.StartInfo();
                    break;

                case "exit":
                    return true;

                case "add":
                    AddSample();
                    break;

                case "change":
                    Console.Write("Enter id: ");
                    number = ReadIntNumber();
                    if (number != null)
                    {
                        ChangeSampleById((int)number);
                    }
                    break;

                case "delete":
                    Console.Write("Enter id: ");
                    number = ReadIntNumber();
                    if (number != null)
                    {
                        DeleteSampleById((int)number);
                    }
                    break;

                default:
                    Console.WriteLine("Command doesn't exist!");
                    break;
            }

            return false;
        }
        private static int? ReadIntNumber()
        {
            var inputString = Console.ReadLine();
            if (Int32.TryParse(inputString, out int x))
            {
                return x;
            }
            else
            {
                Console.WriteLine("InputError!");
                return null;
            }
        }
        public static void ShowList<T>(IEnumerable<T> listOfObjects) where T : class
        {
            if (listOfObjects.Count() == 0)
            {
                Console.WriteLine("None");
                return;
            }

            var type = typeof(T);
            var properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public);
            var propertyNames = new List<string>();
            var sizeofColums = SizeOfColumns<T>(listOfObjects);
            var header = string.Empty;

            int i = 0;
            foreach (var property in properties)
            {
                propertyNames.Add(property.Name);
                header += string.Format("{0," + $"{sizeofColums[i++] + 5}" + "}", property.Name);
            }
            Console.WriteLine(header);

            var finalDataString = string.Empty;
            foreach (var item in listOfObjects)
            {
                i = 0;
                var dataString = string.Empty;
                foreach (var propertyName in propertyNames)
                {
                    var propertyValue = type.GetProperty(propertyName).GetValue(item);

                    dataString += string.Format("{0," + $"{sizeofColums[i++] + 5}" + "}", propertyValue.ToString());
                }
                finalDataString += dataString + '\n';
            }
            Console.WriteLine(finalDataString);
        }
        // SizeOfColums определяет ширину колонки для консоли по максимальному по длине полю для всех данных в бд
        private static int[] SizeOfColumns<T>(IEnumerable<T> listOfObjects) where T : class
        {
            var type = typeof(T);
            var properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public);
            var propertyNames = new List<string>();

            foreach (var property in properties)
            {
                propertyNames.Add(property.Name);
            }

            var sizeOfColumns = new int[propertyNames.Count];

            foreach (var item in listOfObjects)
            {
                int i = 0;
                foreach (var propertyName in propertyNames)
                {
                    var propertyValueStrLen = type.GetProperty(propertyName)
                        .GetValue(item)
                        .ToString()
                        .Length;

                    if (sizeOfColumns[i] < propertyValueStrLen)
                    {
                        sizeOfColumns[i] = propertyValueStrLen;
                    }
                    i++;
                }
            }
            return sizeOfColumns;
        }
        private static bool ChangeField(WeatherForecast weatherForecast)
        {
            Console.Write("field: ");
            var field = Console.ReadLine();
            switch (field)
            {
                case "Date":
                    Console.Write("> ");
                    var culture = CultureInfo.CreateSpecificCulture("en-US");
                    var styles = DateTimeStyles.None;
                    var dataString = Console.ReadLine();
                    if (!DateTime.TryParse(dataString, culture, styles, out DateTime dateResult))
                    {
                        Console.WriteLine("InputError.");
                    }
                    else
                    {
                        weatherForecast.Date = dateResult;
                    }
                    break;

                case "TempC":
                    Console.Write("> ");
                    int? tempC = ReadIntNumber();
                    if (tempC == null)
                    {
                        Console.WriteLine("InputError.");
                    }
                    else
                    {
                        weatherForecast.TempC = (int)tempC;
                    }
                    break;

                case "Summary":
                    Console.Write("> ");
                    string summary = Console.ReadLine();
                    weatherForecast.Summary = summary;
                    break;

                case "stop":
                    return false;

                default:
                    Console.WriteLine("Doesn't exist or inaccessible!");
                    break;
            }
            return true;
        }
        private static void ChangeSampleById(int id)
        {
            var weatherForecast = _handler.FindById(id);

            if (weatherForecast == null)
            {
                Console.WriteLine("Can't find sample by Id!");
                return;
            }

            Console.WriteLine($"\nId(inaccessible): {weatherForecast.Id}");
            Console.WriteLine($"Date: {weatherForecast.Date}");
            Console.WriteLine($"TempC: {weatherForecast.TempC}");
            Console.WriteLine($"TempF(inaccessible): {weatherForecast.TempF}");
            Console.WriteLine($"Summary: {weatherForecast.Summary}\n");

            while (ChangeField(weatherForecast)) { }

            try
            {
                _handler.SaveChanges();
                Console.WriteLine("Sample changed!");
            }
            catch (Exception)
            {

                Console.WriteLine("Error. Operation failed!");
            }
        }
        private static void DeleteSampleById(int id)
        {
            var weatherForecast = _handler.FindById(id);

            if (weatherForecast == null)
            {
                Console.WriteLine("Can't find sample by Id!");
                return;
            }

            if (_handler.Delete(id))
            {
                Console.WriteLine("Operation completed successfully");
            }
            else
            {
                Console.WriteLine("Error. Operation failed!");
            }
        }
        private static void AddSample()
        {
            if (!_handler.Add(CreateSample()))
            {
                Console.WriteLine("Error. Operation failed!");
            }
            else
            {
                Console.WriteLine("Operation completed successfully");
            }
        }
        private static WeatherForecast CreateSample()
        {
            // через рефлексю создать экземпляр и заполнить его инфой введенной с клавы сложно, ибо типы не только стринг и инт...
            //var type = typeof(T);
            //var properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public); ;
            //var propertyNames = properties.Where(p => p.CanWrite == true && p.Name != "Id").Select(p => p.Name).ToArray();
            //var propertyTypes = properties.Where(p => p.CanWrite == true && p.Name != "Id").Select(p => p.PropertyType).ToArray();
            //var newSample = new T();

            var culture = CultureInfo.CreateSpecificCulture("en-US");
            var styles = DateTimeStyles.None;

            Console.Write("Date: ");
            var dataString = Console.ReadLine();
            if (!DateTime.TryParse(dataString, culture, styles, out DateTime dateResult))
            {
                Console.WriteLine("InputError.");
                return null;
            }

            Console.Write("TempC: ");
            int? tempC = ReadIntNumber();
            if (tempC == null)
            {
                Console.WriteLine("InputError.");
                return null;
            }

            Console.Write("Summary: ");
            string summary = Console.ReadLine();

            var newSample = new WeatherForecast()
            {
                Date = dateResult,
                Summary = summary,
                TempC = (int)tempC
            };

            return newSample;
        }

    }
}
