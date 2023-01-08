import React from "react";

import { useNavigate } from "react-router-dom";

export const CampaignCard = ({ campaignObject }) => {
  const navigate = useNavigate();

  let {
    Campaigns_Id,
    Campaigns_Name,
    Hashtag,
    Descreption,
    NonProfitOrganizationName,
    decreption,
    Url,
  } = campaignObject;

  const seeMore = () => {
    navigate("/about-campaign", {
      state: {
        Campaigns_Id,
        Campaigns_Name,
        Hashtag,
        Descreption,
        NonProfitOrganizationName,
        decreption,
        Url,
      },
    });
  };
  return (
    <div className="card text-center mb-3">
      <div className="card-body">
        <h5 className="card-title">{Campaigns_Name}</h5>
        <p className="card-text">{Descreption}</p>
        <a className="btn btn-primary" onClick={seeMore}>
          See More
        </a>
      </div>
    </div>
  );
};
