import React, { useState, useEffect } from "react";

import { useAuth0 } from "@auth0/auth0-react";
import { GetRolesAsync } from "./../../services/services";
import { CheckingHomePage } from "./../../components/checking-home-page/checking.hp.components";
import { UserContext } from "./../../context/userData.context";
import { BusinessCompany_SocialActivists } from "../../components/home-pages-compomemts/hp.businessCompany.socialActivists/BShp.compomemts";

export const HomePage = () => {
  const { user } = useAuth0();
  const [role1, setRole] = useState([]);
  console.log(role1);
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
    <UserContext.Provider value={{ role1 }}>
      {role1.length > 0 ? (
        <CheckingHomePage />
      ) : (
        <BusinessCompany_SocialActivists />
      )}
    </UserContext.Provider>
  );
};
