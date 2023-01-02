import React from "react";

import { HomeOrganization } from "../../../pages/home/home-organization/home-organization";
import { LoginNonProfitOrganization } from "../../login-components/login.NonProfitOrganization/login.NonProfitOrganization.components";
import { ExistRowUser } from "./../../repeat/user-if-exist-repeat";

export const NonProfitOrganizationHP = () => {
  const handleRowUser = () => {
    let userData = ExistRowUser();
    return userData;
  };

  if (!(handleRowUser() === null)) {
    return (
      <>
        <HomeOrganization />
      </>
    );
  } else {
    return <LoginNonProfitOrganization />;
  }
};
