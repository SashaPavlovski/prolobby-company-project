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
                            CompanyName = reader["CompanyName"].ToString(),
                            NonProfitOrganizationName = null
                        });
                    }

                    return SortingUsers;

                }
                catch (SqlException EX)
                {

                    throw;
                }
                catch (Exception EX)
                {

                    throw;
                }
            }

            return null;
        }



        public void SetValues(SqlCommand command, string key, string value, string key2, string value2)
        {
            return;
        }


        string insertByCompany = "select [RepresentativeFirstName] + ' ' + [RepresentativeLastName] as 'FullName',\r\n[CompanyName],CONVERT(NVARCHAR(10), [Date],3) AS [Date],[Phone_number],[Email] \r\nfrom [dbo].[TBBusinessCompanyRepresentatives] ORDER BY [Date]";



        public List<TBSortingUsers> GetByCompany()
        {
            object listSortingUsers;

            try
            {
                listSortingUsers = SqlQuery.RunCommand(insertByCompany, AddSortingProducts, SetValues, null, null, null, null);
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


