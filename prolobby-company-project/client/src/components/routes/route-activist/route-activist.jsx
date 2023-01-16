import { NavBarActivists } from "./../../navBar-users/navBar.Activists/navBar.Activists";
import { Routes, Route } from "react-router-dom";
import { BusinessCompany_SocialActivists } from "../../home-pages-components";
import { HomeAllCampaigns } from "../../../pages/home/home-home-all-campaigns/home-all-campaigns";
import { LoginSocialActivists } from "./../../../pages/login-components/login.SocialActivists/login.SocialActivists.components";
import { AboutCampaign } from "../../../pages/organization/about-campaign/about-campaign";
import { ProductsList } from "../../../pages/products/products-list/products-list";
import { UseMoneyTrackingShow } from "../../use-components/use-money-tracking/use-money-tracking-show/use-money-tracking-show";
import { ActivistProducts } from "./../../../pages/products/activist-products/activist-products";

export const RoutesSocialActivists = () => {
  return (
    <>
      <NavBarActivists />
      <Routes>
        <Route
          path="/"
          element={
            <BusinessCompany_SocialActivists components={HomeAllCampaigns} />
          }
        />
        <Route path="/profile" element={<LoginSocialActivists />} />
        <Route
          path="/about-campaign"
          element={
            <BusinessCompany_SocialActivists components={AboutCampaign} />
          }
        />
        <Route
          path="/products"
          element={
            <BusinessCompany_SocialActivists components={ProductsList} />
          }
        />
        <Route
          path="/my-money"
          element={
            <BusinessCompany_SocialActivists
              components={UseMoneyTrackingShow}
            />
          }
        />
        <Route
          path="/my-products"
          element={
            <BusinessCompany_SocialActivists components={ActivistProducts} />
          }
        />
      </Routes>
    </>
  );
};
