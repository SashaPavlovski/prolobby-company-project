import React from "react";
import { useNavigate } from "react-router-dom";

import { ExistRowUser } from "../../repeat/user-if-exist-repeat";
import {
  BusinessCompanyRoutes,
  SocialActivistsRoutes,
} from "./routes-components/routes-components";

export const BusinessCompany_SocialActivists = ({ components }) => {
  let { userData, role1 } = ExistRowUser();
  let navigate = useNavigate();

  if (!(userData === null)) {
    if (role1[0].name === "BusinessCompanyRepresentative")
      return <BusinessCompanyRoutes components={components} />;
    else if (role1[0].name === "SocialActivists")
      return <SocialActivistsRoutes components={components} />;
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
