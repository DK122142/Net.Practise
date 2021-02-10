using System;
using System.IO;
using EducationPortalADO.DAL.Infrastructure;
using EducationPortalADO.DAL.Repositories;
using EducationPortalADO.DAL.Services;
using Microsoft.Extensions.Configuration;

namespace EducationPortalADO.DAL.Views
{
    public class Start
    {
        public Start()
        {
            IConfiguration configuration;

            try
            {
                configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("config.json", false)
                    .Build();
            }
            catch (Exception e)
            {
                Console.WriteLine("Connection string not found in file config.json. Place file in folder with .exe");
                throw;
            }

            Provider.ConnectionString = configuration.GetSection("connectionString").Value;
            Provider.AccountService = new AccountService(new AccountRepository(Provider.ConnectionString));
            Provider.RoleService = new RoleService(new RoleRepository(Provider.ConnectionString));

            Home.Home.Show();
        }
    }
}
