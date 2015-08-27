namespace Battleships.ConsoleClient.Utilities
{
    public static class RequesterUrlConstants
    {
        public const string BaseUrl = "http://localhost:62858/";
        
        public const string TokenUrl = "Token";

        public const string RegistrationPath = "api/Account/Register";

        public const string CreateGamePath = "api/Games/create";

        public const string AvailableGamesPath = "api/Games/available";

        public const string JoinGamePath = "api/Games/join";

        public const string Play = "api/Games/play";

        public const string Status = "api/Games/status";
    }
}
