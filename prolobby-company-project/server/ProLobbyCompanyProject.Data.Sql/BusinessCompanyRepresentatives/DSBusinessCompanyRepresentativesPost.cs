using ProLobbyCompanyProject.Dal.SqlQueryClasses;
using ProLobbyCompanyProject.Model;
using System;
using System.Data.SqlClient;
using Utilities.Logger;

// file:	BusinessCompanyRepresentatives\DSBusinessCompanyRepresentativesPost.cs
// summary:	Implements the ds business company representatives post class

namespace ProLobbyCompanyProject.Data.Sql.BusinessCompanyRepresentatives
{
    /// <summary>   The business company representatives post login new data . </summary>
    public class DSBusinessCompanyRepresentativesPost: BaseDataSql
    {

        /// <summary>   Default constructor. </summary>
        public DSBusinessCompanyRepresentativesPost(Logger Logger) : base(Logger) { }

        /// <summary>   Adds a user data to DB. </summary>
        /// <param name="userData"> Information describing the user. </param>
        /// <param name="command">  The command. </param>
        public void AddUserData(object userData, SqlCommand command)
        {
            Logger.LogEvent("Enter into AddUserData function");

            Logger.LogEvent("Updating the data of the business company");

            try
            {
                if (userData is TBBusinessCompanyRepresentative)
                {
                    TBBusinessCompanyRepresentative businessCompanyRepresentative = (TBBusinessCompanyRepresentative)userData;

                    command.Parameters.AddWithValue("@CompanyName", businessCompanyRepresentative.CompanyName);
                    command.Parameters.AddWithValue("@Url", businessCompanyRepresentative.Url);
                    command.Parameters.AddWithValue("@Email", businessCompanyRepresentative.Email);
                    command.Parameters.AddWithValue("@RepresentativeFirstName", businessCompanyRepresentative.RepresentativeFirstName);
                    command.Parameters.AddWithValue("@RepresentativeLastName", businessCompanyRepresentative.RepresentativeLastName);
                    command.Parameters.AddWithValue("@Phone_number", businessCompanyRepresentative.Phone_number);
                    command.Parameters.AddWithValue("@User_Id", businessCompanyRepresentative.User_Id);

                    int rows = command.ExecuteNonQuery();

                }
            }
            catch (SqlException Ex)
            {

                throw;
            }
            catch (Exception)
            {

                throw;
            }

            Logger.LogEvent("End AddUserData function and end of data update");
        }

        /// <summary>   The insert data of company. </summary>
        string insert = "insert into [dbo].[TBBusinessCompanyRepresentatives] values (@RepresentativeFirstName,@RepresentativeLastName,@CompanyName,@Url,@Email,@Phone_number,@User_Id,getdate())";

        /// <summary>   Posts the users data. </summary>
        /// <param name="userBusinessCompanyRepresentative">    The user business company new data. </param>
        public void PostUsersData(TBBusinessCompanyRepresentative userBusinessCompanyRepresentative)
        {
            Logger.LogEvent("Enter into PostUsersData function");

            try
            {
                SqlQueryPost sqlQuery = new SqlQueryPost();
                sqlQuery.RunAddUser(insert, AddUserData, userBusinessCompanyRepresentative);
            }
            catch (Exception EX)
            {

                throw;
            }

            Logger.LogEvent("End PostUsersData function");

        }
    }
}
