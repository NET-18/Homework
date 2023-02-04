using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Homewok_25._01._2023
{
    class DatabaseContext : DbContext
    {
        public DbSet<WeatherForecast> WeatherForecasts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            base.OnConfiguring(builder);

            builder.UseSqlServer(@"Data Source=.\SQLEXPRESS;Initial Catalog=homework_database_25.01.2023;Trusted_Connection=True;TrustServerCertificate=True");
        }
    }
}
