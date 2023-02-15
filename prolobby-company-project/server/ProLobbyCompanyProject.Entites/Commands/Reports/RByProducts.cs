using ProLobbyCompanyProject.Model.SortingTables.SortingProducts;
using System;
using System.Collections.Generic;
using Utilities.Logger;

namespace ProLobbyCompanyProject.Entites.Commands.Reports
{
    public class RByProducts: BaseCommands,ICommand
    {
        public RByProducts(Logger logger) : base(logger) { }

        /// <summary>
        /// Sorting the reports of the products.
        /// </summary>
        /// <param name="argv">Sorting options Id</param>
        /// <returns>The product report sorted by the Id.</returns>
        public object Execute(params object[] argv)
        {
            foreach (var item in argv)
            {
                if (item is string)
                {
                    string userId = (string)item;
                    
                    List<TBSortingProducts> ListSortingProducts = MainManager.INSTANCE.BusinessCompanyRepresentatives.GetSortingProducts(userId);

                    string responseProductsList = System.Text.Json.JsonSerializer.Serialize(ListSortingProducts);

                    Console.WriteLine(responseProductsList);

                    base.Logger.LogEvent("The operation of sorting the products reports was carried out successfully in RByUsers");

                    return responseProductsList;
                }
            }

            base.Logger.LogError("\nThe products report sorting operation failed, no sorting option was received in RByUsers.\n");

            return null;
        }
        public void Init() { }
    }
}
