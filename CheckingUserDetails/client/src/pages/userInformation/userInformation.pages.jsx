import React, { useState, useEffect } from "react";

import { useAuth0 } from "@auth0/auth0-react";
import { GetRolesAsync } from "./../../services/services";
import {
  LoginProLobbyOwner,
  LoginBusinessCompanyRepresentative,
  LoginNonProfitOrganization,
  LoginSocialActivists,
} from "../../components/login-components";

export const UserInformationPage = () => {
  const { user } = useAuth0();
  const [role1, setRole] = useState([]);
  let userId = user.sub;
  const handleRoles1 = async () => {
    let roles = await GetRolesAsync(userId);
    setRole(roles);
  };
  useEffect(() => {
    handleRoles1();
  }, []);

  return (
    <>
      {role1.length > 0
        ? role1.map((r) => {
            debugger;
            if (r.name === "ProLobbyOwner") return <LoginProLobbyOwner />;
            else if (r.name === "BusinessCompanyRepresentative") {
              return <LoginBusinessCompanyRepresentative />;
            } else if (r.name === "NonProfitOrganization")
              return <LoginNonProfitOrganization />;
            else if (r.name === "SocialActivists")
              return <LoginSocialActivists />;
            else return <h1>bay</h1>;
          })
        : "loading"}
    </>
  );
};
