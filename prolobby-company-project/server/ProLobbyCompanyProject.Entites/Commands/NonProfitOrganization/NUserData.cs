using ProLobbyCompanyProject.Model;
using System;
using System.Collections.Generic;
using Utilities.Logger;

namespace ProLobbyCompanyProject.Entites.Commands.NonProfitOrganization
{
    public class NUserData: BaseCommands,ICommand
    {
        public NUserData(Logger logger) : base(logger) { }

        /// <summary>
        /// Checks if the organization representative user exists
        /// </summary>
        /// <param name="argv">Id organization representative </param>
        /// <returns>If it exists returns the details if not returns null</returns>
        public object Execute(params object[] argv)
        {
            foreach (var item in argv)
            {
                if (item is string)
                {
                    string userId = (string)item;
                    List<TBNonProfitOrganization> ListNonProfitOrganization = MainManager.INSTANCE.NonProfitOrganizations.CheckingIfExistUser(userId);

                    string responseMessage = System.Text.Json.JsonSerializer.Serialize(ListNonProfitOrganization);

                    base.Logger.LogEvent("The operation of checking if an organization representative exists was successfully performed in NUserData.");

                    return responseMessage;
                }
            }

            base.Logger.LogError("\nThe operation of checking if an organization representative exists failed, the Id of the organization representative was not received in NUserData.\n");

            return null;
        }
        public void Init() { }
    }
}
