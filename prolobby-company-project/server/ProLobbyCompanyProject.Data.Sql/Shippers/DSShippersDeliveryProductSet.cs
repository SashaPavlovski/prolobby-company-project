using ProLobbyCompanyProject.Dal.SqlQueryClasses;
using Utilities.Logger;

namespace ProLobbyCompanyProject.Data.Sql.Shippers
{
    public class DSShippersDeliveryProductSet: BaseDataSql
    {
        public DSShippersDeliveryProductSet(Logger Logger) : base(Logger) { }

        //SendingDeliveryProduct
        public void SendDeliveryProduct(object UserId,System.Data.SqlClient.SqlCommand command)
        {
            try
            {
                command.Parameters.AddWithValue("@Shippers_Id", UserId);
                int rows = command.ExecuteNonQuery();
            }
            catch (System.Exception EX)
            {

                throw;
            }
        }



        string insertSendDelivery = "declare @DonatedProducts_Id int\r\nif exists (select * from [dbo].[TBShippers] where [Shippers_Id] = @Shippers_Id and [Sent] = 1 )\r\n   begin\r\n   update [dbo].[TBShippers] set [Sent] = 0\r\n   where [Shippers_Id] = @Shippers_Id \r\n   SET @DonatedProducts_Id = (select  [DonatedProducts_Id] from [dbo].[TBShippers] where [Shippers_Id] = @Shippers_Id )\r\n   update [dbo].[TBDonatedProducts] set [Status_Product] = 3,[Active] = 0\r\n   where [DonatedProducts_Id] = @DonatedProducts_Id\r\nend";


        public void SendingDeliveryProduct(string IdUser)
        {
            try
            {
                SqlQueryPost sqlQuery = new SqlQueryPost();
                sqlQuery.RunAddUser(insertSendDelivery, SendDeliveryProduct, IdUser);
            }
            catch (System.Exception EX)
            {

                throw;
            }
        }
    }
}
