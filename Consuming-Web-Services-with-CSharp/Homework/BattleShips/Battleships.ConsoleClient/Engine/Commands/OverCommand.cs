namespace Battleships.ConsoleClient.Engine.Commands
{
    using Interfaces;
    using Utilities;

    public class OverCommand : Command
    {
        public OverCommand(IGameEngine gameEngine)
            : base(gameEngine)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            this.GameEngine.IsRunning = false;

            this.Print(MessageConstants.EndOfTheGame);
        }
    }
}
