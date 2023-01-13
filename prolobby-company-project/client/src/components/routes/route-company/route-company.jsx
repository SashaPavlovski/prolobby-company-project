import { Routes, Route } from "react-router-dom";

import { NavBarCompany } from "./../../navBar-users/navBar.Company/navBar.Company";
import { BusinessCompany_SocialActivists } from "../../home-pages-components";
import { HomeOrganization } from "../../../pages/home/home-organization/home-organization";
import { AboutCampaign } from "../../../pages/organization/about-campaign/about-campaign";
import { ProductsList } from "../../../pages/products/products-list/products-list";
import { LoginBusinessCompanyRepresentative } from "../../../pages/login-components";
import { DonateProduct } from "../../../pages/products/donate-product/donate-product";
import { DeliveryProductList } from "../../../pages/delivery-product-list/delivery-product-list";

export const RoutesBusinessCompanyRepresentative = () => {
  return (
    <>
      <NavBarCompany />
      <Routes>
        <Route
          path="/"
          element={
            <BusinessCompany_SocialActivists components={HomeOrganization} />
          }
        />
        <Route
          path="/profile"
          element={<LoginBusinessCompanyRepresentative />}
        />
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
          path="/donate-product"
          element={
            <BusinessCompany_SocialActivists components={DonateProduct} />
          }
        />
        <Route
          path="/delivery-List"
          element={
            <BusinessCompany_SocialActivists components={DeliveryProductList} />
          }
        />
      </Routes>
    </>
  );
};
