﻿////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	ProLobbyOwner\DSProLobbyOwnerUpdate.cs
//
// summary:	Implements the ds pro lobby owner update class
////////////////////////////////////////////////////////////////////////////////////////////////////

using ProLobbyCompanyProject.Dal.SqlQueryClasses;
using ProLobbyCompanyProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProLobbyCompanyProject.Data.Sql.ProLobbyOwner
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   The ds pro lobby owner update. </summary>
    ///
    /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class DSProLobbyOwnerUpdate
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DSProLobbyOwnerUpdate() { }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Updates the new data. </summary>
        ///
        /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
        ///
        /// <param name="command">      The command. </param>
        /// <param name="newUserData">  Information describing the new user. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

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


        /// <summary>   The pro lobby owner id]. </summary>
        string insertUpdate = "update [dbo].[TBProLobbyOwners] set [FirstName] = @FirstName , [LastName] = @LastName,\r\n[Email]=@Email,[Phone_number] = @Phone_number \r\nwhere [ProLobbyOwner_Id] =  @ProLobbyOwner_Id";

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Updates the users data described by NewData. </summary>
        ///
        /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
        ///
        /// <param name="NewData">  Information describing the new. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void UpdateUsersData(TBProLobbyOwner NewData)
        {
            SqlQueryUpdate sqlQuery = new SqlQueryUpdate();
            sqlQuery.RunUpdateData(insertUpdate, UpdateNewData, NewData);
        }
    }
}
