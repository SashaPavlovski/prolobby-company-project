import React from "react";
import { useNavigate } from "react-router-dom";

import { HomeOrganization } from "../../../pages/home/home-organization/home-organization";
import { ExistRowUser } from "../../repeat/user-if-exist-repeat";

export const NonProfitOrganizationHP = () => {
  let { userData } = ExistRowUser();
  let navigate = useNavigate();

  if (!(userData === null)) return <HomeOrganization />;
  else navigate("/profile");
};
