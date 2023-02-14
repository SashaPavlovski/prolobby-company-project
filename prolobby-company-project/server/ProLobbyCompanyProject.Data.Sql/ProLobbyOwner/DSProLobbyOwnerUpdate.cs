using ProLobbyCompanyProject.Dal.SqlQueryClasses;
using ProLobbyCompanyProject.Model;
using System.Data.SqlClient;
using Utilities.Logger;

// file:	ProLobbyOwner\DSProLobbyOwnerUpdate.cs
// summary:	Implements the ds pro lobby owner update class

namespace ProLobbyCompanyProject.Data.Sql.ProLobbyOwner
{
    public class DSProLobbyOwnerUpdate: BaseDataSql
    {
        SqlQueryUpdate sqlQuery;
        public DSProLobbyOwnerUpdate(Logger Logger) : base(Logger)
        {
            sqlQuery = new SqlQueryUpdate();
        }

        /// <summary>   Updates the new data. </summary>
        /// <param name="command">  SQL connection. </param>
        /// <param name="newUserData">  The new data of the owner. </param>
        public void UpdateNewData(SqlCommand command, object newUserData)
        {
            Logger.LogEvent("Enter into UpdateNewData function");

            if (command != null && (newUserData != null))
            {
                if (newUserData is TBProLobbyOwner)
                {
                    Logger.LogEvent("Updates the new data");

                    try
                    {
                        TBProLobbyOwner proLobbyOwnerPost = (TBProLobbyOwner)newUserData;
                        command.Parameters.AddWithValue("@ProLobbyOwner_Id", proLobbyOwnerPost.ProLobbyOwner_Id);
                        command.Parameters.AddWithValue("@FirstName", proLobbyOwnerPost.FirstName);
                        command.Parameters.AddWithValue("@LastName", proLobbyOwnerPost.LastName);
                        command.Parameters.AddWithValue("@Email", proLobbyOwnerPost.Email);
                        command.Parameters.AddWithValue("@Phone_number", proLobbyOwnerPost.Phone_number);

                        int rows = command.ExecuteNonQuery();

                        Logger.LogEvent("End UpdateNewData function successfully");

                    }
                    catch (SqlException Ex)
                    {
                        Logger.LogException(Ex.Message, Ex);

                        throw;
                    }
                    catch (System.Exception Ex)
                    {
                        Logger.LogException(Ex.Message, Ex);

                        throw;
                    }
                }
            }
        }


        /// <summary>  sql query. </summary>
        string insertUpdate = "update [dbo].[TBProLobbyOwners] set [FirstName] = @FirstName , [LastName] = @LastName,\r\n[Email]=@Email,[Phone_number] = @Phone_number \r\nwhere [ProLobbyOwner_Id] =  @ProLobbyOwner_Id";


        /// <summary>   Updates the users data. </summary>
        /// <param name="NewData"> New information user data. </param>
        public void UpdateUsersData(TBProLobbyOwner NewData)
        {
            Logger.LogEvent("\n\nEnter into UpdateUsersData function");

            try
            {
                sqlQuery.RunUpdateData(insertUpdate, UpdateNewData, NewData);

                Logger.LogEvent("End UpdateUsersData function successfully");

            }
            catch (System.Exception Ex)
            {
                Logger.LogException(Ex.Message, Ex);

                throw;
            }
        }
    }
}
