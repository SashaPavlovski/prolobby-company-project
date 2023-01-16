import React from "react";

import { UseValueCreateProduct } from "./../../../components/use-components/use-create-product/use-value-create-product/use-value-create-product";
import { UseFormCreateProduct } from "./../../../components/use-components/use-create-product/use-form-create-product/use-form-create-product";
import { UsePostCreateProduct } from "./../../../components/use-components/use-create-product/use-post-create-campaign/use-post-create-product";
import { Ifexist } from "./../../../components/repeat/user-if-exist";
import { useLocation, useNavigate } from "react-router-dom";

export const DonateProduct = () => {
  const navigate = useNavigate();
  const location = useLocation();
  const { Campaigns_Id } = location.state;
  console.log(`DonateProduct : enter : Campaigns_Id : ${Campaigns_Id}`);
  let { UseStatsVariables } = UseValueCreateProduct({});
  let {
    Product_NameV: { product_Name, setProduct_Name },
    PriceV: { price, setPrice },
    // PictureV: { setPicture },
    CountV: { count, setCount },
  } = UseStatsVariables;
  let { userDataRow } = Ifexist({});
  const sendingData = () => {
    if (userDataRow != null) {
      let userId = userDataRow.BusinessCompany_Id;
      let { sendData } = UsePostCreateProduct({
        UseStatsVariables,
        Campaigns_Id,
        userId,
      });
      navigate("/");
      sendData();
      alert("Thanks for the donation");
    }
  };

  return (
    <UseFormCreateProduct
      setProduct_Name={setProduct_Name}
      setPrice={setPrice}
      // setPicture={setPicture}
      setCount={setCount}
      sendingData={sendingData}
      product_Name={product_Name}
      price={price}
      count={count}
    />
  );
};
