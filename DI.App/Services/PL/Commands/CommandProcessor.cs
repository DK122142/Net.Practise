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

        public CommandProcessor(Dictionary<int, ICommand> commands)
        {
            this.commands = commands;
        }

        public void Process(int number)
        {
            if (!this.commands.TryGetValue(number, out var command)) return;

            command.Execute();
        }

        public IEnumerable<ICommand> Commands => this.commands.Values.AsEnumerable();
    }
}