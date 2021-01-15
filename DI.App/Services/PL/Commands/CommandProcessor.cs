using System.Collections.Generic;
using System.Linq;
using DI.App.Abstractions;
using DI.App.Abstractions.BLL;
using DI.App.Services.PL.Commands;

namespace DI.App.Services.PL
{
    public class CommandProcessor : ICommandProcessor
    {
        private readonly Dictionary<int, ICommand> commands;

        public CommandProcessor(IUserStore userStore)
        {
            commands = new Dictionary<int, ICommand>();

            var addUser = new AddUserCommand(userStore);
            var listUsers = new ListUsersCommand(userStore);
            
            commands.Add(addUser.Number, addUser);
            commands.Add(listUsers.Number, listUsers);
        }

        public void Process(int number)
        {
            if (!this.commands.TryGetValue(number, out var command)) return;

            command.Execute();
        }

        public IEnumerable<ICommand> Commands => this.commands.Values.AsEnumerable();
    }
}