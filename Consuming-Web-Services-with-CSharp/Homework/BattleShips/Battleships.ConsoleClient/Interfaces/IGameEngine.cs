namespace Battleships.ConsoleClient.Interfaces
{
    public interface IGameEngine
    {
        ICommandManager CommandManager { get; set; }

        IUserInterface UserInterface { get; set; }

        IRequester Requester { get; set; }

        bool IsRunning { get; set; }

        void Run();
    }
}
