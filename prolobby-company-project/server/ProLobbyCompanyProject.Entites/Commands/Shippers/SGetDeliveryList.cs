using ProLobbyCompanyProject.Model.Shippers;
using System;
using System.Collections.Generic;
using Utilities.Logger;

namespace ProLobbyCompanyProject.Entites.Commands.Shippers
{
    public class SGetDeliveryList: BaseCommands,ICommand
    {
        public SGetDeliveryList(Logger logger) : base(logger) { }

        /// <summary>
        /// Receiving the data on the products bought
        /// </summary>
        /// <param name="argv"></param>
        /// <returns>List of data on the products bought.</returns>
        public object Execute(params object[] argv)
        {
            List<MADeliveryProductList> deliveryProductList = MainManager.INSTANCE.BusinessCompanyRepresentatives.GetDeliveryList();

            string responseMessageDL = System.Text.Json.JsonSerializer.Serialize(deliveryProductList);

            Console.WriteLine(responseMessageDL);

            base.Logger.LogEvent("The operation of receiving the purchase data of the products was carried out successfully in SGetDeliveryList");

            return responseMessageDL;
        }
        public void Init() { }
    }
}
