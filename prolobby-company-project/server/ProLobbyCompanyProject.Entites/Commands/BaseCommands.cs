using Utilities.Logger;

namespace ProLobbyCompanyProject.Entites.Commands
{
    public interface ICommand
    {
        object Execute(params object[] argv);
        void Init();

    }
    public class BaseCommands
    {
        public Logger Logger;
        public BaseCommands(Logger logger) 
        {
            Logger = logger;
        }
    }
}
