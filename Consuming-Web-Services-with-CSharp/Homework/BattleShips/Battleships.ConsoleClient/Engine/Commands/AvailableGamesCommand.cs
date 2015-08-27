namespace Battleships.ConsoleClient.Engine.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using Exceptions;
    using Interfaces;
    using Models;
    using Utilities;

    public class AvailableGamesCommand : Command
    {
        public AvailableGamesCommand(IGameEngine gameEngine)
            : base(gameEngine)
        {
        }

        public async override void Execute(string[] commandArgs)
        {
            try
            {
                IEnumerable<AvailableGamesDTO> availableGamesData = await this.GameEngine.Requester.AvailableGames();

                if (availableGamesData.Any())
                {
                    this.Print(string.Format(" -{0}", MessageConstants.AvailableGames));
                    foreach (var game in availableGamesData)
                    {
                        this.Print(string.Format("  {0}", game));
                    }
                }
                else
                {
                    this.Print(MessageConstants.NotAvailableGames);
                }
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
