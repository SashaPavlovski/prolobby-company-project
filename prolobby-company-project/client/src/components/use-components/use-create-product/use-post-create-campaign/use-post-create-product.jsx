import { addUserDataAsync } from "../../../../services/services.js";

//sends the product data to cs
//The number of times its donated
export const UsePostCreateProduct = ({
  UseStatsVariables,
  Campaigns_Id,
  userId,
}) => {
  let {
    Product_NameV: { product_Name },
    PriceV: { price },
    CountV: { count },
  } = UseStatsVariables;

  const addNewProduct = async () => {
    for (let i = 0; i < count; i++) {
      await addUserDataAsync("DonatedProducts", "addData", {
        BusinessCompany_Id: userId,
        Campaigns_Id: Campaigns_Id,
        Product_Name: product_Name,
        Price: parseFloat(price),
      });
    }
  };

  const sendData = async () => {
    await addNewProduct();
  };

  return { sendData };
};
