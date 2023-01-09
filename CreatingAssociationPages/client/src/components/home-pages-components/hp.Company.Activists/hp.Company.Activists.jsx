import React from "react";
import { useNavigate } from "react-router-dom";

import { ExistRowUser } from "../../repeat/user-if-exist-repeat";
import { HomeOrganization } from "./../../../pages/home/home-organization/home-organization";
import { AboutCampaign } from "./../../../pages/organization/about-campaign/about-campaign";
import { ProductsList } from "./../../../pages/organization/products-list/products-list";

export const BusinessCompany_SocialActivists = ({ components }) => {
  let { userData, role1 } = ExistRowUser();
  let navigate = useNavigate();

  if (!(userData === null)) {
    return components === HomeOrganization ? (
      <HomeOrganization />
    ) : components === AboutCampaign ? (
      <AboutCampaign />
    ) : components === ProductsList ? (
      <ProductsList />
    ) : (
      <></>
    );
  } else {
    return (
      <>
        {role1.map((r) => {
          if (r.name === "BusinessCompanyRepresentative") navigate("/profile");
          else if (r.name === "SocialActivists") navigate("/profile");
        })}
      </>
    );
  }
};
