using HW25._01._2023.Models;
using HW25._01._2023.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW25._01._2023
{
    public class WeatherForecastDbHandler
    {
        private WeatherForecastDbContext _contexDb;
        public WeatherForecastDbHandler(WeatherForecastDbContext contexDb)
        {
            _contexDb = contexDb;
        }
        public List<WeatherForecast> AllLines() => _contexDb.weatherForecasts.ToList<WeatherForecast>();
        public List<WeatherForecast> TempMoreThan(int x) => _contexDb.weatherForecasts.Where(wf => wf.TempC > x).ToList<WeatherForecast>();
        public List<WeatherForecast> TempLessThan(int x) => _contexDb.weatherForecasts.Where(wf => wf.TempC < x).ToList<WeatherForecast>();
        public bool Add(WeatherForecast sample)
        {
            try
            {
                _contexDb.Add(sample);
                this.SaveChanges();
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }
        public WeatherForecast FindById(int id) =>  _contexDb.weatherForecasts.FirstOrDefault(w => w.Id == id);
        public void SaveChanges()
        {
            _contexDb.SaveChanges();
        }
        public bool Delete(int id)
        {
            try
            {
                var weatherForecast = _contexDb.weatherForecasts.First(w => w.Id == id);
                _contexDb.weatherForecasts.Remove(weatherForecast);
                this.SaveChanges();
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
