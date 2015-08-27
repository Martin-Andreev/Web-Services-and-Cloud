namespace Battleships.ConsoleClient.Models
{
    using Newtonsoft.Json;

    public class AvailableGamesDTO
    {
        [JsonProperty(PropertyName = "Id")]
        public string GameId { get; set; }

                [JsonProperty(PropertyName = "PlayerOne")]
        public string PlayerOneName { get; set; }

        public override string ToString()
        {
            return string.Format("Game id: {0}. Player name: {1}", this.GameId, this.PlayerOneName);
        }
    }
}
