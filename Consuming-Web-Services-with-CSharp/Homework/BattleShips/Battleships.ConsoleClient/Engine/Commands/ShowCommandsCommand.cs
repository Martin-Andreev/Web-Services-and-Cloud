namespace Battleships.ConsoleClient.Engine.Commands
{
    using Interfaces;
    using Utilities;

    public class ShowCommandsCommand : Command
    {
        public ShowCommandsCommand(IGameEngine gameEngine)
            : base(gameEngine)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            this.Print("Game commands:");

            this.GameEngine.UserInterface.WriteLine(string.Format(" -{0}", MessageConstants.RegisterCommand));
            this.GameEngine.UserInterface.WriteLine(string.Format(" -{0}", MessageConstants.LoginCommand));
            this.GameEngine.UserInterface.WriteLine(string.Format(" -{0}", MessageConstants.AvailableGamesCommand));
            this.GameEngine.UserInterface.WriteLine(string.Format(" -{0}", MessageConstants.CreateGameCommand));
            this.GameEngine.UserInterface.WriteLine(string.Format(" -{0}", MessageConstants.JoinGameCommand));
            this.GameEngine.UserInterface.WriteLine(string.Format(" -{0}", MessageConstants.PlayCommand));
            this.GameEngine.UserInterface.WriteLine(string.Format(" -{0}", MessageConstants.StatusCommand));
            this.GameEngine.UserInterface.WriteLine(string.Format(" -{0}", MessageConstants.OverCommand));
            this.GameEngine.UserInterface.WriteLine(string.Format(" -{0}", MessageConstants.ShowCommandsCommand));
        }
    }
}
