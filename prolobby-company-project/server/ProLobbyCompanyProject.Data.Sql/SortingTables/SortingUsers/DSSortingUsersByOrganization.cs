﻿using ProLobbyCompanyProject.Dal;
using ProLobbyCompanyProject.Model.SortingTables.SortingUsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProLobbyCompanyProject.Data.Sql.SortingTables.SortingUsers
{
    public class DSSortingUsersByOrganization
    {
        //Sorting of users by association
        public DSSortingUsersByOrganization () { sqlQuery1 = new SqlQuery(); }
        SqlQuery sqlQuery1;
        List<TBSortingUsers> sortingUsers = null;
        string insertByOrganizations = "select [RepresentativeFirstName] + ' ' + [RepresentativeLastName] as 'FullName',\r\n[NonProfitOrganizationName],CONVERT(NVARCHAR(10), [Date],3) AS [Date],[Phone_number],[Email] \r\nfrom [dbo].[TBNonProfitOrganizations] ORDER BY [Date]";
       
        public object AddSortingProducts(System.Data.SqlClient.SqlDataReader reader, System.Data.SqlClient.SqlCommand command, string campaignName)
        {
            List<TBSortingUsers> SortingUsers = new List<TBSortingUsers>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    SortingUsers.Add(new TBSortingUsers() { FullName = reader["FullName"].ToString(), Date = DateTime.Parse(reader["Date"].ToString()), Phone_number = reader["Phone_number"].ToString(), Email = reader["Email"].ToString(), CompanyName = null, NonProfitOrganizationName = reader["NonProfitOrganizationName"].ToString() });

                }
                return SortingUsers;
            }
            return null;
        }



        public void SetValues(System.Data.SqlClient.SqlCommand command, string key, string value, string key2, string value2)
        {
            return;
        }

        public List<TBSortingUsers> GetByOrganizations()
        {
            object listSortingUsers = sqlQuery1.RunCommand(insertByOrganizations, AddSortingProducts, SetValues, null, null, null, null);
            if (listSortingUsers != null)
            {

                if (listSortingUsers is List<TBSortingUsers>)
                {
                    sortingUsers = (List<TBSortingUsers>)listSortingUsers;
                }
            }
            return sortingUsers;
        }

    }
}
