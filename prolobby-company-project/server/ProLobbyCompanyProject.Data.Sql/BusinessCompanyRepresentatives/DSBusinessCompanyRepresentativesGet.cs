using ProLobbyCompanyProject.Dal;
using ProLobbyCompanyProject.Model;
using System;
using System.Collections.Generic;
using Utilities.Logger;

// file:	BusinessCompanyRepresentatives\DSBusinessCompanyRepresentativesGet.cs
// summary:	Implements the ds business company representatives get class
namespace ProLobbyCompanyProject.Data.Sql
{
    /// <summary>   The ds business company representatives get. </summary>
    public class DSBusinessCompanyRepresentativesGet: BaseDataSql
    {
        /// <summary>   Default constructor. </summary>

        SqlQuery sqlQuery;
        public DSBusinessCompanyRepresentativesGet(Logger Logger) : base(Logger)
        {
            sqlQuery = new SqlQuery();
        }


        /// <summary> Adds the business company login Data. </summary>
        /// <param name="reader">   The reader. </param>
        /// <param name="command">  The command. </param>
        /// <param name="UserId">   Identifier for the user. </param>
        /// <returns>   An object of business company </returns>

        public object AddBusinessCompanyInformation(System.Data.SqlClient.SqlDataReader reader, System.Data.SqlClient.SqlCommand command, string UserId)
        {
            Logger.LogEvent("Enter into AddBusinessCompanyInformation function");

            Logger.LogEvent("Starting the data of the business company representative");

            List<TBBusinessCompanyRepresentative> businessCompanyRepresentative = new List<TBBusinessCompanyRepresentative>();

            try
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        businessCompanyRepresentative.Add(new TBBusinessCompanyRepresentative
                        {
                            BusinessCompany_Id = int.Parse(reader["BusinessCompany_Id"].ToString()),
                            CompanyName = reader["CompanyName"].ToString(),
                            Email = reader["Email"].ToString(),
                            Phone_number = reader["Phone_number"].ToString(),
                            RepresentativeFirstName = reader["RepresentativeFirstName"].ToString(),
                            RepresentativeLastName = reader["RepresentativeLastName"].ToString(),
                            Url = reader["Url"].ToString()
                        });
                    }

                    Logger.LogEvent("End AddBusinessCompanyInformation function and taking the data of business company representative");

                    return businessCompanyRepresentative;
                }
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.Message);
                Console.WriteLine(Ex.StackTrace);
            }
           
            return null;
        }

        /// <summary>   Sets the values. </summary>
        /// <param name="command">  The command. </param>
        /// <param name="key">      The key. </param>
        /// <param name="value">    The value. </param>
        /// <param name="key2">     The second key. </param>
        /// <param name="value2">   The second value. </param>
        public void SetValues(System.Data.SqlClient.SqlCommand command, string key, string value, string key2, string value2)
        {
            try
            {
                Logger.LogEvent("Enter into User_Id variable the business company representative id");

                command.Parameters.AddWithValue($"@{key}", value);
            }
            catch (Exception Ex)
            {
               Console.WriteLine(Ex.Message);
            }
        }
        /// <summary>   The insert business company. </summary>
        string insertBusinessCompany = "if exists (select  [User_Id]  from [dbo].[TBBusinessCompanyRepresentatives] where [User_Id] = @User_Id)\r\nbegin\r\n       select BusinessCompany_Id,[RepresentativeFirstName],\r\n\t   [RepresentativeLastName],\r\n\t [RepresentativeLastName],\r\n\t [CompanyName],[Url],\r\n\t  [Email],\r\n\t [Phone_number]\r\n\t from [dbo].[TBBusinessCompanyRepresentatives]\r\n\twhere [User_Id] = @User_Id\r\nend\r\n";


        /// <summary>   Gets business company user row. </summary>
        /// <param name="IdUser">   The identifier user. </param>
        /// <returns> The business company user row. </returns>
        public List<TBBusinessCompanyRepresentative> GetBusinessCompanyUserRow(string IdUser)
        {
            Logger.LogEvent("Enter into GetBusinessCompanyUserRow function");

            List<TBBusinessCompanyRepresentative> BusinessCompanyList = null;

            try
            {
                object listBusiness = sqlQuery.RunCommand(insertBusinessCompany, AddBusinessCompanyInformation, SetValues, "User_Id", IdUser, null, null);

                if (listBusiness is List<TBBusinessCompanyRepresentative>)
                {
                    BusinessCompanyList = (List<TBBusinessCompanyRepresentative>)listBusiness;
                }
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.Message);
                Console.WriteLine(Ex.StackTrace);
            }

            Logger.LogEvent("End GetBusinessCompanyUserRow function");

            return BusinessCompanyList;
        }
    }
}
