using ProLobbyCompanyProject.Model;
using System;
using Utilities.Logger;

namespace ProLobbyCompanyProject.Entites.Commands.ProLobbyOwner
{
    internal class PUpdateData: BaseCommands,ICommand
    {
        public PUpdateData(Logger logger) : base(logger) { }

        /// <summary>
        /// Updating the owner's data.
        /// </summary>
        /// <param name="argv">The owner's data with the new ones.</param>
        /// <returns>If operation was performed successfully or failed.</returns>
        public object Execute(params object[] argv)
        {
            foreach (var item in argv)
            {
                if (item is TBProLobbyOwner)
                {
                    TBProLobbyOwner UserOwnerData = (TBProLobbyOwner)item;

                    if (UserOwnerData.ProLobbyOwner_Id != 0 && UserOwnerData.FirstName != null && UserOwnerData.LastName != null && UserOwnerData.Email != null && UserOwnerData.Phone_number != null)
                    {
                        MainManager.INSTANCE.ProLobbyOwner.UpdateUsersOwner(UserOwnerData);

                        base.Logger.LogEvent("The data update operation was performed successfully in PUpdateData.");

                        return "The operation was successful";
                    }
                }

            }

            base.Logger.LogError("\nThe data update operation failed, the data is not valid in PUpdateData.\n");

            return "The operation failed";
        }
        public void Init() { }
    }
}
