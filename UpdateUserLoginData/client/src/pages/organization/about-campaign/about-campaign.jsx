import React, { useContext } from "react";

import { useLocation, useNavigate } from "react-router-dom";
import { UserContext } from "../../../context/userData.context.js";

export const AboutCampaign = () => {
  const navigate = useNavigate();
  let { role1 } = useContext(UserContext);
  const location = useLocation();
  const {
    Campaigns_Id,
    Campaigns_Name,
    Hashtag,
    Descreption,
    NonProfitOrganizationName,
    decreption,
    Url,
  } = location.state;
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
        <p className="card-text">Purpose of the campaign: {Descreption}</p>
        <p className="card-text">Organization: {NonProfitOrganizationName}</p>
        <p className="card-text">About Us: {decreption}</p>
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
