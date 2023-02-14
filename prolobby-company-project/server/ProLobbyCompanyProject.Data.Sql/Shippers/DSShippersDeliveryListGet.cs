using ProLobbyCompanyProject.Dal;
using ProLobbyCompanyProject.Model.Shippers;
using System.Collections.Generic;
using System.Data.SqlClient;
using Utilities.Logger;

namespace ProLobbyCompanyProject.Data.Sql.Shippers
{
    public class DSShippersDeliveryListGet: BaseDataSql
    {
        SqlQuery SqlQuery;

        public DSShippersDeliveryListGet(Logger Logger) : base(Logger)
        {
            SqlQuery = new SqlQuery();
        }


        /// <summary>
        /// Get list of delivery details.
        /// </summary>
        /// <param name="reader"> Get data from the sql. </param>
        /// <param name="command"> SQL connection. </param>
        /// <param name="UserId"></param>
        /// <returns> list of delivery details. </returns>
        public object AddDeliveryList(SqlDataReader reader, SqlCommand command, string UserId)
        {
            Logger.LogEvent("Enter into AddDeliveryList function");

            List<MADeliveryProductList> DeliveryListData = new List<MADeliveryProductList>();

            try
            {
                if (reader.HasRows)
                {
                    Logger.LogEvent("Start get list of delivery details.");

                    while (reader.Read())
                    {
                        DeliveryListData.Add(new MADeliveryProductList
                        {
                            Shippers_Id = int.Parse(reader["Shippers_Id"].ToString()),
                            FullName = reader["Full_Name"].ToString(),
                            Product_Name = reader["Product_Name"].ToString(),
                            Phone_number = reader["Phone_number"].ToString(),
                            Email = reader["Email"].ToString(),
                            Address = reader["Address"].ToString(),
                            Sent = bool.Parse(reader["Sent"].ToString())
                        });
                    }

                    Logger.LogEvent("End AddDeliveryList function, return list of delivery.");

                    return DeliveryListData;
                }

                Logger.LogEvent("End AddDeliveryList function, return null.");

                return null;
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
        }

        public void SetValues(SqlCommand command, string key, string value, string key2, string value2)
        {
            return;
        }

        /// <summary>
        /// sql query that get data of the shipments
        /// </summary>
        string insertGetData = "select TB2.Shippers_Id,TB3.Product_Name,TB1.FirstName +' ' +TB1.LastName AS 'Full_Name',TB1.Email,\r\nTB1.Phone_number,TB1.Address,TB2.Sent\r\nfrom [dbo].[TBSocialActivists] TB1 inner join [dbo].[TBShippers] TB2\r\non TB1.SocialActivists_Id =  TB2.SocialActivists_Id inner join [dbo].[TBDonatedProducts] TB3 \r\non TB2.DonatedProducts_Id = TB3.DonatedProducts_Id";


        /// <summary>
        /// Get delivery details of social activists
        /// </summary>
        /// <returns> List of Delivery data. </returns>
        public List<MADeliveryProductList> GetDeliveryListProduct()
        {
            Logger.LogEvent("\n\nEnter into GetDeliveryListProduct function");

            List<MADeliveryProductList> newData = null;
            object listNewData;

            try
            {
                listNewData = SqlQuery.RunCommand(insertGetData, AddDeliveryList, SetValues, null, null, null, null);

                Logger.LogEvent("The operation of receiving the details of the shipments was done successfully");

            }
            catch (System.Exception Ex) { Logger.LogException(Ex.Message, Ex); throw; }



            if (listNewData != null && listNewData is List<MADeliveryProductList>)
            {
                newData = (List<MADeliveryProductList>)listNewData;

                Logger.LogEvent("End GetDeliveryListProduct function, return Delivery list");


                return newData;

            }

            Logger.LogEvent("End GetDeliveryListProduct function, return null");

            return newData;
        }
    }
}
