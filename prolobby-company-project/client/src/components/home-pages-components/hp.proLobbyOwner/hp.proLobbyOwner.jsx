import { useNavigate } from "react-router-dom";

import { ExistRowUser } from "../../repeat/user-if-exist-repeat";
import { HomeAllCampaigns } from "./../../../pages/home/home-home-all-campaigns/home-all-campaigns";
import { AboutCampaign } from "./../../../pages/organization/about-campaign/about-campaign";
import { ProductsList } from "./../../../pages/products/products-list/products-list";
import { SendCampaignsMoney } from "./../../../pages/send-campaigns-money/send-campaigns-money";
import { ReportsCampaigns } from "./../../../pages/reports/reports-campaigns/reports-campaigns";
import { ReportsPosts } from "./../../../pages/reports/reports-posts/reports-posts";
import { ReportsUsers } from "./../../../pages/reports/reports-users/reports-users";
import { ReportsProducts } from "./../../../pages/reports/reports-products/reports-products";

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
    ) : components === ReportsCampaigns ? (
      <ReportsCampaigns />
    ) : components === ReportsPosts ? (
      <ReportsPosts />
    ) : components === ReportsUsers ? (
      <ReportsUsers />
    ) : components === ReportsProducts ? (
      <ReportsProducts />
    ) : (
      <></>
    );
  else return navigate("/profile");
};
