namespace Battleships.ConsoleClient
{
    using Engine;
    using Interfaces;
    using UserInterface;

    public class BattleshipProgram
    {
        public static void Main()
        {
            ICommandManager commandManager = new CommandManager();
            IUserInterface userInterface = new ConsoleInterface();
            IRequester requester = new Requester();
           
            var engine = new GameEngine(userInterface, commandManager, requester);
            engine.Run();
        }
    }
}
