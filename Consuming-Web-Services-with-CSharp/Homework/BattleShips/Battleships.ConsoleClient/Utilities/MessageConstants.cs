namespace Battleships.ConsoleClient.Utilities
{
    public static class MessageConstants
    {
        public const string WelcomeMessage = "------ Welcome to Battleship Game -------";

        public const string SuccessfullyRegisteredUser = "User {0} successfully registered.";
        public const string SuccessfulLogin = "User {0} successfully logged in.";
        public const string SuccessfullyCreatedNewGame = "New game with id: '{0}' has been successfully created.";

        public const string AvailableGames = "Available games:";
        public const string NotAvailableGames = "There are no available games. Please, try again later.";

        public const string SuccessfullyBombed = "Successfully bombed at position {0} {1}";

        public const string ErrorMessage = "--EROR-- {0}";

        public const string RegisterCommand = "register - registers new user. ---> /email password confirm password/";
        public const string LoginCommand = "login - logs in existing user. ---> /username password/";
        public const string CreateGameCommand = "create-game - creates new game.";
        public const string AvailableGamesCommand = "available-games - shows all available games.";
        public const string JoinGameCommand = "join-game - joins player to existing game. ---> /game id/";
        public const string PlayCommand = "play - makes movement to selected position. ---> /game id position x position y/";
        public const string StatusCommand = "status - shows game field. ---> /game id/";
        public const string OverCommand = "over - exists the program.";
        public const string ShowCommandsCommand = "commands - shows all commands.";

        public const string EndOfTheGame = "Goodbye";
    }
}
