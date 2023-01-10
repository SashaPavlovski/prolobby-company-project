using ProLobbyCompanyProject.Dal;
using ProLobbyCompanyProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProLobbyCompanyProject.Data.Sql
{
    public class DSBusinessCompanyRepresentativesGet
    {
        public DSBusinessCompanyRepresentativesGet (){}

        public object AddBusinessCompanyInformation(System.Data.SqlClient.SqlDataReader reader, System.Data.SqlClient.SqlCommand command, string UserId)
        {
            List<TBBusinessCompanyRepresentative> businessCompanyRepresentative = new List<TBBusinessCompanyRepresentative>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    businessCompanyRepresentative.Add(new TBBusinessCompanyRepresentative() {BusinessCompany_Id = int.Parse(reader["BusinessCompany_Id"].ToString()) ,CompanyName = reader["CompanyName"].ToString(), Email = reader["Email"].ToString(), Phone_number = reader["Phone_number"].ToString(), RepresentativeFirstName = reader["RepresentativeFirstName"].ToString(), RepresentativeLastName = reader["RepresentativeLastName"].ToString(), Url = reader["Url"].ToString() });
                }
                return businessCompanyRepresentative;
            }
            return null;
        }

        string insertBusinessCompany = "if exists (select  [User_Id]  from [dbo].[TBBusinessCompanyRepresentatives] where [User_Id] = @User_Id)\r\nbegin\r\n       select BusinessCompany_Id,[RepresentativeFirstName],\r\n\t   [RepresentativeLastName],\r\n\t [RepresentativeLastName],\r\n\t [CompanyName],[Url],\r\n\t  [Email],\r\n\t [Phone_number]\r\n\t from [dbo].[TBBusinessCompanyRepresentatives]\r\n\twhere [User_Id] = @User_Id\r\nend\r\n";

        public List<TBBusinessCompanyRepresentative> GetBusinessCompanyUserRow(string IdUser)
        {
            SqlQuery sqlQuery1 = new SqlQuery();
            List<TBBusinessCompanyRepresentative> BusinessCompanyList = null;


            object listBusiness = sqlQuery1.RunCommand(insertBusinessCompany, AddBusinessCompanyInformation, "User_Id", IdUser,null,null);

            if (listBusiness is List<TBBusinessCompanyRepresentative>)
            {
                BusinessCompanyList = (List<TBBusinessCompanyRepresentative>)listBusiness;
            }
            return BusinessCompanyList;
        }
    }
}
