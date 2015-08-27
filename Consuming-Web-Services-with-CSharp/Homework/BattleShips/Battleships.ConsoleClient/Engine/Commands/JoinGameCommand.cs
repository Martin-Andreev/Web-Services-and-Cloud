namespace Battleships.ConsoleClient.Engine.Commands
{
    using System;
    using System.Net.Http;
    using Exceptions;
    using Interfaces;
    using Utilities;

    public class JoinGameCommand : Command
    {
        public JoinGameCommand(IGameEngine gameEngine)
            : base(gameEngine)
        {
        }

        public async override void Execute(string[] parameters)
        {
            try
            {
                string joinedGameId = await this.GameEngine.Requester.JoinGame(parameters);

                this.Status(joinedGameId);
            }
            catch (ApiException ex)
            {
                foreach (var error in ex.Errors)
                {
                    this.Print(string.Format(MessageConstants.ErrorMessage, error));
                }
            }
            catch (IndexOutOfRangeException ex)
            {
                this.Print(string.Format(MessageConstants.ErrorMessage, ex.Message));
            }
        }
    }
}
