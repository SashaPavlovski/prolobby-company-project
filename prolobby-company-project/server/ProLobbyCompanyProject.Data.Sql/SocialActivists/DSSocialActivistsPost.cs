using ProLobbyCompanyProject.Dal.SqlQueryClasses;
using ProLobbyCompanyProject.Model;
using System;
using System.Data.SqlClient;
using Utilities.Logger;

/// file:	SocialActivists\DSSocialActivistsPost.cs
/// summary:	Implements the ds social activists post class

namespace ProLobbyCompanyProject.Data.Sql.SocialActivists
{
    public class DSSocialActivistsPost: BaseDataSql
    {

        SqlQueryPost sqlQuery;
        public DSSocialActivistsPost(Logger Logger) : base(Logger)
        {
            sqlQuery = new SqlQueryPost();
        }

        /// <summary>   Adds a user data to TBSocialActivists. </summary>
        /// <param name="userData"> Information describing the user. </param>
        /// <param name="command">  The command. </param>
        public void AddUserData(object userData, SqlCommand command)
        {
            Logger.LogEvent("Enter into AddUserData function");

            Logger.LogEvent("Entering social activist data into SQL");

            if (userData!= null && userData is TBSocialActivists)
            {
                try
                {
                    TBSocialActivists socialActivists = (TBSocialActivists)userData;

                    command.Parameters.AddWithValue("@FirstName", socialActivists.FirstName);
                    command.Parameters.AddWithValue("@LastName", socialActivists.LastName);
                    command.Parameters.AddWithValue("@Address", socialActivists.Address);
                    command.Parameters.AddWithValue("@Email", socialActivists.Email);
                    command.Parameters.AddWithValue("@Twitter_user", socialActivists.Twitter_user);
                    command.Parameters.AddWithValue("@Phone_number", socialActivists.Phone_number);
                    command.Parameters.AddWithValue("@User_Id", socialActivists.User_Id);

                    int rows = command.ExecuteNonQuery();

                    Logger.LogEvent("The operation was performed successfully");

                }
                catch (SqlException Ex)
                {
                    Logger.LogException(Ex.Message, Ex);

                    throw;
                }
                catch (Exception Ex)
                {
                    Logger.LogException(Ex.Message, Ex);

                    throw;
                }
            }

            Logger.LogEvent("End AddUserData function");

        }

        /// <summary>   sql query insert social activist data. </summary>
        string insert = "insert into [dbo].[TBSocialActivists] values (@FirstName,@LastName,@Address,@Email,@Twitter_user,@Phone_number,@User_Id,getdate())";

        /// <summary>   Posts the users data. </summary>
        /// <param name="userSocialActivists">  The user social activists. </param>

        public void PostUsersData(TBSocialActivists userSocialActivists)
        {
            Logger.LogEvent("\n\nEnter into PostUsersData function");

            try
            {
                sqlQuery.RunAddUser(insert, AddUserData, userSocialActivists);
            }
            catch (Exception Ex)
            {
                Logger.LogException(Ex.Message, Ex);

                throw;
            }
        }
    }
}
