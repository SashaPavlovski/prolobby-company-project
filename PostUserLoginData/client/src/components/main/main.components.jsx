import React, { useState, useEffect } from "react";
import { Routes, Route, useNavigate } from "react-router-dom";

import { LogoutButton } from "../auth/buttons/logOut.buttons.auth0.components";
import { useAuth0 } from "@auth0/auth0-react";
import { UserContext } from "./../../context/userData.context";
import { GetRolesAsync } from "./../../services/services";
import { HomeActivistsBusiness } from "./../../pages/home/home-activists-business/home-activists-business";
import {
  NavBarCompany,
  NavBarActivists,
  NavBarOrganization,
  NavBarOwner,
} from "../navBar-users";
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

export const Main = () => {
  const { user } = useAuth0();
  const [role1, setRole] = useState([]);
  const [userData1, setUserData1] = useState(null);
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
      <UserContext.Provider value={{ role1, userData1, setUserData1 }}>
        {role1.length > 0 ? (
          role1.map((r) => {
            if (r.name === "NonProfitOrganization") {
              return NonProfitOrganizationRoute(userData1);
            } else if (r.name === "BusinessCompanyRepresentative") {
              return BusinessCompanyRepresentativeRoute(userData1);
            } else if (r.name === "ProLobbyOwner")
              return ProLobbyOwnerRoute(userData1);
            else if (r.name === "SocialActivists")
              return SocialActivistsRoute(userData1);
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

const NonProfitOrganizationRoute = (userData) => {
  return (
    <>
      <NavBarOrganization />
      <Routes>
        <Route path="/" element={<NonProfitOrganizationHP />} />
        <Route
          path="/profile"
          element={<LoginNonProfitOrganization userDetails={userData} />}
        />
      </Routes>
    </>
  );
};

const ProLobbyOwnerRoute = (userData) => {
  return (
    <>
      <NavBarOwner />
      <Routes>
        <Route path="/" element={<ProLobbyOwnerHP />} />
        <Route
          path="/profile"
          element={<LoginProLobbyOwner userDetails={userData} />}
        />
      </Routes>
    </>
  );
};

const SocialActivistsRoute = (userData) => {
  return (
    <>
      <NavBarActivists />
      <Routes>
        <Route path="/" element={<BusinessCompany_SocialActivists />} />
        <Route
          path="/profile"
          element={<LoginSocialActivists userDetails={userData} />}
        />
      </Routes>
    </>
  );
};

const BusinessCompanyRepresentativeRoute = (userData) => {
  return (
    <>
      <NavBarCompany />
      <Routes>
        <Route path="/" element={<BusinessCompany_SocialActivists />} />
        <Route
          path="/profile"
          element={
            <LoginBusinessCompanyRepresentative userDetails={userData} />
          }
        />
      </Routes>
    </>
  );
};
