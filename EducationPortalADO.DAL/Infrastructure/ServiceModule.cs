using System;
using EducationPortalADO.DAL.Entities;
using EducationPortalADO.DAL.Interfaces;
using EducationPortalADO.DAL.Repositories;
using EducationPortalADO.DAL.Services;
using Microsoft.Extensions.DependencyInjection;

namespace EducationPortalADO.DAL.Infrastructure
{
    public static class ServiceModule
    {
        public static IServiceCollection Services { get; set; }

        public static IServiceProvider ServiceProvider { get; set; }

        static ServiceModule()
        {
            Services = new ServiceCollection();
            
            Services.AddTransient<IRepository<Account>>(x => new AccountRepository(Config.ConnectionString));
            Services.AddTransient<IRepository<Role>>(x => new RoleRepository(Config.ConnectionString));
            Services.AddTransient<IService<Account>, AccountService>();
            Services.AddTransient<IService<Role>, RoleService>();
            
            ServiceProvider = Services.BuildServiceProvider();
        }
    }
}
