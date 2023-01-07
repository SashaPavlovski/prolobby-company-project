import React from "react";
import { useNavigate } from "react-router-dom";

import { ExistRowUser } from "../../repeat/user-if-exist-repeat";
import { HomeActivistsBusiness } from "../../../pages/home/home-activists-business/home-activists-business";

export const BusinessCompany_SocialActivists = () => {
  let { userData, role1 } = ExistRowUser();
  let navigate = useNavigate();

  if (!(userData === null)) {
    return <HomeActivistsBusiness />;
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
