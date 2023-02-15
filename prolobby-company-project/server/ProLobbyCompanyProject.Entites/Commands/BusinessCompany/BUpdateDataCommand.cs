using Microsoft.AspNetCore.Mvc;
using ProLobbyCompanyProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.Logger;

namespace ProLobbyCompanyProject.Entites.Commands.BusinessCompany
{
    public class BUpdateDataCommand: BaseCommands,ICommand
    {
        public BUpdateDataCommand(Logger logger) :base(logger) { }

        /// <summary>
        /// Updating company representative details.
        /// </summary>
        /// <param name="argv"> All the details of the user with the details to update. </param>
        /// <returns>  Answer whether the operation was successful or not. </returns>
        public object Execute(params object[] argv)
        {
            foreach (var item in argv)
            {
                if (item is TBBusinessCompanyRepresentative)
                {
                    TBBusinessCompanyRepresentative UserCompanyData = (TBBusinessCompanyRepresentative)item;

                    if (UserCompanyData.BusinessCompany_Id != 0 && UserCompanyData.RepresentativeFirstName != null && UserCompanyData.RepresentativeLastName != null && UserCompanyData.CompanyName != null && UserCompanyData.Phone_number != null && UserCompanyData.Email != null)
                    {
                        MainManager.INSTANCE.BusinessCompanyRepresentatives.UpdateActivist(UserCompanyData);

                        base.Logger.LogEvent("The operation of updating the data of the company representative was carried out successfully");

                        return "The operation was successful";
                    }
                }
            }

            base.Logger.LogEvent("The operation to update the data of the company representative failed, not enough data was received in BUpdateDataCommand");

            return "The operation failed";
        }

        public void Init()
        {

        }
    }
}
