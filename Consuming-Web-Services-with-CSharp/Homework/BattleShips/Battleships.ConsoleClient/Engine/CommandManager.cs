namespace Battleships.ConsoleClient.Engine
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Commands;
    using Interfaces;

    public class CommandManager : ICommandManager
    {
        public CommandManager()
        {
            this.CommandsByName = new Dictionary<string, Command>();
        }

        public IGameEngine Engine { get; set; }

        public IDictionary<string, Command> CommandsByName { get; set; } 

        public void ProcessCommand(string commandLine)
        {
            string[] arguments = commandLine.Split(' ');
            
            string commandName = arguments[0];
            string[] parameters = arguments.Skip(1).ToArray();

            if (!this.CommandsByName.ContainsKey(commandName))
            {
                throw new NotSupportedException(string.Format(
                    "Command {0} does not exist.", commandName));
            }

            var command = this.CommandsByName[commandName];
            command.Execute(parameters);
        }

        public virtual void SeedCommands()
        {
            this.CommandsByName["register"] = new RegisterCommand(this.Engine);
            this.CommandsByName["login"] = new LoginCommand(this.Engine);
            this.CommandsByName["create-game"] = new CreateGameCommand(this.Engine);
            this.CommandsByName["available-games"] = new AvailableGamesCommand(this.Engine);
            this.CommandsByName["join-game"] = new JoinGameCommand(this.Engine);
            this.CommandsByName["play"] = new PlayCommand(this.Engine);
            this.CommandsByName["status"] = new StatusCommand(this.Engine);
            this.CommandsByName["over"] = new OverCommand(this.Engine);
            this.CommandsByName["commands"] = new ShowCommandsCommand(this.Engine);
        }
    }
}
