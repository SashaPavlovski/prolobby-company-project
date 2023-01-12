using ProLobbyCompanyProject.Dal;
using ProLobbyCompanyProject.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProLobbyCompanyProject.Data.Sql
{
    public class DSNonProfitOrganizationsGet
    {
        public DSNonProfitOrganizationsGet() { }
        public byte[] GetPhoto(string filePath)
        {
            FileStream stream = new FileStream(
                filePath, FileMode.Open, FileAccess.Read);
            BinaryReader reader = new BinaryReader(stream);

            byte[] photo = reader.ReadBytes((int)stream.Length);

            reader.Close();
            stream.Close();

            return photo;
        }

        public object AddNonProfitOrganizationInformation(System.Data.SqlClient.SqlDataReader reader, System.Data.SqlClient.SqlCommand command, string UserId)
        {
            List<TBNonProfitOrganization> nonProfitOrganization = new List<TBNonProfitOrganization>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    nonProfitOrganization.Add(new TBNonProfitOrganization() { NonProfitOrganization_Id = int.Parse(reader["NonProfitOrganization_Id"].ToString()), NonProfitOrganizationName = reader["NonProfitOrganizationName"].ToString(), RepresentativeFirstName = reader["RepresentativeFirstName"].ToString(), RepresentativeLastName = reader["RepresentativeLastName"].ToString(), decreption = reader["decreption"].ToString(), Phone_number = reader["Phone_number"].ToString(), Email = reader["Email"].ToString(), Logo = null, Url = reader["Url"].ToString() });

                }
                return nonProfitOrganization;
            }
            return null;
        }



        public void SetValues(System.Data.SqlClient.SqlCommand command, string key, string value, string key2, string value2)
        {
                command.Parameters.AddWithValue($"@{key}", value);
        }

    //declare @User_Id  nvarchar(max)\r\n

    string insertNonProfitOrganization = "if exists (select  [User_Id]  from [dbo].[TBNonProfitOrganizations] where [User_Id] = @User_Id)\r\nbegin\r\nselect  NonProfitOrganization_Id,[NonProfitOrganizationName],[Url],[decreption],[Email],[RepresentativeFirstName],\r\n[RepresentativeLastName],[Phone_number],[Logo]\r\n\t   from [dbo].[TBNonProfitOrganizations]\r\n\t   where [User_Id] = @User_Id\r\nend";

        public List<TBNonProfitOrganization> GetNonProfitUserRow(string IdUser)
        {
            SqlQuery sqlQuery1 = new SqlQuery();
            List<TBNonProfitOrganization> NonProfitOrganization = null;
            object listNonProfitOrganization = sqlQuery1.RunCommand(insertNonProfitOrganization, AddNonProfitOrganizationInformation, SetValues, "User_Id", IdUser, null, null); 

            if (listNonProfitOrganization is List<TBNonProfitOrganization>)
            {
                NonProfitOrganization = (List<TBNonProfitOrganization>)listNonProfitOrganization;
            }
            return NonProfitOrganization;
        }
    }
}
