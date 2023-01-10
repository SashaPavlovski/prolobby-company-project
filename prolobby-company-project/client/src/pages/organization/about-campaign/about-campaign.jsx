import React, { useContext, useState } from "react";

import { useLocation, useNavigate } from "react-router-dom";
import { UserContext } from "../../../context/userData.context.js";
import { DeleteAsync } from "../../../services/services.js";
import { UseGetCampaign } from "./../../../components/use-components/use-campaigns/use-get-campaign/use-get-campaign";
import { UseFormAboutCampaign } from "./../../../components/use-components/use-campaigns/use-form-about-campaign/use-form-about-campaign";

export const AboutCampaign = () => {
  let { role1 } = useContext(UserContext);
  const navigate = useNavigate();
  const location = useLocation();
  const { Campaigns_Id } = location.state;
  console.log(`Campaigns_Id : ${Campaigns_Id}`);
  const [campaign, setCampaign] = useState([]);
  console.log(`role1 : ${role1[0].name}`);
  let getCampaign = {
    type: "Campaigns",
    action: "getOneData",
    sortValue: Campaigns_Id,
    setfunc: setCampaign,
  };

  UseGetCampaign(getCampaign);
  let {
    Campaigns_Name,
    Hashtag,
    CampaignsDescreption,
    NonProfitOrganizationName,
    NonProfitOrganizationDecreption,
    Url,
  } = campaign;

  console.log(
    `AboutCampaign : ${
      (Campaigns_Name,
      Hashtag,
      CampaignsDescreption,
      NonProfitOrganizationName,
      NonProfitOrganizationDecreption,
      Url)
    }`
  );
  const productDonation = () => {
    navigate("/donate-product", {
      state: {
        Campaigns_Id,
      },
    });
  };
  const productsList = () => {
    navigate("/products", {
      state: {
        Campaigns_Id,
      },
    });
  };
  const remove = async () => {
    await DeleteAsync("Campaigns", "deleteData", Campaigns_Id);
    navigate("/");
  };
  return (
    <UseFormAboutCampaign
      Campaigns_Name={Campaigns_Name}
      CampaignsDescreption={CampaignsDescreption}
      NonProfitOrganizationName={NonProfitOrganizationName}
      NonProfitOrganizationDecreption={NonProfitOrganizationDecreption}
      Hashtag={Hashtag}
      Url={Url}
      role1={role1}
      productDonation={productDonation}
      productsList={productsList}
      remove={remove}
    />
  );
};
