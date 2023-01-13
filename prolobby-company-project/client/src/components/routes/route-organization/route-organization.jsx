import { NavBarOrganization } from "./../../navBar-users/navBar.Organization/navBar.Organization";
import { Routes, Route } from "react-router-dom";
import { AboutCampaign } from "../../../pages/organization/about-campaign/about-campaign";
import { ProductsList } from "../../../pages/products/products-list/products-list";
import { NonProfitOrganizationHP } from "../../home-pages-components";
import { LoginNonProfitOrganization } from "../../../pages/login-components";
import { CreateCampaign } from "../../../pages/organization/create-campaign/create-campaign";
import { AllCampaignsByIdOrganization } from "../../../pages/home/home-organization-by-id/home-organization-by-id";

export const RoutesNonProfitOrganization = () => {
  return (
    <>
      <NavBarOrganization />
      <Routes>
        <Route
          path="/"
          element={
            <NonProfitOrganizationHP
              components={AllCampaignsByIdOrganization}
            />
          }
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
