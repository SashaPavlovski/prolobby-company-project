import React from "react";

export const UseFormAboutCampaign = ({
  Campaigns_Name,
  CampaignsDescreption,
  NonProfitOrganizationName,
  NonProfitOrganizationDecreption,
  Hashtag,
  Url,
  role1,
  productDonation,
  productsList,
  remove,
  joinUs,
}) => {
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
        <div>
          <a href={Url} className="btn btn-link">
            See More About Us
          </a>
        </div>
        {role1[0].name === "BusinessCompanyRepresentative" ? (
          <a className="btn btn-success" onClick={productDonation}>
            For product donation
          </a>
        ) : (
          <></>
        )}
        {role1[0].name === "SocialActivists" ||
        role1[0].name === "NonProfitOrganization" ||
        role1[0].name === "ProLobbyOwner" ? (
          <a className="btn btn-primary" onClick={productsList}>
            Products list
          </a>
        ) : (
          <></>
        )}
        {role1[0].name === "NonProfitOrganization" ||
        role1 === "ProLobbyOwner" ? (
          <a className="btn btn-danger" onClick={remove}>
            Remove
          </a>
        ) : (
          <></>
        )}
        {role1[0].name === "SocialActivists" ? (
          <a className="btn btn-primary" onClick={joinUs}>
            To join
          </a>
        ) : (
          <></>
        )}
      </div>
    </div>
  );
};
