import React, { useState, useContext, useEffect } from "react";

import { UserInformationPage } from "./../../pages/userInformation/userInformation.pages";
import { UserContext } from "./../../context/userData.context";
import { GetUserDataAsync } from "../../services/services.js";
import { useAuth0 } from "@auth0/auth0-react";

import {
  ProLobbyOwnerHP,
  NonProfitOrganizationHP,
  BusinessCompany_SocialActivists,
} from "../home-pages-compomemts";

export const CheckingHomePage = () => {
  const [userData, setUserData] = useState([]);
  const { user } = useAuth0();
  const { role1 } = useContext(UserContext);
  console.log(role1.name);
  let userAuthId = user.sub;
  console.log(`userAuthId : ${userAuthId}`);

  const handleGetUserData = async (userId) => {
    let userRow = await GetUserDataAsync(role1[0].name, userId);
    console.log(`userRow : ${userId}`);
    setUserData(userRow);
    console.log(`userData: ${userData === null}`);
  };
  useEffect(() => {
    handleGetUserData(userAuthId);
  }, []);

  if (!(userData === null)) {
    console.log("ggg");
    return (
      <div>
        {role1 === "ProLobbyOwner" ? (
          <ProLobbyOwnerHP />
        ) : role1 === "NonProfitOrganization" ? (
          <NonProfitOrganizationHP />
        ) : role1 === "BusinessCompanyRepresentative" ||
          role1 === "SocialActivists" ? (
          <BusinessCompany_SocialActivists />
        ) : (
          <h1>CheckingHomePage Falde</h1>
        )}
        ;
      </div>
    );
  } else {
    console.log("ww");
    return (
      <h1>
        <UserInformationPage />
      </h1>
    );
  }
};
