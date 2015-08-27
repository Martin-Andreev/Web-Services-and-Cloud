namespace Battleships.ConsoleClient.Engine.Commands
{
    using System;
    using System.Net.Http;
    using Exceptions;
    using Interfaces;
    using Utilities;

    public class CreateGameCommand : Command
    {
        public CreateGameCommand(IGameEngine gameEngine)
            : base(gameEngine)
        {
        }

        public async override void Execute(string[] parameters)
        {
            try
            {
                string createdGameId = await this.GameEngine.Requester.CreateGame();
                string commandResult = string.Format(MessageConstants.SuccessfullyCreatedNewGame, createdGameId);

                this.Print(string.Format(" -{0}", commandResult));
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
