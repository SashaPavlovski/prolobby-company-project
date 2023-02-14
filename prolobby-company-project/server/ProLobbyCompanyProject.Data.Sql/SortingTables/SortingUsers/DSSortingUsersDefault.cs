using ProLobbyCompanyProject.Dal;
using ProLobbyCompanyProject.Model.SortingTables.SortingUsers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Utilities.Logger;

namespace ProLobbyCompanyProject.Data.Sql.SortingTables.SortingUsers
{
    public class DSSortingUsersDefault: BaseDataSql
    {
        /// <summary>
        /// Sorting of users by social activists or by an owner
        /// </summary>


        SqlQuery SqlQuery;

        List<TBSortingUsers> sortingUsers = null;

        public DSSortingUsersDefault(Logger Logger) : base(Logger)
        {
            SqlQuery = new SqlQuery();
        }


        /// <summary>
        /// Get all the data about social activists or proLobby owners according to the query
        /// </summary>
        /// <param name="reader"> Get data from sql. </param>
        /// <param name="command"> SQL connection </param>
        /// <param name="campaignName"></param>
        /// <returns> List of details about social activists or proLobby owners. </returns>
        public object AddSortingUsers(SqlDataReader reader, SqlCommand command, string campaignName)
        {
            Logger.LogEvent("Enter into AddSortingUsers function");

            List<TBSortingUsers> SortingUsers = new List<TBSortingUsers>();

            if (reader.HasRows)
            {
                Logger.LogEvent("Starting sorting the report table of the social activists or proLobby owners");

                try
                {
                    while (reader.Read())
                    {
                        SortingUsers.Add(new TBSortingUsers
                        {
                            FullName = reader["FullName"].ToString(),
                            Date = DateTime.Parse(reader["Date"].ToString()),
                            Phone_number = reader["Phone_number"].ToString(),
                            Email = reader["Email"].ToString(),
                            CompanyName = null,
                            NonProfitOrganizationName = null
                        });
                    }

                    Logger.LogEvent("End AddSortingUsers function, return user report list");

                    return SortingUsers;

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

            Logger.LogEvent("End AddSortingUsers function, return null");

            return null;
        }



        public void SetValues(SqlCommand command, string key, string value, string key2, string value2)
        {
            return;
        }



        /// <summary>
        /// sql query select all details about all proLobby owners sorted by date
        /// </summary>
        string insertByProLobbyOwners = "select [FirstName] + ' ' + [LastName] as 'FullName',\r\nCONVERT(NVARCHAR(10), [Date],3) AS [Date],[Phone_number],[Email] \r\nfrom [dbo].[TBProLobbyOwners] ORDER BY [Date]";



        /// <summary>
        /// sql query select all details about all  social activists sorted by date
        /// </summary>
        string insertBySocialActivists = "select [FirstName] + ' ' + [LastName] as 'FullName',\r\nCONVERT(NVARCHAR(10), [Date],3) AS [Date],[Phone_number],[Email] \r\nfrom [dbo].[TBSocialActivists] ORDER BY [Date]";


        /// <summary>
        /// Get details of the proLobby owners.
        /// </summary>
        /// <returns> A report of details about proLobby owners. </returns>
        public List<TBSortingUsers> GetByProLobbyOwners()
        {
            Logger.LogEvent("\n\nEnter into GetByProLobbyOwners function");

            object listSortingUsers;

            try
            {
                listSortingUsers = SqlQuery.RunCommand(insertByProLobbyOwners, AddSortingUsers, SetValues, null, null, null, null);
            }
            catch (Exception Ex)
            {
                Logger.LogException(Ex.Message, Ex);

                throw;
            }

            if (listSortingUsers != null)
            {

                if (listSortingUsers is List<TBSortingUsers>)
                {
                    sortingUsers = (List<TBSortingUsers>)listSortingUsers;

                    Logger.LogEvent("End GetByProLobbyOwners function successfully");

                    return sortingUsers;

                }
            }

            Logger.LogEvent("End GetByProLobbyOwners function, return null");

            return sortingUsers;
        }


        /// <summary>
        /// Get details of the social activists.
        /// </summary>
        /// <returns> A report of details about social activists. </returns>
        public List<TBSortingUsers> GetBySocialActivists()
        {
            Logger.LogEvent("\n\nEnter into GetBySocialActivists function");

            object listSortingUsers;

            try
            {
                listSortingUsers = SqlQuery.RunCommand(insertBySocialActivists, AddSortingUsers, SetValues, null, null, null, null);
            }
            catch (Exception Ex)
            {
                Logger.LogException(Ex.Message, Ex);

                throw;
            }

            if (listSortingUsers != null)
            {

                if (listSortingUsers is List<TBSortingUsers>)
                {
                    sortingUsers = (List<TBSortingUsers>)listSortingUsers;

                    Logger.LogEvent("End GetBySocialActivists function successfully");

                    return sortingUsers;

                }
            }

            Logger.LogEvent("End GetBySocialActivists function, return null");

            return sortingUsers;
        }

    }
}
