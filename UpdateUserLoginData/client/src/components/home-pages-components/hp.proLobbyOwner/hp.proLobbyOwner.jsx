import React from "react";
import { useNavigate } from "react-router-dom";

//import { HomeOwner } from "../../../pages/home/home-owner/home-owner";
import { ExistRowUser } from "../../repeat/user-if-exist-repeat";
import { HomeOrganization } from "./../../../pages/home/home-organization/home-organization";

export const ProLobbyOwnerHP = () => {
  let { userData } = ExistRowUser();
  let navigate = useNavigate();

  if (!(userData === null)) return <HomeOrganization />;
  else return navigate("/profile");
};
