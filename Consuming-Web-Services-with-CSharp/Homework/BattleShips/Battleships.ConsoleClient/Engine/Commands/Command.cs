namespace Battleships.ConsoleClient.Engine.Commands
{
    using Interfaces;

    public abstract class Command : ICommand
    {
        protected Command(IGameEngine gameEngine)
        {
            this.GameEngine = gameEngine;
        }

        public IGameEngine GameEngine { get; set; }

        public abstract void Execute(string[] commandArgs);

        public void Print(string parameter)
        {
            this.GameEngine.UserInterface.WriteLine(parameter);
        }

        public async void Status(string gameId)
        {
            this.Print(string.Empty);
            this.GameEngine.UserInterface.Write("\t");

            string status = await this.GameEngine.Requester.GameStatus(gameId);
            for (int i = 1; i <= status.Length; i++)
            {
                this.GameEngine.UserInterface.Write(status[i - 1] + " ");
                if (i % 8 == 0)
                {
                    this.GameEngine.UserInterface.WriteLine(string.Empty);
                    this.GameEngine.UserInterface.Write("\t");
                }
            }

            this.Print(string.Empty);
        }
    }
}
