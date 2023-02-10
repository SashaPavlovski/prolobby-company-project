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

        SqlQuery SqlQuery;

        List<TBSortingUsers> sortingUsers = null;

        //Sorting of users by social activists or by an owner
        public DSSortingUsersDefault(Logger Logger) : base(Logger)
        {
            SqlQuery = new SqlQuery();
        }


        public object AddSortingProducts(SqlDataReader reader, SqlCommand command, string campaignName)
        {
            List<TBSortingUsers> SortingUsers = new List<TBSortingUsers>();
            if (reader.HasRows)
            {
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
                }
                catch (SqlException EX)
                {

                    throw;
                }
                catch (Exception EX)
                {

                    throw;
                }
                return SortingUsers;
            }
            return null;
        }



        public void SetValues(SqlCommand command, string key, string value, string key2, string value2)
        {
            return;
        }

        string insertByProLobbyOwners = "select [FirstName] + ' ' + [LastName] as 'FullName',\r\nCONVERT(NVARCHAR(10), [Date],3) AS [Date],[Phone_number],[Email] \r\nfrom [dbo].[TBProLobbyOwners] ORDER BY [Date]";

        string insertBySocialActivists = "select [FirstName] + ' ' + [LastName] as 'FullName',\r\nCONVERT(NVARCHAR(10), [Date],3) AS [Date],[Phone_number],[Email] \r\nfrom [dbo].[TBSocialActivists] ORDER BY [Date]";

        public List<TBSortingUsers> GetByProLobbyOwners()
        {
            object listSortingUsers;

            try
            {
                listSortingUsers = SqlQuery.RunCommand(insertByProLobbyOwners, AddSortingProducts, SetValues, null, null, null, null);
            }
            catch (Exception EX)
            {

                throw;
            }

            if (listSortingUsers != null)
            {

                if (listSortingUsers is List<TBSortingUsers>)
                {
                    sortingUsers = (List<TBSortingUsers>)listSortingUsers;

                    return sortingUsers;

                }
            }
            return sortingUsers;
        }
        public List<TBSortingUsers> GetBySocialActivists()
        {
            object listSortingUsers;

            try
            {
                listSortingUsers = SqlQuery.RunCommand(insertBySocialActivists, AddSortingProducts, SetValues, null, null, null, null);
            }
            catch (Exception EX)
            {

                throw;
            }

            if (listSortingUsers != null)
            {

                if (listSortingUsers is List<TBSortingUsers>)
                {
                    sortingUsers = (List<TBSortingUsers>)listSortingUsers;

                    return sortingUsers;

                }
            }
            return sortingUsers;
        }

    }
}
