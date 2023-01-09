import { useNavigate } from "react-router-dom";

//import { HomeOwner } from "../../../pages/home/home-owner/home-owner";
import { ExistRowUser } from "../../repeat/user-if-exist-repeat";
import { HomeOrganization } from "./../../../pages/home/home-organization/home-organization";
import { AboutCampaign } from "./../../../pages/organization/about-campaign/about-campaign";
import { ProductsList } from "./../../../pages/organization/products-list/products-list";

export const ProLobbyOwnerHP = ({ components }) => {
  let { userData } = ExistRowUser();
  let navigate = useNavigate();

  if (!(userData === null))
    return components === HomeOrganization ? (
      <HomeOrganization />
    ) : components === AboutCampaign ? (
      <AboutCampaign />
    ) : components === ProductsList ? (
      <ProductsList />
    ) : (
      <></>
    );
  else return navigate("/profile");
};
