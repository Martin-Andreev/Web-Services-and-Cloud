namespace Battleships.ConsoleClient.Engine
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Exceptions;
    using Interfaces;
    using Models;
    using Utilities;

    public class Requester : IRequester
    {
        private const string BaseUrl = RequesterUrlConstants.BaseUrl;

        private readonly HttpClient httpClient;
        private string accessToken;

        public Requester()
        {
            this.httpClient = new HttpClient();
        }

        public async Task<RegisterDataDTO> RegisterUser(string[] parameters)
        {
            const string registrationEndpoint = BaseUrl + RequesterUrlConstants.RegistrationPath;

            var email = parameters[0];
            var password = parameters[1];
            var confirmPassword = parameters[2];
            var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("email", email),
                    new KeyValuePair<string, string>("password", password),
                    new KeyValuePair<string, string>("confirmPassword", confirmPassword)
                });

            var response = await this.httpClient.PostAsync(registrationEndpoint, content);
            await this.ValiadteResponse(response);

            RegisterDataDTO registerData = new RegisterDataDTO
            {
                Email = email
            };

            return registerData;

        }

        public async Task<LoginDataDTO> LoginUser(string[] parameters)
        {
            const string loginEndpoint = BaseUrl + RequesterUrlConstants.TokenUrl;

            var username = parameters[0];
            var password = parameters[1];
            var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("username", username),
                    new KeyValuePair<string, string>("password", password),
                    new KeyValuePair<string, string>("grant_type", "password")
                });

            var response = await this.httpClient.PostAsync(loginEndpoint, content);
            await this.ValiadteResponse(response);

            var loginData = response.Content.ReadAsAsync<LoginDataDTO>().Result;
            this.accessToken = loginData.AccessToken;

            return loginData;

        }

        public async Task<string> CreateGame()
        {
            const string createGameEndpoint = BaseUrl + RequesterUrlConstants.CreateGamePath;

            this.AddAuthorizationHeaderIfNotExist();

            var response = await this.httpClient.PostAsync(createGameEndpoint, null);
            await this.ValiadteResponse(response);

            string createdGameId = response.Content.ReadAsAsync<string>().Result;

            return createdGameId;
        }

        public async Task<IEnumerable<AvailableGamesDTO>> AvailableGames()
        {
            const string availableGamesEndpoint = BaseUrl + RequesterUrlConstants.AvailableGamesPath;

            this.AddAuthorizationHeaderIfNotExist();

            var response = await this.httpClient.GetAsync(availableGamesEndpoint);
            await this.ValiadteResponse(response);

            var availableGames = response.Content.ReadAsAsync<IEnumerable<AvailableGamesDTO>>().Result;

            return availableGames;
        }

        public async Task<string> JoinGame(string[] parameters)
        {
            const string joinGameEndpoint = BaseUrl + RequesterUrlConstants.JoinGamePath;

            this.AddAuthorizationHeaderIfNotExist();

            string gameId = parameters[0];
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("GameId", gameId)
            });

            var response = await this.httpClient.PostAsync(joinGameEndpoint, content);
            await this.ValiadteResponse(response);

            return gameId;
        }

        public async Task<string> GameStatus(string gameId)
        {
            const string gameStatusEndpoint = BaseUrl + RequesterUrlConstants.Status;

            this.AddAuthorizationHeaderIfNotExist();

            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("GameId", gameId)
            });

            var response = await this.httpClient.PostAsync(gameStatusEndpoint, content);
            await this.ValiadteResponse(response);

            var status = response.Content.ReadAsAsync<string>().Result;

            return status;
        }

        public async Task<PlayDTO> Play(string[] parameters)
        {
            const string playEndpoint = BaseUrl + RequesterUrlConstants.Play;

            string gameId = parameters[0];
            string positionX = parameters[1];
            string positionY = parameters[2];

            this.AddAuthorizationHeaderIfNotExist();

            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("GameId", gameId), 
                new KeyValuePair<string, string>("PositionX", positionX), 
                new KeyValuePair<string, string>("PositionY", positionY), 
            });

            var response = await this.httpClient.PostAsync(playEndpoint, content);
            await this.ValiadteResponse(response);
            
            PlayDTO responseData = new PlayDTO()
            {
                PositionX = positionX,
                PositionY = positionY
            };

            return responseData;
        }

        private void AddAuthorizationHeaderIfNotExist()
        {
            if (this.httpClient.DefaultRequestHeaders.Contains("Authorization"))
            {
                this.httpClient.DefaultRequestHeaders.Remove("Authorization");
            }

            this.httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + this.accessToken);
        }

        private async Task ValiadteResponse(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                throw ApiException.Build(response);
            }
        }
    }
}