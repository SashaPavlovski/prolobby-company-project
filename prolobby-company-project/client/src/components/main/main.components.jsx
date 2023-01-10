import React, { useState, useEffect } from "react";
import { Routes, Route, useNavigate } from "react-router-dom";

import { LogoutButton } from "../auth/buttons/logOut.buttons.auth0.components";
import { useAuth0 } from "@auth0/auth0-react";
import { UserContext } from "./../../context/userData.context";
import { GetRolesAsync } from "./../../services/services";
import { HomeActivistsBusiness } from "./../../pages/home/home-activists-business/home-activists-business";
import { CreateCampaign } from "../../pages/organization/create-campaign/create-campaign";
import { AboutCampaign } from "./../../pages/organization/about-campaign/about-campaign";
import { ProductsList } from "./../../pages/products/products-list/products-list";
import {
  NavBarCompany,
  NavBarActivists,
  NavBarOrganization,
  NavBarOwner,
} from "../navBar-users";
import { HomeOrganization } from "./../../pages/home/home-organization/home-organization";

import {
  ProLobbyOwnerHP,
  NonProfitOrganizationHP,
  BusinessCompany_SocialActivists,
} from "../home-pages-components";
import {
  LoginProLobbyOwner,
  LoginBusinessCompanyRepresentative,
  LoginNonProfitOrganization,
  LoginSocialActivists,
} from "../../pages/login-components";
import { DonateProduct } from "../../pages/products/donate-product/donate-product";

export const Main = () => {
  const { user } = useAuth0();
  const [role1, setRole] = useState([]);

  let userId = user.sub;
  const handleRoles1 = async () => {
    let roles = await GetRolesAsync(userId);
    setRole(roles);
  };
  useEffect(() => {
    handleRoles1();
    console.log("enter");
  }, []);

  return (
    <>
      <UserContext.Provider value={{ role1, userId }}>
        {role1.length > 0 ? (
          role1.map((r) => {
            if (r.name === "NonProfitOrganization") {
              return NonProfitOrganizationRoute();
            } else if (r.name === "BusinessCompanyRepresentative") {
              return BusinessCompanyRepresentativeRoute();
            } else if (r.name === "ProLobbyOwner") return ProLobbyOwnerRoute();
            else if (r.name === "SocialActivists")
              return SocialActivistsRoute();
            else
              return (
                <>
                  <HomeActivistsBusiness />
                </>
              );
          })
        ) : (
          <>
            <h1>Please wait until Data validation</h1>
            <LogoutButton />
          </>
        )}
      </UserContext.Provider>
    </>
  );
};

const NonProfitOrganizationRoute = () => {
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

const ProLobbyOwnerRoute = () => {
  return (
    <>
      <NavBarOwner />
      <Routes>
        <Route
          path="/"
          element={<ProLobbyOwnerHP components={HomeOrganization} />}
        />
        <Route path="/profile" element={<LoginProLobbyOwner />} />
        <Route
          path="/about-campaign"
          element={<ProLobbyOwnerHP components={AboutCampaign} />}
        />
        <Route
          path="/products"
          element={<ProLobbyOwnerHP components={ProductsList} />}
        />
      </Routes>
    </>
  );
};

const SocialActivistsRoute = () => {
  return (
    <>
      <NavBarActivists />
      <Routes>
        <Route
          path="/"
          element={
            <BusinessCompany_SocialActivists components={HomeOrganization} />
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
      </Routes>
    </>
  );
};

const BusinessCompanyRepresentativeRoute = () => {
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
      </Routes>
    </>
  );
};
