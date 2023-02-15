using ProLobbyCompanyProject.Model;
using System;
using Utilities.Logger;

namespace ProLobbyCompanyProject.Entites.Commands.ProLobbyOwner
{
    public class PAddData: BaseCommands,ICommand
    {
        public PAddData(Logger logger) : base(logger) { }

        /// <summary>
        /// Saving details for the first time of the owner.
        /// </summary>
        /// <param name="argv">Owner details</param>
        /// <returns>If operation was performed successfully or failed.</returns>
        public object Execute(params object[] argv)
        {
            foreach (var item in argv)
            {
                if (item is TBProLobbyOwner)
                {
                    TBProLobbyOwner userOwner = (TBProLobbyOwner)item;

                    if (userOwner.FirstName != null && userOwner.LastName != null && userOwner.Email != null && userOwner.Phone_number != null && userOwner.User_Id != null)
                    {
                        MainManager.INSTANCE.ProLobbyOwner.PostUsersOwner(userOwner);

                        base.Logger.LogEvent("The data saving operation was performed successfully in PAddData.");

                        return "The operation was successful";
                    }
                }
            }

            base.Logger.LogError("\nThe save data operation failed, the data is not valid in PAddData.\n");

            return "The operation failed";
        }
        public void Init() { }
    }
}
