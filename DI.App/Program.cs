using System;
using System.Linq;
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

            services.AddSingleton<IUser, User>();
            services.AddSingleton<IDatabaseService, InMemoryDatabaseService>();
            services.AddSingleton<IUserStore, UserStore>();
            services.AddSingleton<ICommand, AddUserCommand>();
            services.AddSingleton<ICommand, ListUsersCommand>();
            services.AddSingleton<ICommandProcessor, CommandProcessor>(provider =>
                new CommandProcessor(provider.GetServices<ICommand>().ToDictionary(c => c.Number)));
            services.AddSingleton<ICommandManager, CommandManager>();
            
            IServiceProvider serviceProvider = services.BuildServiceProvider();
            
            var manager = serviceProvider.GetService<ICommandManager>();
            
            manager.Start();
        }
    }
}