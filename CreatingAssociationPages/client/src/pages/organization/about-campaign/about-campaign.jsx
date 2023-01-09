import React, { useContext, useState } from "react";

import { useLocation, useNavigate } from "react-router-dom";
import { UserContext } from "../../../context/userData.context.js";
import { UseGetCampaign } from "./../../../components/use-components/use-campaigns/use-get-campaign/use-get-campaign";

export const AboutCampaign = () => {
  let { role1 } = useContext(UserContext);
  const navigate = useNavigate();
  const location = useLocation();
  const { Campaigns_Id } = location.state;
  console.log(`Campaigns_Id : ${Campaigns_Id}`);
  const [campaign, setCampaign] = useState([]);

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
  const productDonation = () => {};
  const productsList = () => {
    navigate("/products", {
      state: {
        Campaigns_Id,
      },
    });
  };
  const remove = () => {};
  return (
    <div className="card text-center mb-3">
      <div className="card-body">
        <h4 className="card-title">{Campaigns_Name}</h4>
        <p className="card-text">
          Purpose of the campaign: {CampaignsDescreption}
        </p>
        <p className="card-text">Organization: {NonProfitOrganizationName}</p>
        <p className="card-text">About Us: {NonProfitOrganizationDecreption}</p>
        <h5 className="card-title">Our hashtag: {Hashtag}</h5>
        <a href={Url} className="btn btn-link">
          See More About Us
        </a>
        {role1 === "BusinessCompanyRepresentative" ? (
          <a className="btn btn-success" onClick={productDonation}>
            For product donation
          </a>
        ) : (
          <></>
        )}
        {role1 === "SocialActivists" ||
        role1 === "NonProfitOrganization" ||
        role1 === "ProLobbyOwner" ? (
          <a className="btn btn-primary" onClick={productsList}>
            Products list
          </a>
        ) : (
          <></>
        )}
        {role1 === "NonProfitOrganization" || role1 === "ProLobbyOwner" ? (
          <a className="btn btn-danger" onClick={remove}>
            Remove
          </a>
        ) : (
          <></>
        )}
      </div>
    </div>
  );
};
