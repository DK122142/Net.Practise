using System;
using System.IO;
using EducationPortalADO.DAL.Entities;
using EducationPortalADO.DAL.Repositories;
using Microsoft.Extensions.Configuration;

namespace EducationPortalADO.DAL
{
    class Program
    {
        static void Main(string[] args)
        {
            IConfiguration configuration;

            try
            {
                configuration= new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("config.json", false)
                    .Build();
            }
            catch (Exception e)
            {
                Console.WriteLine("Connection string not found in file config.json. Place file in folder with .exe");
                throw;
            }
            
            var accountRep = new AccountRepository(configuration.GetSection("connectionString").Value);
            var roleRep = new RoleRepository(configuration.GetSection("connectionString").Value);
            
            // var roles = roleRep.GetAll();
            // foreach (var role in roles)
            // {
            //     Console.WriteLine($"{role.Id}, {role.RoleType}, {role.Description}");
            // }

            // var newacc = new Account
            //     {Login = "newUser", Password = PasswordHasher.HashPassword("pass"), Role = (int) Roles.User};
            // accountRep.Create(newacc);
            
            // var account = accountRep.Get(2);
            // account.Login = "updatedUser";
            // accountRep.Update(account);
            
            // var accs = accountRep.GetAll();
            // foreach (var acc in accs)
            // {
            //     Console.WriteLine($"{acc.Id}, {acc.Login}, {acc.Password}, {acc.Role}");
            // }
            
            // accountRep.Delete(7);
            
            // accs = accountRep.GetAll();
            // foreach (var acc in accs)
            // {
            //     Console.WriteLine($"{acc.Id}, {acc.Login}, {acc.Password}, {acc.Role}");
            // }
        }
    }
}
