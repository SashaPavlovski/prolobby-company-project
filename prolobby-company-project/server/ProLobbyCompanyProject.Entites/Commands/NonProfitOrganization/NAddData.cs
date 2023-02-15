using ProLobbyCompanyProject.Model;
using System;
using Utilities.Logger;

namespace ProLobbyCompanyProject.Entites.Commands.NonProfitOrganization
{
    public class NAddData: BaseCommands,ICommand
    {
        public NAddData(Logger logger) : base(logger) { }

        /// <summary>
        /// Entering data of the organization representative for the first time.
        /// </summary>
        /// <param name="argv">Data of the organization representative</param>
        /// <returns>Whether the operation succeeded or failed.</returns>
        public object Execute(params object[] argv)
        {
            foreach (var item in argv)
            {
                if (item is TBNonProfitOrganization)
                {
                    TBNonProfitOrganization userOrganization = (TBNonProfitOrganization)item;

                    if (userOrganization.Url != null && userOrganization.decreption != null && userOrganization.NonProfitOrganizationName != null && userOrganization.RepresentativeFirstName != null && userOrganization.RepresentativeLastName != null && userOrganization.User_Id != null)
                    {
                        MainManager.INSTANCE.NonProfitOrganizations.PostUsersOrganization(userOrganization);

                        base.Logger.LogError("The data saving operation was performed successfully in NAddData.");

                        return "The operation was successful";
                    }
                }

            }
            base.Logger.LogError("\nThe data saving operation failed, the Id of the organization representative was not received in NAddData.\n");

            return "The operation failed";
        }
        public void Init() { }
    }
}
