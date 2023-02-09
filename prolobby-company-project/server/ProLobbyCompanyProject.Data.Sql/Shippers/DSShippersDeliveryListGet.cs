using ProLobbyCompanyProject.Dal;
using ProLobbyCompanyProject.Model.Shippers;
using System.Collections.Generic;
using Utilities.Logger;

namespace ProLobbyCompanyProject.Data.Sql.Shippers
{
    public class DSShippersDeliveryListGet: BaseDataSql
    {
        //Receiving a shipment schedule
        public DSShippersDeliveryListGet(Logger Logger) : base(Logger) { }
        public object AddDeliveryList(System.Data.SqlClient.SqlDataReader reader, System.Data.SqlClient.SqlCommand command, string UserId)
        {
            List<MADeliveryProductList> DeliveryListData = new List<MADeliveryProductList>();
            if (reader.HasRows)
            {
                try
                {
                    while (reader.Read())
                    {
                        DeliveryListData.Add(new MADeliveryProductList() { Shippers_Id = int.Parse(reader["Shippers_Id"].ToString()), FullName = reader["Full_Name"].ToString(), Product_Name = reader["Product_Name"].ToString(), Phone_number = reader["Phone_number"].ToString(), Email = reader["Email"].ToString(), Address = reader["Address"].ToString(), Sent = bool.Parse(reader["Sent"].ToString()) });
                    }
                }
                catch (System.Exception EX)
                {

                    throw;
                }
                return DeliveryListData;
            }
            return null;
        }


        public void SetValues(System.Data.SqlClient.SqlCommand command, string key, string value, string key2, string value2)
        {
            return;
        }

        //Creating a shipping table
        string insertGetData = "select TB2.Shippers_Id,TB3.Product_Name,TB1.FirstName +' ' +TB1.LastName AS 'Full_Name',TB1.Email,\r\nTB1.Phone_number,TB1.Address,TB2.Sent\r\nfrom [dbo].[TBSocialActivists] TB1 inner join [dbo].[TBShippers] TB2\r\non TB1.SocialActivists_Id =  TB2.SocialActivists_Id inner join [dbo].[TBDonatedProducts] TB3 \r\non TB2.DonatedProducts_Id = TB3.DonatedProducts_Id";

        //Sending to dal
        //Receiving a list of Delivery
        public List<MADeliveryProductList> GetDeliveryListProduct()
        {
            SqlQuery sqlQuery1 = new SqlQuery();
            List<MADeliveryProductList> newData = null;
            object listNewData;
            try
            {
                listNewData = sqlQuery1.RunCommand(insertGetData, AddDeliveryList, SetValues, null, null, null, null);
            }
            catch (System.Exception EX)
            {

                throw;
            }

            if (listNewData is List<MADeliveryProductList>)
            {
                newData = (List<MADeliveryProductList>)listNewData;
            }
            return newData;
        }

    }
}
