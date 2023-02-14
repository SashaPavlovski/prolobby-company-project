using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProLobbyCompanyProject.Entites.Commands
{
    public interface ICommand
    {
        object Execute(params object[] argv);
        void Init();

    }
    public class BaseCommands
    {
    }
}
