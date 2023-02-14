using ProLobbyCompanyProject.Dal;
using ProLobbyCompanyProject.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Utilities.Logger;

/// file:SocialActivists\DSSocialActivistsGet.cs
/// summary:	Implements the ds social activists get class

namespace ProLobbyCompanyProject.Data.Sql
{
    public class DSSocialActivistsGet: BaseDataSql
    {
        SqlQuery SqlQuery;
        public DSSocialActivistsGet(Logger Logger) : base(Logger)
        {
            SqlQuery = new SqlQuery();
        }

        /// <summary>   Adds a social activists information. </summary>
        /// <param name="reader">   The reader. </param>
        /// <param name="command">  The command. </param>
        /// <param name="UserId">   Identifier for the user. </param>
        /// <returns>   An object TBSocialActivists List . </returns>
        public object AddSocialActivistsInformation(SqlDataReader reader, SqlCommand command, string UserId)
        {
            Logger.LogEvent("Enter into AddSocialActivistsInformation function");

            Logger.LogEvent("Receiving data about the social activist by the id");

            List<TBSocialActivists> socialActivists = new List<TBSocialActivists>();
            
            if (reader.HasRows)
            {
                try
                {
                    while (reader.Read())
                    {
                        socialActivists.Add(new TBSocialActivists
                        {
                            SocialActivists_Id = int.Parse(reader["SocialActivists_Id"].ToString()),
                            Address = reader["Address"].ToString(),
                            Email = reader["Email"].ToString(),
                            FirstName = reader["FirstName"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            Phone_number = reader["Phone_number"].ToString(),
                            Twitter_user = reader["Twitter_user"].ToString()
                        });
                    }
                }
                catch (SqlException Ex) { Logger.LogException(Ex.Message, Ex); throw; }
                catch (Exception Ex) { Logger.LogException(Ex.Message, Ex); throw; }

                Logger.LogEvent("End AddSocialActivistsInformation function and the data has been sent");
                
                return socialActivists;
            }

            Logger.LogEvent("End AddSocialActivistsInformation function and no data received");

            return null;
        }


        public void SetValues(SqlCommand command, string key, string value, string key2, string value2)
        {
            Logger.LogEvent("Enter into SetValues function");

            Logger.LogEvent("Entering data into values");

            try
            {
                command.Parameters.AddWithValue($"@{key}", value);
            }
            catch (SqlException Ex) { Logger.LogException(Ex.Message, Ex); throw; }
            catch (Exception Ex) { Logger.LogException(Ex.Message, Ex); throw; }
        }

        /// <summary>  sql query. </summary>
        string insertSocialActivists = "if exists (select  [User_Id]  from [dbo].[TBSocialActivists] where [User_Id] = @User_Id)\r\nbegin\r\n       select SocialActivists_Id,[FirstName],[LastName],[Address],[Email],[Twitter_user],[Phone_number]\r\n\t   from [dbo].[TBSocialActivists]\r\n\t   where [User_Id] = @User_Id\r\nend";


        /// <summary>   Gets social activists row. </summary>
        /// <param name="IdUser">   The identifier user. </param>
        /// <returns>   The social activists row. </returns>
        public List<TBSocialActivists> GetSocialActivistsRow(string IdUser)
        {
            Logger.LogEvent("\n\nEnter into GetSocialActivistsRow function");

            List<TBSocialActivists> SocialActivists = null;

            object listSocialActivists;

            try
            {
                listSocialActivists = SqlQuery.RunCommand(insertSocialActivists, AddSocialActivistsInformation, SetValues, "User_Id", IdUser, null, null);
            }
            catch (Exception Ex)
            {
                Logger.LogException(Ex.Message, Ex);

                throw;
            }

            if (listSocialActivists!= null && listSocialActivists is List<TBSocialActivists>)
            {
                SocialActivists = (List<TBSocialActivists>)listSocialActivists;

                Logger.LogEvent("End GetSocialActivistsRow function and get listSocialActivists");

                return SocialActivists;
            }

            Logger.LogEvent("End GetSocialActivistsRow function and invalid value was received");

            return SocialActivists;
        }
    }
}
