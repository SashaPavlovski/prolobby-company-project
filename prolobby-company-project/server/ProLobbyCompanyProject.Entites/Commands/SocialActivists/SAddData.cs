using ProLobbyCompanyProject.Model;
using System;
using Utilities.Logger;

namespace ProLobbyCompanyProject.Entites.Commands.SocialActivists
{
    public class SAddData: BaseCommands,ICommand
    {
        public SAddData(Logger logger) : base(logger) { }

        /// <summary>
        /// Saving the data of a social activist for the first time.
        /// </summary>
        /// <param name="argv">Social activist data</param>
        /// <returns>If operation was performed successfully or failed.</returns>
        public object Execute(params object[] argv)
        {
            foreach (var item in argv)
            {
                if (item is TBSocialActivists)
                {
                    TBSocialActivists userActivists = (TBSocialActivists)item;

                    if (userActivists.FirstName != null && userActivists.LastName != null && userActivists.Email != null && userActivists.Phone_number != null && userActivists.User_Id != null && userActivists.Address != null && userActivists.Twitter_user != null)
                    {
                        MainManager.INSTANCE.SocialActivists.PostUsersActivists(userActivists);

                        base.Logger.LogEvent("The data saving operation was performed successfully in SAddData.");

                        return "The operation was successful";
                    }
                }
            }

            base.Logger.LogError("\nThe save data operation failed, the data is not valid in SAddData.\n");

            return "The operation failed";
        }
        public void Init() { }
    }
}
