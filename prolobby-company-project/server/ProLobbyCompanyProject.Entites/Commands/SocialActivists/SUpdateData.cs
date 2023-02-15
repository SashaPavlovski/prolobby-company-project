using ProLobbyCompanyProject.Model;
using System;
using Utilities.Logger;

namespace ProLobbyCompanyProject.Entites.Commands.SocialActivists
{
    public class SUpdateData: BaseCommands,ICommand
    {
        public SUpdateData(Logger logger) : base(logger) { }

        /// <summary>
        /// Updating data of a social activist.
        /// </summary>
        /// <param name="argv">Data of a social activist with the new ones.</param>
        /// <returns>If operation was performed successfully or failed.</returns>
        public object Execute(params object[] argv)
        {
            foreach (var item in argv)
            {
                if (item is TBSocialActivists)
                {
                    TBSocialActivists UserActivistsData = item as TBSocialActivists;

                    if (UserActivistsData.SocialActivists_Id != 0 && UserActivistsData.FirstName != null && UserActivistsData.LastName != null && UserActivistsData.Email != null && UserActivistsData.Phone_number != null && UserActivistsData.Address != null && UserActivistsData.Twitter_user != null)
                    {
                        MainManager.INSTANCE.SocialActivists.UpdateActivist(UserActivistsData);

                        base.Logger.LogEvent("The data update operation was performed successfully in SUpdateData.");

                        return "The operation was successful";
                    }

                }
            }

            base.Logger.LogError("\nThe data update operation failed, the data is not valid in SUpdateData.\n");

            return "The operation failed";
        }
        public void Init() { }
    }
}
