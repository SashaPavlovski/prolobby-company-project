import React, { useState } from "react";

import { useAuth0 } from "@auth0/auth0-react";
let count = 0;
export const UseValueLoginOrganization = ({ userDetails }) => {
  const { user } = useAuth0();
  const [organizationName, setOrganizationName] = useState("");
  const [url, setUrl] = useState("");
  const [decreption, setDecreption] = useState("");
  const [firstName, setFirstName] = useState("ooo");
  const [lastName, setLastName] = useState(user.family_name);
  const [email, setEmail] = useState(user.email);
  const [phoneNumber, setPhoneNumber] = useState(user.phone_number);
  const [picture, setPicture] = useState("");

  let userFirstName = "";
  let userOrganizationName = "";
  let userUrl = "";
  let userDecreption = "";
  let userLastName = "";
  let userEmail = "";
  let userPhoneNumber = "";
  let userPicture = "";

  if (userDetails === null) {
    userFirstName = "ooo";
    userEmail = user.email;
    userLastName = user.family_name;
    userPhoneNumber = user.phone_number;
    // userPicture = user.picture;
  }
  console.log(
    count++,
    "!!!!!!!!!!!!!!!!!!!!",
    firstName,
    lastName,
    organizationName,
    url,
    decreption,
    email,
    phoneNumber,
    picture
  );
  return {
    defaultVariables: {
      userFirstName,
      userOrganizationName,
      userUrl,
      userDecreption,
      userLastName,
      userEmail,
      userPhoneNumber,
      userPicture,
    },
    UseStatsVariables: {
      organizationNameV: { organizationName, setOrganizationName },
      urlV: { url, setUrl },
      decreptionV: { decreption, setDecreption },
      firstNameV: { firstName, setFirstName },
      lastNameV: { lastName, setLastName },
      emailV: { email, setEmail },
      phoneNumberV: { phoneNumber, setPhoneNumber },
      pictureV: { picture, setPicture },
    },
  };
};
