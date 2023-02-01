using HW25._01._2023.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW25._01._2023.Persistance
{
    public class WeatherForecastDbContext : DbContext
    {
        public DbSet<WeatherForecast> weatherForecasts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            base.OnConfiguring(builder);

            builder.UseSqlServer(@"Data Source=User-PC;Initial Catalog=WF_Database;Trusted_Connection=True;TrustServerCertificate=True");
        }
    }
}
