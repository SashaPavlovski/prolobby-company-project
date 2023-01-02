using Microsoft.AspNetCore.Http;
using ProLobbyCompanyProject.Dal;
using ProLobbyCompanyProject.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProLobbyCompanyProject.Data.Sql
{
    public class DSUserData
    {
        public DSUserData() { }
        public  byte[] GetPhoto(string filePath)
        {
            FileStream stream = new FileStream(
                filePath, FileMode.Open, FileAccess.Read);
            BinaryReader reader = new BinaryReader(stream);

            byte[] photo = reader.ReadBytes((int)stream.Length);

            reader.Close();
            stream.Close();

            return photo;
        }
        public object AddBusinessCompanyInformation(System.Data.SqlClient.SqlDataReader reader, System.Data.SqlClient.SqlCommand command, string UserId)
        {
            command.Parameters.AddWithValue("@User_Id", UserId);
            List<TBBusinessCompanyRepresentative> businessCompanyRepresentative = new List<TBBusinessCompanyRepresentative>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    businessCompanyRepresentative.Add(new TBBusinessCompanyRepresentative() { CompanyName = reader["CompanyName"].ToString(), Email = reader["Email"].ToString(), Phone_number = reader["Phone_number"].ToString(), RepresentativeFirstName = reader["RepresentativeFirstName"].ToString(), RepresentativeLastName = reader["RepresentativeLastName"].ToString(), Url = reader["Url"].ToString() });
                }
                return businessCompanyRepresentative;
            }           
            return null;
        }

        public object AddProLobbyOwnerInformation(System.Data.SqlClient.SqlDataReader reader, System.Data.SqlClient.SqlCommand command, string UserId)
        {
            command.Parameters.AddWithValue("@User_Id", UserId);
            List<TBProLobbyOwner> proLobbyOwner = new List<TBProLobbyOwner>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                   proLobbyOwner.Add(new TBProLobbyOwner() {FirstName = reader["FirstName"].ToString(),LastName = reader["LastName"].ToString(),Phone_number = reader["Phone_number"].ToString(),Email = reader["Email"].ToString() });
                }
                return proLobbyOwner;
            }
            return null;
        }

        public object AddNonProfitOrganizationInformation(System.Data.SqlClient.SqlDataReader reader, System.Data.SqlClient.SqlCommand command, string UserId)
        {
            command.Parameters.AddWithValue("@User_Id", UserId);
            List<TBNonProfitOrganization> nonProfitOrganization = new List<TBNonProfitOrganization>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    nonProfitOrganization.Add(new TBNonProfitOrganization() { NonProfitOrganizationName = reader["NonProfitOrganizationName"].ToString(),RepresentativeFirstName = reader["RepresentativeFirstName"].ToString(), RepresentativeLastName = reader["RepresentativeLastName"].ToString(),decreption = reader["decreption"].ToString(),Phone_number = reader["Phone_number"].ToString(),Email = reader["Email"].ToString(),Logo = GetPhoto(reader["logi"].ToString()), Url = reader["Url"].ToString()  });
                    
                }
                return nonProfitOrganization;
            }
            return null;
        }

        public object AddSocialActivistsInformation(System.Data.SqlClient.SqlDataReader reader, System.Data.SqlClient.SqlCommand command, string UserId)
        {
            command.Parameters.AddWithValue("@User_Id", UserId);
            List<TBSocialActivists> socialActivists = new List<TBSocialActivists>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    socialActivists.Add(new TBSocialActivists() {Address = reader["Address"].ToString(),Email = reader["Email"].ToString(),FirstName = reader["FirstName"].ToString(),LastName = reader["LastName"].ToString(),Phone_number = reader["Phone_number"].ToString(),Twitter_user = reader["Twitter_user"].ToString() });

                } 
                return socialActivists;
            }
            return null;
        }


        string insertBusinessCompany = "declare @User_Id nvarchar(max)\r\n\r\nif exists (select  [User_Id]  from [dbo].[TBBusinessCompanyRepresentatives] where [User_Id] = @User_Id)\r\nbegin\r\n       select [RepresentativeFirstName],\r\n\t   [RepresentativeLastName],\r\n\t   [RepresentativeLastName],\r\n\t   [CompanyName],[Url],\r\n\t   [Email],\r\n\t   [Phone_number]\r\n\t   from [dbo].[TBBusinessCompanyRepresentatives]\r\n\t   where [User_Id] = @User_Id\r\nend";

        string insertProLobbyOwner = "declare @User_Id  nvarchar(max) \r\nif exists (select  [User_Id]  from [dbo].[TBProLobbyOwners] where [User_Id] = @User_Id)\r\nbegin\r\n       select [FirstName],[LastName],[Email],[Phone_number]\r\n\t   from [dbo].[TBProLobbyOwners]\r\n\t   where [User_Id] = @User_Id\r\nend";

        
        string insertNonProfitOrganization = "declare @User_Id  nvarchar(max)\r\nif exists (select  [User_Id]  from [dbo].[TBNonProfitOrganizations] where [User_Id] = @User_Id)\r\nbegin\r\n       select [NonProfitOrganizationName],[Url],[decreption],[Email],[RepresentativeFirstName],\r\n[RepresentativeLastName],[Phone_number],[Logo]\r\n\t   from [dbo].[TBNonProfitOrganizations]\r\n\t   where [User_Id] = @User_Id\r\nend";

        
        string insertSocialActivists = "declare @User_Id nvarchar(max)\r\n\r\nif exists (select  [User_Id]  from [dbo].[TBBusinessCompanyRepresentatives] where [User_Id] = @User_Id)\r\nbegin\r\n       select [RepresentativeFirstName],\r\n\t   [RepresentativeLastName],\r\n\t   [RepresentativeLastName],\r\n\t   [CompanyName],[Url],\r\n\t   [Email],\r\n\t   [Phone_number]\r\n\t   from [dbo].[TBBusinessCompanyRepresentatives]\r\n\t   where [User_Id] = @User_Id\r\nend";

                

        public List<TBBusinessCompanyRepresentative> GetBusinessCompanyUserRow(string IdUser)
        {
            SqlQuery sqlQuery1 = new SqlQuery();
            List<TBBusinessCompanyRepresentative> BusinessCompanyList = null;   


               object listBusiness =  sqlQuery1.RunCommand(insertBusinessCompany, AddBusinessCompanyInformation, IdUser);

            if(listBusiness is List<TBBusinessCompanyRepresentative>)
            {
                BusinessCompanyList = (List<TBBusinessCompanyRepresentative>)listBusiness;
            }
            return BusinessCompanyList;
        }

        public List<TBProLobbyOwner> GetProLobbyOwnerUserRow(string IdUser)
        {
            SqlQuery sqlQuery1 = new SqlQuery();
            List<TBProLobbyOwner> ProLobbyOwnerList = null;
            object listProLobbyOwner = sqlQuery1.RunCommand(insertProLobbyOwner, AddProLobbyOwnerInformation, IdUser); ;

            if (listProLobbyOwner is List<TBProLobbyOwner>)
            {
                ProLobbyOwnerList = (List<TBProLobbyOwner>)listProLobbyOwner;
            }
            return ProLobbyOwnerList;
        }

        public List<TBNonProfitOrganization> GetNonProfitUserRow(string IdUser)
        {
            SqlQuery sqlQuery1 = new SqlQuery();
            List<TBNonProfitOrganization> NonProfitOrganization = null;
            object listNonProfitOrganization = sqlQuery1.RunCommand(insertNonProfitOrganization, AddNonProfitOrganizationInformation, IdUser); ;

            if (listNonProfitOrganization is List<TBNonProfitOrganization>)
            {
                NonProfitOrganization = (List<TBNonProfitOrganization>)listNonProfitOrganization;
            }
            return NonProfitOrganization;
        }

        public List<TBSocialActivists> GetSocialActivistsRow(string IdUser)
        {
            SqlQuery sqlQuery1 = new SqlQuery();
            List<TBSocialActivists> SocialActivists = null;
            object listSocialActivists = sqlQuery1.RunCommand(insertSocialActivists, AddSocialActivistsInformation, IdUser); ;

            if (listSocialActivists is List<TBSocialActivists>)
            {
                SocialActivists = (List<TBSocialActivists>)listSocialActivists;
            }
            return SocialActivists;
        }
    }
}
