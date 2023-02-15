using ProLobbyCompanyProject.Model;
using System;
using System.Collections.Generic;
using Utilities.Logger;

namespace ProLobbyCompanyProject.Entites.Commands.DonatedProducts
{
    public class DGetData: BaseCommands,ICommand
    {
        public DGetData(Logger logger) : base(logger) { }

        /// <summary>
        /// Receiving the products of a certain campaign according to ID.
        /// </summary>
        /// <param name="argv">Campaign Id</param>
        /// <returns>Products donated to a specific campaign, If not null is returned.</returns>
        public object Execute(params object[] argv)
        {
            foreach (var item in argv)
            {
                if (item is string)
                {
                    string userId = (string)item;   

                    List<TBDonatedProducts> ListDonatedProducts = MainManager.INSTANCE.BusinessCompanyRepresentatives.GetCampaignProducts(userId);

                    string responseMessageNP = System.Text.Json.JsonSerializer.Serialize(ListDonatedProducts);

                    Console.WriteLine(responseMessageNP);

                    base.Logger.LogEvent("The operation of receiving the products of a certain campaign was carried out successfully in DGetData.");

                    return responseMessageNP;
                }
            }

            base.Logger.LogError("\nThe operation of receiving the products of a certain campaign failed, no campaign id was received\n");

            return null;
        }
        public void Init() { }
    }
}
