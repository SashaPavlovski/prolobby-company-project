using ProLobbyCompanyProject.Dal.SqlQueryClasses;
using System.Data.SqlClient;
using Utilities.Logger;

namespace ProLobbyCompanyProject.Data.Sql.Shippers
{
    public class DSShippersDeliveryProductSet: BaseDataSql
    {
        SqlQueryPost sqlQuery;
        public DSShippersDeliveryProductSet(Logger Logger) : base(Logger) 
        {
            sqlQuery = new SqlQueryPost();
        }

        /// <summary>
        /// Updating the DB sending the product delivery.
        /// </summary>
        /// <param name="UserId"> Shipper id - Data about the donated product and who bought it. </param>
        /// <param name="command"> Sql connection. </param>
        public void SendDeliveryProduct(object UserId,SqlCommand command)
        {
            Logger.LogEvent("Enter into SendDeliveryProduct function");

            try
            {
                Logger.LogEvent("Update sending the product to the operator.");

                command.Parameters.AddWithValue("@Shippers_Id", UserId);

                int rows = command.ExecuteNonQuery();

                Logger.LogEvent("End SendDeliveryProduct function, done successfully");

            }
            catch (SqlException EX)
            {

                throw;
            }
            catch (System.Exception EX)
            {

                throw;
            }
        }



        string insertSendDelivery = "declare @DonatedProducts_Id int\r\nif exists (select * from [dbo].[TBShippers] where [Shippers_Id] = @Shippers_Id and [Sent] = 1 )\r\n   begin\r\n   update [dbo].[TBShippers] set [Sent] = 0\r\n   where [Shippers_Id] = @Shippers_Id \r\n   SET @DonatedProducts_Id = (select  [DonatedProducts_Id] from [dbo].[TBShippers] where [Shippers_Id] = @Shippers_Id )\r\n   update [dbo].[TBDonatedProducts] set [Status_Product] = 3,[Active] = 0\r\n   where [DonatedProducts_Id] = @DonatedProducts_Id\r\nend";


        /// <summary>
        /// Updating the database on sending the product by the representative of a business company.
        /// </summary>
        /// <param name="IdUser"> Shipper id - Data about the donated product and who bought it. </param>
        public void SendingDeliveryProduct(string IdUser)
        {
            Logger.LogEvent("Enter into SendingDeliveryProduct function");

            try
            {
                sqlQuery.RunAddUser(insertSendDelivery, SendDeliveryProduct, IdUser);

                Logger.LogEvent("End SendingDeliveryProduct function, successfully");

            }
            catch (System.Exception EX)
            {

                throw;
            }
        }
    }
}
