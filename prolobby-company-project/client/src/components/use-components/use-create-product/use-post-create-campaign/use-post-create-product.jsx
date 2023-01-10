import { addUserDataAsync } from "../../../../services/services.js";

export const UsePostCreateProduct = ({
  UseStatsVariables,
  Campaigns_Id,
  userId,
}) => {
  console.log(
    `UsePostCreateProduct : ${(UseStatsVariables, Campaigns_Id, userId)}`
  );
  let {
    Product_NameV: { product_Name },
    PriceV: { price },
    PictureV: { picture },
  } = UseStatsVariables;

  const addNewProduct = async () => {
    console.log(product_Name, price, userId);
    return await addUserDataAsync("DonatedProducts", "getData", {
      BusinessCompany_Id: userId,
      Campaigns_Id: Campaigns_Id,
      Product_Name: product_Name,
      Price: price,
    });
  };

  const sendData = async () => {
    let answer = await addNewProduct();
    console.log("answer : " + answer);
    return answer;
  };

  return { sendData };
};
