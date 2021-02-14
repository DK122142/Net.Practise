using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace EducationPortalADO.DAL.Infrastructure
{
    public static class Config
    {
        public static string ConnectionString { get; set; }
        public static IConfiguration Configuration { get; set; }

        static Config()
        {
            try
            {
                Configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("config.json", false)
                    .Build();
            }
            catch (Exception e)
            {
                Console.WriteLine("Connection string not found in file config.json. Place file in folder with .exe");
                throw;
            }

            ConnectionString = Configuration.GetSection("connectionString").Value;
        }
    }
}
