using ProLobbyCompanyProject.Data.Sql;
using ProLobbyCompanyProject.Data.Sql.ProLobbyOwner;
using ProLobbyCompanyProject.Model;
using System.Collections.Generic;
using Utilities.Logger;

namespace ProLobbyCompanyProject.Entites
{
    public class ProLobbyOwner: BaseEntity
    {
        DSProLobbyOwnerGet dSUserData;
        DSProLobbyOwnerPost userOwnerPost;
        DSProLobbyOwnerUpdate usersNewData;

        public ProLobbyOwner(Logger logger) : base(logger)
        {
            dSUserData = new DSProLobbyOwnerGet(base.Logger);
            userOwnerPost = new DSProLobbyOwnerPost(base.Logger);
            usersNewData = new DSProLobbyOwnerUpdate(base.Logger);

            Logger.LogEvent("Initializing the data in the constructor");
        }

        //Checking if the proLobby owner exists
        //Gets the manager's id
        public List<TBProLobbyOwner> CheckingIfExistUser(string id)
        {
            Logger.LogEvent("\n\nEnter into CheckingIfExistUser function");

            return dSUserData.GetProLobbyOwnerUserRow(id);
        }

        //Entering proLobby owner data 
        public void PostUsersOwner(TBProLobbyOwner userOwnerData)
        {
            Logger.LogEvent("\n\nEnter into PostUsersOwner function");

            userOwnerPost.PostUsersData(userOwnerData);

            Logger.LogEvent("End PostUsersOwner function");

        }

        //Updating the data of proLobby owner
        public void UpdateUsersOwner(TBProLobbyOwner updateUserData)
        {
            Logger.LogEvent("\n\nEnter into UpdateUsersOwner function");

            usersNewData.UpdateUsersData(updateUserData);

            Logger.LogEvent("End UpdateUsersOwner function");

        }
    }
}
