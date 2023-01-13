import { useNavigate } from "react-router-dom";

import { ExistRowUser } from "../../repeat/user-if-exist-repeat";
import { CreateCampaign } from "../../../pages/organization/create-campaign/create-campaign";
import { AboutCampaign } from "./../../../pages/organization/about-campaign/about-campaign";
import { ProductsList } from "./../../../pages/products/products-list/products-list";
import { AllCampaignsByIdOrganization } from "../../../pages/home/home-organization-by-id/home-organization-by-id";

export const NonProfitOrganizationHP = ({ components }) => {
  let { userData } = ExistRowUser();
  let navigate = useNavigate();

  //  console.log("id - " + userData[0].NonProfitOrganization_Id);
  if (!(userData === null))
    return components === AllCampaignsByIdOrganization ? (
      <AllCampaignsByIdOrganization />
    ) : components === CreateCampaign ? (
      <CreateCampaign />
    ) : components === AboutCampaign ? (
      <AboutCampaign />
    ) : components === ProductsList ? (
      <ProductsList />
    ) : (
      <></>
    );
  else navigate("/profile");
};
