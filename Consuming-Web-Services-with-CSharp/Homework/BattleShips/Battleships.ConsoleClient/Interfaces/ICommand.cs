namespace Battleships.ConsoleClient.Interfaces
{
    using Engine;

    public interface ICommand
    {
        IGameEngine GameEngine { get; set; }

        void Execute(string[] commandArgs);
    }
}
