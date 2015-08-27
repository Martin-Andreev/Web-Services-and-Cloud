namespace Battleships.ConsoleClient.Engine
{
    using System;
    using Interfaces;
    using Utilities;

    public class GameEngine : IGameEngine
    {      
        public GameEngine(IUserInterface userInterface, ICommandManager commandManager, IRequester requester)
        {
            this.UserInterface = userInterface;
            this.CommandManager = commandManager;
            this.Requester = requester;
        }

        public IRequester Requester { get; set; }

        public ICommandManager CommandManager { get; set; }

        public IUserInterface UserInterface { get; set; }

        public bool IsRunning { get; set; }

        public void Run()
        {
            this.IsRunning = true;
            this.CommandManager.Engine = this;
            this.CommandManager.SeedCommands();
            this.PrintWelcomeMessage();
            this.ShowAllCommands();
            do
            {
                string commandLine = this.UserInterface.ReadLine();
                try
                {
                    this.CommandManager.ProcessCommand(commandLine);
                }
                catch (Exception ex)
                {
                    this.UserInterface.WriteLine(ex.Message);
                }
            } while (IsRunning);
        }

        private void ShowAllCommands()
        {
            const string command = "commands";
            this.CommandManager.ProcessCommand(command);
            this.UserInterface.WriteLine(string.Empty);
        }

        private void PrintWelcomeMessage()
        {
            this.UserInterface.WriteLine(MessageConstants.WelcomeMessage);
            this.UserInterface.WriteLine(string.Empty);
        }
    }
}
