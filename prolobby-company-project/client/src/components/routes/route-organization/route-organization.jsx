import { NavBarOrganization } from "./../../navBar-users/navBar.Organization/navBar.Organization";
import { Routes, Route } from "react-router-dom";
import { HomeOrganization } from "../../../pages/home/home-organization/home-organization";
import { AboutCampaign } from "../../../pages/organization/about-campaign/about-campaign";
import { ProductsList } from "../../../pages/products/products-list/products-list";
import { NonProfitOrganizationHP } from "../../home-pages-components";
import { LoginNonProfitOrganization } from "../../../pages/login-components";
import { CreateCampaign } from "../../../pages/organization/create-campaign/create-campaign";

export const RoutesNonProfitOrganization = () => {
  return (
    <>
      <NavBarOrganization />
      <Routes>
        <Route
          path="/"
          element={<NonProfitOrganizationHP components={HomeOrganization} />}
        />
        <Route path="/profile" element={<LoginNonProfitOrganization />} />
        <Route
          path="/create-campaign"
          element={<NonProfitOrganizationHP components={CreateCampaign} />}
        />
        <Route
          path="/about-campaign"
          element={<NonProfitOrganizationHP components={AboutCampaign} />}
        />
        <Route
          path="/products"
          element={<NonProfitOrganizationHP components={ProductsList} />}
        />
      </Routes>
    </>
  );
};
