import React from "react";
import { useNavigate } from "react-router-dom";

import { ExistRowUser } from "../../repeat/user-if-exist-repeat";
//import { HomeActivistsBusiness } from "../../../pages/home/home-activists-business/home-activists-business";
import { HomeOrganization } from "./../../../pages/home/home-organization/home-organization";

export const BusinessCompany_SocialActivists = () => {
  let { userData, role1 } = ExistRowUser();
  let navigate = useNavigate();

  if (!(userData === null)) {
    return <HomeOrganization />;
  } else {
    return (
      <>
        {role1.map((r) => {
          if (r.name === "BusinessCompanyRepresentative") navigate("/profile");
          else if (r.name === "SocialActivists") navigate("/profile");
        })}
      </>
    );
  }
};
