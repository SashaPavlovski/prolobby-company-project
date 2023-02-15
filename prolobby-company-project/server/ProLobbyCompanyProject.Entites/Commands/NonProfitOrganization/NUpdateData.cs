using ProLobbyCompanyProject.Model;
using System;
using Utilities.Logger;

namespace ProLobbyCompanyProject.Entites.Commands.NonProfitOrganization
{
    public class NUpdateData: BaseCommands,ICommand
    {
        public NUpdateData(Logger logger) : base(logger) { }

        /// <summary>
        /// Updating the data of an organization representative.
        /// </summary>
        /// <param name="argv">Information about the organization with the new information.</param>
        /// <returns>Whether the update was successful or not.</returns>
        public object Execute(params object[] argv)
        {
            foreach (var item in argv)
            {
                if (item is TBNonProfitOrganization)
                {
                    TBNonProfitOrganization UserOrganizationData = (TBNonProfitOrganization)item;

                    if (UserOrganizationData.NonProfitOrganization_Id != 0 && UserOrganizationData.NonProfitOrganizationName != null && UserOrganizationData.RepresentativeLastName != null && UserOrganizationData.Email != null && UserOrganizationData.Phone_number != null && UserOrganizationData.RepresentativeFirstName != null && UserOrganizationData.decreption != null && UserOrganizationData.Url != null)
                    {
                        MainManager.INSTANCE.NonProfitOrganizations.UpdateActivist(UserOrganizationData);

                        base.Logger.LogEvent("vThe update operation of the organization representative was carried out successfully in NUpdateData.");

                        return "The operation was successful";
                    }

                }
            }

            base.Logger.LogError("\nThe update operation of the representative in the association failed, the data is incorrect in NUpdateData.\n");

            return "The operation failed";
        }
        public void Init() { }
    }
}
