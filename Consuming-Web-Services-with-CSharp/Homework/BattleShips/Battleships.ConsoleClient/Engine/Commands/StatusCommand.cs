namespace Battleships.ConsoleClient.Engine.Commands
{
    using Interfaces;

    public class StatusCommand : Command
    {
        public StatusCommand(IGameEngine gameEngine)
            : base(gameEngine)
        {
        }

        public override void Execute(string[] parameters)
        {
            string gameId = parameters[0];

            this.Status(gameId);
        }
    }
}
