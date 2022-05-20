using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Promedio.Aplications.Iservices;
using Promedio.Aplications.Services;
using Promedio.Domain.Interfaces;
using Promedio.Domain.PromedioEntities;
using Promedio.Infraestucture.Repository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Promedio.App
{
    static class Program
    {
        public static IConfiguration Configuration;
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables().Build();



            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
   

            var services = new ServiceCollection();
            services.AddDbContext<PepitoSchoolContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("Default"));
            });
            services.AddScoped<IDbContext, PepitoSchoolContext>();
            services.AddScoped<Iestudiante, EstudianteRepository>();
            services.AddScoped<IEstudianteservice, EstudianteService>();
            services.AddScoped<Form1>();
            using(var servicesscope = services.BuildServiceProvider())
            {
                var main = servicesscope.GetRequiredService<Form1>();
                Application.Run(main);
            }
        }
    }
}
