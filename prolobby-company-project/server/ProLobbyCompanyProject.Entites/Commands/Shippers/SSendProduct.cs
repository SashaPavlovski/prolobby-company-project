using System;
using Utilities.Logger;

namespace ProLobbyCompanyProject.Entites.Commands.Shippers
{
    public class SSendProduct: BaseCommands,ICommand
    {
        public SSendProduct(Logger logger) : base(logger) { }

        /// <summary>
        /// Product shipping update.
        /// </summary>
        /// <param name="argv">Activist Id</param>
        /// <returns>If the operation succeeded or failed.</returns>
        public object Execute(params object[] argv)
        {
            foreach (var item in argv)
            {
                if (item is string)
                {
                    string userId = (string)item;

                    MainManager.INSTANCE.BusinessCompanyRepresentatives.SetProductDelivery(userId);

                    base.Logger.LogEvent("Update The sending products was done successfully in SSendProduct.");

                    return "Succeeded";
                }
            }

            base.Logger.LogError("\nUpdate The sending products failed, Activist Id Invalid in SSendProduct.\n");

            return null;
        }
        public void Init() { }
    }
}
