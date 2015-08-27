namespace Battleships.ConsoleClient.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Models;

    public interface IRequester
    {
        Task<RegisterDataDTO> RegisterUser(string[] parameters);

        Task<LoginDataDTO> LoginUser(string[] parameters);

        Task<string> CreateGame();

        Task<IEnumerable<AvailableGamesDTO>> AvailableGames();

        Task<string> JoinGame(string[] parameters);

        Task<string> GameStatus(string gameId);

        Task<PlayDTO> Play(string[] parameters);
    }
}
