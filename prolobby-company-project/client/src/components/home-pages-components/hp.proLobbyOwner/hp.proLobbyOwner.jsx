import { useNavigate } from "react-router-dom";

//import { HomeOwner } from "../../../pages/home/home-owner/home-owner";
import { ExistRowUser } from "../../repeat/user-if-exist-repeat";
import { HomeAllCampaigns } from "./../../../pages/home/home-home-all-campaigns/home-all-campaigns";
import { AboutCampaign } from "./../../../pages/organization/about-campaign/about-campaign";
import { ProductsList } from "./../../../pages/products/products-list/products-list";
import { SendCampaignsMoney } from "./../../../pages/send-campaigns-money/send-campaigns-money";

export const ProLobbyOwnerHP = ({ components }) => {
  let { userData } = ExistRowUser();
  let navigate = useNavigate();

  if (!(userData === null))
    return components === HomeAllCampaigns ? (
      <HomeAllCampaigns />
    ) : components === AboutCampaign ? (
      <AboutCampaign />
    ) : components === ProductsList ? (
      <ProductsList />
    ) : components === SendCampaignsMoney ? (
      <SendCampaignsMoney />
    ) : (
      <></>
    );
  else return navigate("/profile");
};
