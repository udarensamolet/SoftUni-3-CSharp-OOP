using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CommandPattern.Core.Models
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private const string CommandSufix = "Command";
        public string Read(string args)
        {
            List<string> tokens = args
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string commandName = tokens[0];
            tokens.RemoveAt(0);
            string[] commandArgs = tokens.ToArray();

            Type commandType = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(x => x.Name == $"{commandName}{CommandSufix}");
            ICommand command = (ICommand)Activator.CreateInstance(commandType);
            string result = command.Execute(commandArgs);
            return result;
        }
    }
}
