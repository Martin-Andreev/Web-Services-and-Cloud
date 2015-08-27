namespace Battleships.ConsoleClient.Engine.Commands
{
    using System;
    using Exceptions;
    using Interfaces;
    using Models;
    using Utilities;

    public class RegisterCommand : Command
    {
        public RegisterCommand(IGameEngine gameEngine)
            : base(gameEngine)
        {
        }

        public async override void Execute(string[] parameters)
        {
            try
            {
                RegisterDataDTO registerData = await this.GameEngine.Requester.RegisterUser(parameters);
                string formattedResult = string.Format(MessageConstants.SuccessfullyRegisteredUser, registerData.Email);

                this.Print(string.Format(" -{0}", formattedResult));
            
            }
            catch (ApiException ex)
            {
                foreach (var error in ex.Errors)
                {
                    this.Print(string.Format(MessageConstants.ErrorMessage, error));
                }
            }
            catch(IndexOutOfRangeException ex)
            {
                this.Print(string.Format(MessageConstants.ErrorMessage, ex.Message));
            }
        }
    }
}
