using ProLobbyCompanyProject.Model;
using Utilities.Logger;

namespace ProLobbyCompanyProject.Entites.Commands.BusinessCompany
{
    public class BAddDataCommand: BaseCommands,ICommand
    {
        public BAddDataCommand(Logger logger):base(logger) { }

        /// <summary>
        /// Saving for the first time of the details of the company representative.
        /// </summary>
        /// <param name="argv">Receiving all the data on the representative of the company.</param>
        /// <returns> Answer whether the operation was successful. </returns>
        public object Execute(params object[] argv)
        {
            foreach (var item in argv)
            {
                if(item is TBBusinessCompanyRepresentative)
                {
                    TBBusinessCompanyRepresentative userCompany = (TBBusinessCompanyRepresentative)item;

                    if (userCompany.Url != null && userCompany.Email != null && userCompany.CompanyName != null && userCompany.RepresentativeFirstName != null && userCompany.RepresentativeLastName != null && userCompany.User_Id != null && userCompany.Phone_number != null)
                    {
                        MainManager.INSTANCE.BusinessCompanyRepresentatives.PostUsersCompanys(userCompany);

                        return "The operation was successful";
                    }

                    base.Logger.LogError("\nNot all the details of a company representative were received in BAddDataCommand class, the operation failed\n");

                    return "The operation failed";
                }
            }

            return "The operation failed";

        }
        public void Init()
        {

        }
    }
}
