import React, { useState, useEffect } from "react";

import { LogoutButton } from "../auth/buttons/logOut.buttons.auth0.components";
import { useAuth0 } from "@auth0/auth0-react";
import { UserContext } from "./../../context/userData.context";
import { GetRolesAsync } from "./../../services/services";
import {
  RoutesBusinessCompanyRepresentative,
  RoutesNonProfitOrganization,
  RoutesSocialActivists,
  RoutesProLobbyOwner,
} from "../routes";

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
              return RoutesNonProfitOrganization();
            } else if (r.name === "BusinessCompanyRepresentative") {
              return RoutesBusinessCompanyRepresentative();
            } else if (r.name === "ProLobbyOwner") return RoutesProLobbyOwner();
            else if (r.name === "SocialActivists")
              return RoutesSocialActivists();
            else return <></>;
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
