namespace Battleships.ConsoleClient.Engine.Commands
{
    using System;
    using System.Net.Http;
    using Exceptions;
    using Interfaces;
    using Models;
    using Utilities;

    public class PlayCommand : Command
    {
        public PlayCommand(IGameEngine gameEngine)
            : base(gameEngine)
        {
        }

        public async override void Execute(string[] parameters)
        {
            try
            {
                PlayDTO responseData = await this.GameEngine.Requester.Play(parameters);
                string formattedResult = string.Format(
                    MessageConstants.SuccessfullyBombed, responseData.PositionX, responseData.PositionY);

                this.Print(formattedResult);
                this.Status(parameters[0]);
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
