namespace Battleships.ConsoleClient.Interfaces
{
    using System.Collections.Generic;
    using Engine.Commands;

    public interface ICommandManager
    {
        IGameEngine Engine { get; set; }

        IDictionary<string, Command> CommandsByName { get; set; } 

        void ProcessCommand(string commandLine);

        void SeedCommands();
    }
}
