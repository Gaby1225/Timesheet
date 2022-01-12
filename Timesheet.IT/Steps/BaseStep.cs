using Dapper;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Timesheet.Data.Context;
using Timesheet.Data.Support.Categorias;

namespace Timesheet.IT.Steps
{
    [Binding]
    public class BaseStep : WebApplicationFactory<Startup>
    {
        protected readonly WebApplicationFactory<Startup> Factory;
        private readonly DbCategoria CategoriaDb = new DbCategoria();
        protected BaseStep(WebApplicationFactory<Startup> factory)
        {
            var projectDir = Directory.GetCurrentDirectory();
            var configPath = Path.Combine(projectDir, "appsettings.json");

            Factory = factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureAppConfiguration((context, conf) =>
                {
                    conf.AddJsonFile(configPath);
                });
            });

            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            config.GetSection("ConnectionStrings").Bind(CategoriaDb);
        }

        public void DeleteAll()
        {
            var sqlQuery = "DELETE from categorias" +
                            " DBCC CHECKIDENT ('[categorias]', RESEED, 0)";
                            

            using var connection = new SqlConnection(CategoriaDb.ServerConnection);
            connection.Execute(sqlQuery);
        }
    }
}
