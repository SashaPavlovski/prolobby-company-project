﻿using ProLobbyCompanyProject.Dal.SqlQueryClasses;
using ProLobbyCompanyProject.Model;
using Utilities.Logger;

// file:	ProLobbyOwner\DSProLobbyOwnerUpdate.cs
// summary:	Implements the ds pro lobby owner update class

namespace ProLobbyCompanyProject.Data.Sql.ProLobbyOwner
{
    public class DSProLobbyOwnerUpdate: BaseDataSql
    {
        public DSProLobbyOwnerUpdate(Logger Logger) : base(Logger) { }

        /// <summary>   Updates the new data. </summary>
        /// <param name="command">      The command. </param>
        /// <param name="newUserData">  Information describing the new user. </param>
        public void UpdateNewData(System.Data.SqlClient.SqlCommand command, object newUserData)
        {

            if (command == null && (newUserData == null)) return;
            {
                if (newUserData is TBProLobbyOwner)
                {
                    try
                    {
                        TBProLobbyOwner proLobbyOwnerPost = (TBProLobbyOwner)newUserData;
                        command.Parameters.AddWithValue("@ProLobbyOwner_Id", proLobbyOwnerPost.ProLobbyOwner_Id);
                        command.Parameters.AddWithValue("@FirstName", proLobbyOwnerPost.FirstName);
                        command.Parameters.AddWithValue("@LastName", proLobbyOwnerPost.LastName);
                        command.Parameters.AddWithValue("@Email", proLobbyOwnerPost.Email);
                        command.Parameters.AddWithValue("@Phone_number", proLobbyOwnerPost.Phone_number);
                        int rows = command.ExecuteNonQuery();
                    }
                    catch (System.Exception EX)
                    {

                        throw;
                    }
                }
            }
        }


        /// <summary>   The pro lobby owner id]. </summary>
        string insertUpdate = "update [dbo].[TBProLobbyOwners] set [FirstName] = @FirstName , [LastName] = @LastName,\r\n[Email]=@Email,[Phone_number] = @Phone_number \r\nwhere [ProLobbyOwner_Id] =  @ProLobbyOwner_Id";


        /// <summary>   Updates the users data described by NewData. </summary>
        /// <param name="NewData">  Information describing the new. </param>
        public void UpdateUsersData(TBProLobbyOwner NewData)
        {
            try
            {
                SqlQueryUpdate sqlQuery = new SqlQueryUpdate();
                sqlQuery.RunUpdateData(insertUpdate, UpdateNewData, NewData);
            }
            catch (System.Exception EX)
            {

                throw;
            }
        }
    }
}
