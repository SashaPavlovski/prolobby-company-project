import React from "react";
import { HomeOrganization } from "./../../../../pages/home/home-organization/home-organization";
import { AboutCampaign } from "./../../../../pages/organization/about-campaign/about-campaign";
import { ProductsList } from "./../../../../pages/products/products-list/products-list";
import { DonateProduct } from "./../../../../pages/products/donate-product/donate-product";
import { UseMoneyTrackingShow } from './../../../use-components/use-money-tracking/use-money-tracking-show/use-money-tracking-show';

export const BusinessCompanyRoutes = ({ components }) => {
  return components === HomeOrganization ? (
    <HomeOrganization />
  ) : components === AboutCampaign ? (
    <AboutCampaign />
  ) : components === ProductsList ? (
    <ProductsList />
  ) : components === DonateProduct ? (
    <DonateProduct />
  ) : (
    <></>
  );
};
export const SocialActivistsRoutes = ({ components }) => {
  return components === HomeOrganization ? (
    <HomeOrganization />
  ) : components === AboutCampaign ? (
    <AboutCampaign />
  ) : components === ProductsList ? (
    <ProductsList />
  ) : components === UseMoneyTrackingShow ? (
    <UseMoneyTrackingShow />
  ) : (
    <></>
  );
};
