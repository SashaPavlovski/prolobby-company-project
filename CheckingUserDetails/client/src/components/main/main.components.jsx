import React, { useState, useEffect } from "react";
import { Routes, Route } from "react-router-dom";

import { useAuth0 } from "@auth0/auth0-react";
import { UserContext } from "./../../context/userData.context";
import { GetRolesAsync } from "./../../services/services";
import { NavBar } from "./../navBar/navBar.components";
import { HomeActivistsBusiness } from "./../../pages/home/home-activists-business/home-activists-business";
import {
  ProLobbyOwnerHP,
  NonProfitOrganizationHP,
  BusinessCompany_SocialActivists,
} from "../home-pages-compomemts";
import {
  LoginProLobbyOwner,
  LoginBusinessCompanyRepresentative,
  LoginNonProfitOrganization,
  LoginSocialActivists,
} from "../login-components";

export const Main = () => {
  const { user } = useAuth0();
  const [role1, setRole] = useState([]);
  console.log(role1.name + "eeeee");
  let userId = user.sub;
  const handleRoles1 = async () => {
    let roles = await GetRolesAsync(userId);
    console.log(roles.length + "pp");
    setRole(roles);
  };
  useEffect(() => {
    handleRoles1();
    console.log("enter");
  }, []);

  return (
    <>
      <UserContext.Provider value={{ role1 }}>
        <NavBar />
        {role1.length > 0 ? (
          role1.map((r) => {
            if (r.name === "NonProfitOrganization")
              return NonProfitOrganizationRoute();
            else if (r.name === "BusinessCompanyRepresentative") {
              return (
                <>
                  {console.log("ff")}
                  {BusinessCompanyRepresentativeRoute()}
                </>
              );
            } else if (r.name === "ProLobbyOwner") return ProLobbyOwnerRoute();
            else if (r.name === "SocialActivists")
              return SocialActivistsRoute();
            else
              return (
                <>
                  <h6>bay</h6>
                  <HomeActivistsBusiness />
                </>
              );
          })
        ) : (
          <>Please wait until Data validation</>
        )}
      </UserContext.Provider>
    </>
  );
};

const NonProfitOrganizationRoute = () => {
  return (
    <Routes>
      <Route path="/" element={<NonProfitOrganizationHP />} />
      <Route path="/contactUs" element={<LoginNonProfitOrganization />} />
    </Routes>
  );
};

const ProLobbyOwnerRoute = () => {
  return (
    <Routes>
      <Route path="/" element={<ProLobbyOwnerHP />} />
      <Route path="/contactUs" element={<LoginProLobbyOwner />} />
    </Routes>
  );
};

const SocialActivistsRoute = () => {
  return (
    <Routes>
      <Route path="/" element={<BusinessCompany_SocialActivists />} />
      <Route
        path="/contactUs"
        element={<LoginBusinessCompanyRepresentative />}
      />
    </Routes>
  );
};

const BusinessCompanyRepresentativeRoute = () => {
  return (
    <Routes>
      <Route path="/" element={<BusinessCompany_SocialActivists />} />
      <Route path="/contactUs" element={<LoginSocialActivists />} />
    </Routes>
  );
};
