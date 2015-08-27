namespace Battleships.ConsoleClient.Interfaces
{
    public interface IUserInterface
    {
        string ReadLine();

        void Write(string message);

        void WriteLine(string message);
    }
}
