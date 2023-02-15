using ProLobbyCompanyProject.Model.MoneyTracking;
using System;
using System.Collections.Generic;
using Utilities.Logger;

namespace ProLobbyCompanyProject.Entites.Commands.MoneyTracking
{
    public class MGetDataMoney: BaseCommands,ICommand
    {
        public MGetDataMoney(Logger logger) : base(logger) { }


        /// <summary>
        /// Receiving details from a money tracking table with social activist ID.
        /// </summary>
        /// <param name="argv">Activist Id</param>
        /// <returns>The details related to money tracking.</returns>
        public object Execute(params object[] argv)
        {
            foreach (var item in argv)
            {
                if (item is string)
                {
                    string userId = (string)item;

                    List<MAMoneyTracking> ListMoneyTracking = MainManager.INSTANCE.SocialActivists.GetMoneyData(userId);

                    string responseMessageList = System.Text.Json.JsonSerializer.Serialize(ListMoneyTracking);

                    Console.WriteLine(responseMessageList);

                    base.Logger.LogEvent("Receiving the data if it exists was done successfully in MGetDataMoney.");
                    return responseMessageList;
                }
            }

            base.Logger.LogError("\nFailed to get the data if it exists, the active Id was not received.\n");
            return null; 
        }
        public void Init() { }
    }
}
