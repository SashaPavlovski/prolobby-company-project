using ProLobbyCompanyProject.Dal;
using ProLobbyCompanyProject.Model;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using Utilities.Logger;

namespace ProLobbyCompanyProject.Data.Sql
{
    public class DSNonProfitOrganizationsGet: BaseDataSql
    {
        SqlQuery SqlQuery;
        public DSNonProfitOrganizationsGet(Logger Logger) : base(Logger) 
        {
            SqlQuery = new SqlQuery();
        }


        //Receiving data from an organization representative
        public object AddNonProfitOrganizationInformation(SqlDataReader reader, SqlCommand command, string UserId)
        {
            Logger.LogEvent("Enter into AddNonProfitOrganizationInformation function");

            Logger.LogEvent("Receiving data from an organization representative");

            try
            {
                List<TBNonProfitOrganization> nonProfitOrganization = new List<TBNonProfitOrganization>();
                if (reader.HasRows)
                {
                    try
                    {
                        while (reader.Read())
                        {

                            nonProfitOrganization.Add(new TBNonProfitOrganization
                            {
                                NonProfitOrganization_Id = int.Parse(reader["NonProfitOrganization_Id"].ToString()),
                                NonProfitOrganizationName = reader["NonProfitOrganizationName"].ToString(),
                                RepresentativeFirstName = reader["RepresentativeFirstName"].ToString(),
                                RepresentativeLastName = reader["RepresentativeLastName"].ToString(),
                                decreption = reader["decreption"].ToString(),
                                Phone_number = reader["Phone_number"].ToString(),
                                Email = reader["Email"].ToString(),
                                Url = reader["Url"].ToString()
                            });
                        }

                        Logger.LogEvent("The data was received successfully");
                        Logger.LogEvent("The data was received successfully");

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

                    Logger.LogEvent("End AddNonProfitOrganizationInformation function and return nonProfitOrganization data ");

                    return nonProfitOrganization;
                }
            }
            catch (System.Exception Ex) { Logger.LogException(Ex.Message, Ex); throw; }

            Logger.LogEvent("End AddNonProfitOrganizationInformation function and return null");

            return null;
        }

        //Entering a value of id
        public void SetValues(SqlCommand command, string key, string value, string key2, string value2)
        {
            Logger.LogEvent("Enter into SetValues function");

            try
            {
                command.Parameters.AddWithValue($"@{key}", value);

                Logger.LogEvent("Done successfully");

            }
            catch (SqlException Ex) { Logger.LogException(Ex.Message, Ex); throw; }
            catch (System.Exception Ex) { Logger.LogException(Ex.Message, Ex); throw; }
        }

        /// <summary>   declare @User_Id  nvarchar(max)\r\n. </summary>

        string insertNonProfitOrganization = "if exists (select  [User_Id]  from [dbo].[TBNonProfitOrganizations] where [User_Id] = @User_Id)\r\nbegin\r\nselect  NonProfitOrganization_Id,[NonProfitOrganizationName],[Url],[decreption],[Email],[RepresentativeFirstName],\r\n[RepresentativeLastName],[Phone_number]\r\n\t   from [dbo].[TBNonProfitOrganizations]\r\n\t   where [User_Id] = @User_Id\r\nend";

        public List<TBNonProfitOrganization> GetNonProfitUserRow(string IdUser)
        {
            Logger.LogEvent("\n\nEnter into GetNonProfitUserRow function");

            List<TBNonProfitOrganization> NonProfitOrganization = null;

            object listNonProfitOrganization;

            try
            {
                listNonProfitOrganization = SqlQuery.RunCommand(insertNonProfitOrganization, AddNonProfitOrganizationInformation, SetValues, "User_Id", IdUser, null, null);

                Logger.LogEvent("The data was received successfully");

            }
            catch (System.Exception Ex) { Logger.LogException(Ex.Message, Ex); throw; }

            if (listNonProfitOrganization is List<TBNonProfitOrganization>)
            {
                NonProfitOrganization = (List<TBNonProfitOrganization>)listNonProfitOrganization;

                Logger.LogEvent("End PostUsersOrganization function and return nonProfitOrganization data");

                return NonProfitOrganization;

            }

            Logger.LogError("End PostUsersOrganization function and return null");

            return NonProfitOrganization;
        }
    }
}
