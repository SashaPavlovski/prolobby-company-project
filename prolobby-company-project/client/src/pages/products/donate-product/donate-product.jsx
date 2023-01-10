import React, { useContext } from "react";

import { UserContext } from "../../../context/userData.context.js";
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
  // const { userId } = useContext(UserContext);
  let { UseStatsVariables } = UseValueCreateProduct({});

  let {
    Product_NameV: { setProduct_Name },
    PriceV: { setPrice },
    PictureV: { setPicture },
  } = UseStatsVariables;

  let { userDataRow, user } = Ifexist({});

  const sendingData = () => {
    if (userDataRow != null) {
      let userId = userDataRow.BusinessCompany_Id;
      console.log("ente!!!!!!!!r : " + userDataRow.BusinessCompany_Id);
      let { sendData } = UsePostCreateProduct({
        UseStatsVariables,
        Campaigns_Id,
        userId,
      });
      sendData();
    }
  };
  //שם התורם
  //את מי הוא מייצג
  //מה הוא רוצה לתרום
  //מה המחיר שלו
  //תמונה של התרומה
  //לעשות הודעה קופצת תודה שתרמתה
  return (
    <UseFormCreateProduct
      setProduct_Name={setProduct_Name}
      setPrice={setPrice}
      setPicture={setPicture}
      sendingData={sendingData}
    />
  );
};
