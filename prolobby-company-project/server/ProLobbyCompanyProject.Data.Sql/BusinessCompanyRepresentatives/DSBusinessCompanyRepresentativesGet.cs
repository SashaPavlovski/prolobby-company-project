
using ProLobbyCompanyProject.Dal;
using ProLobbyCompanyProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// file:	BusinessCompanyRepresentatives\DSBusinessCompanyRepresentativesGet.cs
// summary:	Implements the ds business company representatives get class
namespace ProLobbyCompanyProject.Data.Sql
{
    /// <summary>   The ds business company representatives get. </summary>
    public class DSBusinessCompanyRepresentativesGet
    {
        /// <summary>   Default constructor. </summary>
        public DSBusinessCompanyRepresentativesGet() { }


        /// <summary> Adds the business company login Data. </summary>
        /// <param name="reader">   The reader. </param>
        /// <param name="command">  The command. </param>
        /// <param name="UserId">   Identifier for the user. </param>
        /// <returns>   An object of business company </returns>

        public object AddBusinessCompanyInformation(System.Data.SqlClient.SqlDataReader reader, System.Data.SqlClient.SqlCommand command, string UserId)
        {
            List<TBBusinessCompanyRepresentative> businessCompanyRepresentative = new List<TBBusinessCompanyRepresentative>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    businessCompanyRepresentative.Add(new TBBusinessCompanyRepresentative() { BusinessCompany_Id = int.Parse(reader["BusinessCompany_Id"].ToString()), CompanyName = reader["CompanyName"].ToString(), Email = reader["Email"].ToString(), Phone_number = reader["Phone_number"].ToString(), RepresentativeFirstName = reader["RepresentativeFirstName"].ToString(), RepresentativeLastName = reader["RepresentativeLastName"].ToString(), Url = reader["Url"].ToString() });
                }
                return businessCompanyRepresentative;
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
            command.Parameters.AddWithValue($"@{key}", value);
        }
        /// <summary>   The insert business company. </summary>
        string insertBusinessCompany = "if exists (select  [User_Id]  from [dbo].[TBBusinessCompanyRepresentatives] where [User_Id] = @User_Id)\r\nbegin\r\n       select BusinessCompany_Id,[RepresentativeFirstName],\r\n\t   [RepresentativeLastName],\r\n\t [RepresentativeLastName],\r\n\t [CompanyName],[Url],\r\n\t  [Email],\r\n\t [Phone_number]\r\n\t from [dbo].[TBBusinessCompanyRepresentatives]\r\n\twhere [User_Id] = @User_Id\r\nend\r\n";


        /// <summary>   Gets business company user row. </summary>
        /// <param name="IdUser">   The identifier user. </param>
        /// <returns> The business company user row. </returns>
        public List<TBBusinessCompanyRepresentative> GetBusinessCompanyUserRow(string IdUser)
        {
            SqlQuery sqlQuery1 = new SqlQuery();
            List<TBBusinessCompanyRepresentative> BusinessCompanyList = null;


            object listBusiness = sqlQuery1.RunCommand(insertBusinessCompany, AddBusinessCompanyInformation, SetValues, "User_Id", IdUser, null, null);

            if (listBusiness is List<TBBusinessCompanyRepresentative>)
            {
                BusinessCompanyList = (List<TBBusinessCompanyRepresentative>)listBusiness;
            }
            return BusinessCompanyList;
        }
    }
}
