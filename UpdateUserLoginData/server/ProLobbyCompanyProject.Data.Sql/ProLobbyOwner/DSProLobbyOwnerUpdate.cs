using ProLobbyCompanyProject.Dal.SqlQueryClasses;
using ProLobbyCompanyProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProLobbyCompanyProject.Data.Sql.ProLobbyOwner
{
    public class DSProLobbyOwnerUpdate
    {
        public DSProLobbyOwnerUpdate() { }
        public void UpdateNewData(System.Data.SqlClient.SqlCommand command, object newUserData)
        {

            if (command == null && (newUserData == null)) return;
            {
                if (newUserData is TBProLobbyOwner)
                {
                    TBProLobbyOwner proLobbyOwnerPost = (TBProLobbyOwner)newUserData;
                    command.Parameters.AddWithValue("@ProLobbyOwner_Id", proLobbyOwnerPost.ProLobbyOwner_Id);
                    command.Parameters.AddWithValue("@FirstName", proLobbyOwnerPost.FirstName);
                    command.Parameters.AddWithValue("@LastName", proLobbyOwnerPost.LastName);
                    command.Parameters.AddWithValue("@Email", proLobbyOwnerPost.Email);
                    command.Parameters.AddWithValue("@Phone_number", proLobbyOwnerPost.Phone_number);

                }
            }
            int rows = command.ExecuteNonQuery();
        }


        string insertUpdate = "update [dbo].[TBProLobbyOwners] set [FirstName] = @FirstName , [LastName] = @LastName,\r\n[Email]=@Email,[Phone_number] = @Phone_number \r\nwhere [ProLobbyOwner_Id] =  @ProLobbyOwner_Id";


        public void UpdateUsersData(TBProLobbyOwner NewData)
        {
            SqlQueryUpdate sqlQuery = new SqlQueryUpdate();
            sqlQuery.RunUpdateData(insertUpdate, UpdateNewData, NewData);
        }
    }
}
