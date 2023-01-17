import React from "react";

import { HomeAllCampaigns } from "./../../../../pages/home/home-home-all-campaigns/home-all-campaigns";
import { AboutCampaign } from "./../../../../pages/organization/about-campaign/about-campaign";
import { ProductsList } from "./../../../../pages/products/products-list/products-list";
import { DonateProduct } from "./../../../../pages/products/donate-product/donate-product";
import { UseMoneyTrackingShow } from "./../../../use-components/use-money-tracking/use-money-tracking-show/use-money-tracking-show";
import { ActivistProducts } from "./../../../../pages/products/activist-products/activist-products";
import { DeliveryProductList } from "./../../../../pages/delivery-product-list/delivery-product-list";

//Checks whether the user is already registered in the system
export const BusinessCompanyRoutes = ({ components }) => {
  return components === HomeAllCampaigns ? (
    <HomeAllCampaigns />
  ) : components === AboutCampaign ? (
    <AboutCampaign />
  ) : components === ProductsList ? (
    <ProductsList />
  ) : components === DonateProduct ? (
    <DonateProduct />
  ) : components === DeliveryProductList ? (
    <DeliveryProductList />
  ) : (
    <></>
  );
};

//Checks whether the user is already registered in the system
export const SocialActivistsRoutes = ({ components }) => {
  return components === HomeAllCampaigns ? (
    <HomeAllCampaigns />
  ) : components === AboutCampaign ? (
    <AboutCampaign />
  ) : components === ProductsList ? (
    <ProductsList />
  ) : components === UseMoneyTrackingShow ? (
    <UseMoneyTrackingShow />
  ) : components === ActivistProducts ? (
    <ActivistProducts />
  ) : (
    <></>
  );
};
