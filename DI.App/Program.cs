using System;
using DI.App.Abstractions;
using DI.App.Abstractions.BLL;
using DI.App.Abstractions.PL;
using DI.App.Models;
using DI.App.Services;
using DI.App.Services.PL;
using DI.App.Services.PL.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace DI.App
{
    internal class Program
    {
        private static void Main()
        {
            IServiceCollection services = new ServiceCollection();
            
            services.AddTransient<IUser, User>();
            services.AddTransient<IDatabaseService, InMemoryDatabaseService>();
            services.AddTransient<IUserStore, UserStore>();
            services.AddTransient<ICommand, AddUserCommand>();
            services.AddTransient<ICommand, ListUsersCommand>();
            services.AddTransient<ICommandProcessor, CommandProcessor>();
            services.AddTransient<ICommandManager, CommandManager>();
            
            IServiceProvider serviceProvider = services.BuildServiceProvider();
            
            var manager = serviceProvider.GetService<ICommandManager>();
            
            manager.Start();
        }
    }
}