import React from "react";
import { useAuth0 } from "@auth0/auth0-react";

import { addUserDataAsync } from "./../../../../services/services";
import { useNavigate } from "react-router-dom";
let cunter = 0;

export const UsePostLoginOrganization = ({ UseStatsVariables }) => {
  let navigate = useNavigate();
  const { user } = useAuth0();
  console.log("UsePostLoginOrganization");
  let {
    organizationNameV: { organizationName },
    urlV: { url },
    decreptionV: { decreption },
    firstNameV: { firstName },
    lastNameV: { lastName },
    emailV: { email },
    phoneNumberV: { phoneNumber },
    pictureV: { picture },
  } = UseStatsVariables;

  const handleUserData = async () => {
    console.log(
      "oooooooooooooooooooooo",
      cunter++,
      firstName,
      lastName,
      organizationName,
      url,
      decreption,
      email,
      phoneNumber,
      picture
    );

    await addUserDataAsync("NonProfitOrganization", "addData", {
      NonProfitOrganizationName: organizationName,
      Url: url,
      decreption: decreption,
      RepresentativeFirstName: firstName,
      RepresentativeLastName: lastName,
      Email: email,
      Phone_number: phoneNumber,
      SetImage: null,
      User_Id: user.sub,
    });
    navigate("/");
  };
  return { handleUserData };
};
