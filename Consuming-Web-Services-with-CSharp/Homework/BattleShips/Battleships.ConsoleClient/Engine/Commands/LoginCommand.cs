namespace Battleships.ConsoleClient.Engine.Commands
{
    using System;
    using Exceptions;
    using Interfaces;
    using Models;
    using Utilities;

    public class LoginCommand : Command
    {
        public LoginCommand(IGameEngine gameEngine)
            : base(gameEngine)
        {
        }

        public async override void Execute(string[] parameters)
        {
            try
            {
                LoginDataDTO loginData = await this.GameEngine.Requester.LoginUser(parameters);
                string formattedResult = string.Format(MessageConstants.SuccessfulLogin, loginData.UserName);

                this.Print(string.Format(" -{0}", formattedResult));
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
