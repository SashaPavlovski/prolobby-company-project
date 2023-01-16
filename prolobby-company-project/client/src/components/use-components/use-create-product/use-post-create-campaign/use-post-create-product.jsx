import { addUserDataAsync } from "../../../../services/services.js";

export const UsePostCreateProduct = ({
  UseStatsVariables,
  Campaigns_Id,
  userId,
}) => {
  let {
    Product_NameV: { product_Name },
    PriceV: { price },
    // PictureV: { picture },
    CountV: { count },
  } = UseStatsVariables;
  console.log(
    `UsePostCreateProduct : ${(UseStatsVariables, Campaigns_Id, userId, count)}`
  );

  const addNewProduct = async () => {
    console.log(product_Name, price, userId, count);
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
