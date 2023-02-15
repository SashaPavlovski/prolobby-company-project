using ProLobbyCompanyProject.Model;
using System;
using System.Collections.Generic;
using Utilities.Logger;

namespace ProLobbyCompanyProject.Entites.Commands.ProLobbyOwner
{
    public class PUserData: BaseCommands,ICommand
    {
        public PUserData(Logger logger) : base(logger) { }

        /// <summary>
        /// Check with the owner already exists
        /// </summary>
        /// <param name="argv">Owner Id</param>
        /// <returns>If it exists returns the details if not returns null</returns>
        public object Execute(params object[] argv)
        {
            foreach (var item in argv)
            {
                if (item is string)
                {
                    string userId = (string)item;

                    List<TBProLobbyOwner> ListProLobbyOwner = MainManager.INSTANCE.ProLobbyOwner.CheckingIfExistUser(userId);
                    string responseMessagePO = System.Text.Json.JsonSerializer.Serialize(ListProLobbyOwner);
                    Console.WriteLine(responseMessagePO);

                    base.Logger.LogEvent("The test operation was performed successfully in PUserData.");

                    return responseMessagePO;
                }
            }

            base.Logger.LogError("\nThe test operation failed, the Id is not valid in PUserData.\n");

            return null;
        }
        public void Init() { }
    }
}
