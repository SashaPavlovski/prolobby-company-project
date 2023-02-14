using ProLobbyCompanyProject.Dal;
using ProLobbyCompanyProject.Model.SortingTables.SortingUsers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Utilities.Logger;

namespace ProLobbyCompanyProject.Data.Sql.SortingTables.SortingUsers
{
    public class DSSortingUsersByCompany: BaseDataSql
    {
        //Sorting users by company

        SqlQuery SqlQuery;

        List<TBSortingUsers> sortingUsers = null;

        public DSSortingUsersByCompany(Logger Logger) : base(Logger)
        {
            SqlQuery = new SqlQuery();
        }

        /// <summary>
        /// Get all the data about business company representative according to the query.
        /// </summary>
        /// <param name="reader"> Get data from sql. </param>
        /// <param name="command"> SQL connection. </param>
        /// <param name="campaignName"></param>
        /// <returns> List of details about business company representative. </returns>
        public object AddSortingUsers(SqlDataReader reader, SqlCommand command, string campaignName)
        {
            Logger.LogEvent("Enter into AddSortingUsers function");

            List<TBSortingUsers> SortingUsers = new List<TBSortingUsers>();

            if (reader.HasRows)
            {
                Logger.LogEvent("Starting sorting the report table of the business company representative");

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
                            CompanyName = reader["CompanyName"].ToString(),
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
        /// sql query select all details about all business company representative sorted by date
        /// </summary>

        string insertByCompany = "select [RepresentativeFirstName] + ' ' + [RepresentativeLastName] as 'FullName',\r\n[CompanyName],CONVERT(NVARCHAR(10), [Date],3) AS [Date],[Phone_number],[Email] \r\nfrom [dbo].[TBBusinessCompanyRepresentatives] ORDER BY [Date]";


        /// <summary>
        /// Get details of the business company representative
        /// </summary>
        /// <returns> A report of details about all business company representative </returns>
        public List<TBSortingUsers> GetByCompany()
        {
            Logger.LogEvent("\n\nEnter into GetByCompany function");

            object listSortingUsers;

            try
            {
                listSortingUsers = SqlQuery.RunCommand(insertByCompany, AddSortingUsers, SetValues, null, null, null, null);
            }
            catch (Exception Ex) { Logger.LogException(Ex.Message, Ex); throw; }

            if (listSortingUsers != null)
            {

                if (listSortingUsers is List<TBSortingUsers>)
                {
                    sortingUsers = (List<TBSortingUsers>)listSortingUsers;

                    Logger.LogEvent("End GetByCompany function successfully");

                    return sortingUsers;
                }
            }

            Logger.LogEvent("End GetByCompany function, return null");

            return sortingUsers;
        }
    }
}


