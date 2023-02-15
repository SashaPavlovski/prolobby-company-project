using ProLobbyCompanyProject.Model;
using System;
using System.Collections.Generic;
using Utilities.Logger;

namespace ProLobbyCompanyProject.Entites.Commands.SocialActivists
{
    public class SUserData: BaseCommands,ICommand
    {
        public SUserData(Logger logger) : base(logger) { }

        /// <summary>
        /// Checking with a social activist already exists.
        /// </summary>
        /// <param name="argv">Social activist Id</param>
        /// <returns>If it exists returns the details if not returns null</returns>
        public object Execute(params object[] argv)
        {
            foreach (var item in argv)
            {
                if (item is string)
                {
                    string userId = (string)item;

                    List<TBSocialActivists> ListSocialActivists = MainManager.INSTANCE.SocialActivists.CheckingIfExistUser(userId);

                    string responseMessageSA = System.Text.Json.JsonSerializer.Serialize(ListSocialActivists);

                    Console.WriteLine(responseMessageSA);


                    base.Logger.LogEvent("The test operation was performed successfully in SUserData.");

                    return responseMessageSA;
                }
            }

            base.Logger.LogError("\nThe test operation failed, the Id is not valid in SUserData.\n");
            
            return null;
        }
        public void Init() { }
    }
}
