using ProLobbyCompanyProject.Model;
using System;
using System.Collections.Generic;
using Utilities.Logger;

namespace ProLobbyCompanyProject.Entites.Commands.Shippers
{
    public class SGetProductById: BaseCommands,ICommand
    {
        public SGetProductById(Logger logger) : base(logger) { }

        /// <summary>
        /// Receiving all the products bought by one social activist,
        /// With receiving the activist id.
        /// </summary>
        /// <param name="argv">Activist id</param>
        /// <returns>All the products bought by one social activist.</returns>
        public object Execute(params object[] argv)
        {
            foreach (var item in argv)
            {
                if (item is string)
                {
                    string userId = (string)item;

                    List<TBDonatedProducts> ListDonatedProducts = MainManager.INSTANCE.BusinessCompanyRepresentatives.GetByUserIdProducts(userId);

                    string responseMessageNP = System.Text.Json.JsonSerializer.Serialize(ListDonatedProducts);

                    Console.WriteLine(responseMessageNP);

                    base.Logger.LogEvent("The receipt of the products bought by a social activist was done successfully in SGetProductById.");

                    return responseMessageNP;
                }

            }

            base.Logger.LogError("\nThe receipt of the products bought by a social activist failed, Activist Id Invalid in SGetProductById.\n");

            return null;
        }
        public void Init() { }
    }
}
