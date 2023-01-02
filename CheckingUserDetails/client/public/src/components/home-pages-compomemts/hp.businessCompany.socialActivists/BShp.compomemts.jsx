import React, { useContext } from "react";

import { UserContext } from "../../../context/userData.context.js";
import { ExistRowUser } from "../../repeat/user-if-exist-repeat";
import { HomeActivistsBusiness } from "./../../../pages/home/home-activists-business/home-activists-business";
import {
  LoginBusinessCompanyRepresentative,
  LoginSocialActivists,
} from "../../login-components";

export const BusinessCompany_SocialActivists = () => {
  const { role1 } = useContext(UserContext);

  const handleRowUser = () => {
    let userData = ExistRowUser();
    return userData;
  };

  if (!(handleRowUser() === null)) {
    return (
      <>
        <HomeActivistsBusiness />
      </>
    );
  } else {
    return (
      <>
        {role1.map((r) => {
          if (r.name === "BusinessCompanyRepresentative") {
            return <LoginBusinessCompanyRepresentative />;
          } else if (r.name === "SocialActivists")
            return <LoginSocialActivists />;
        })}
      </>
    );
  }
};
