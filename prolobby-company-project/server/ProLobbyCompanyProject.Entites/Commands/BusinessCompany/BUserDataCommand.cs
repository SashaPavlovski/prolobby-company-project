using ProLobbyCompanyProject.Model;
using System;
using System.Collections.Generic;
using Utilities.Logger;

namespace ProLobbyCompanyProject.Entites.Commands.BusinessCompany
{
    public class BUserDataCommand: BaseCommands,ICommand
    {
        public BUserDataCommand(Logger logger) : base(logger) { }

        /// <summary>
        /// User login with enter details,
        /// Checks if the user exists.
        /// </summary>
        /// <param name="argv"> Receiving a thesis of the company representative and checking whether it exists. </param>
        /// <returns>  Null if there is no such representative in another system returns his details. </returns>
        public object Execute (params object[] argv)
        {
            foreach (var item in argv)
            {
                if (item is string)
                {
                    string userId = (string)item;

                    List<TBBusinessCompanyRepresentative> ListBusinessCompany = MainManager.INSTANCE.BusinessCompanyRepresentatives.CheckingIfExistUser(userId);

                    string responseMessageLB = System.Text.Json.JsonSerializer.Serialize(ListBusinessCompany);

                    Console.WriteLine(responseMessageLB);

                    base.Logger.LogEvent("The action of checking whether the company representative exists was successfully carried out, in BUserDataCommand.");

                    return responseMessageLB;
                }
            }

            base.Logger.LogError("\nThe operation of checking whether the company representative exists failed in BUserDataCommand.\n");

            return null;
        }

        public void Init()
        {

        }
    }
}
