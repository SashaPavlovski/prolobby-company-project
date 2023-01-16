import { useState } from "react";

import { Ifexist } from "../../../repeat/user-if-exist";

export const UseValueLoginOrganization = () => {
  let { userDataRow, user } = Ifexist({});
  const [organizationName, setOrganizationName] = useState("");
  const [url, setUrl] = useState("");
  const [decreption, setDecreption] = useState("");
  const [firstName, setFirstName] = useState("");
  const [lastName, setLastName] = useState(user.family_name);
  const [email, setEmail] = useState(user.email);
  const [phoneNumber, setPhoneNumber] = useState(user.phone_number);
  // const [picture, setPicture] = useState("");

  let userFirstName = "";
  let userOrganizationName = "";
  let userUrl = "";
  let userDecreption = "";
  let userLastName = "";
  let userEmail = "";
  let userPhoneNumber = "";
  // let userPicture = "";

  // if (userDataRow === null) {
  //   console.log("if");
  //   userFirstName = user.name;
  //   userEmail = user.email;
  //   userLastName = user.family_name;
  //   userPhoneNumber = user.phone_number;
  //   // userPicture = user.picture;
  // }
  if (userDataRow !== null) {
    console.log("else");
    userFirstName = userDataRow.RepresentativeFirstName;
    userOrganizationName = userDataRow.NonProfitOrganizationName;
    userUrl = userDataRow.Url;
    userDecreption = userDataRow.decreption;
    userLastName = userDataRow.RepresentativeLastName;
    userEmail = userDataRow.Email;
    userPhoneNumber = userDataRow.Phone_number;
  }

  console.log(
    firstName,
    lastName,
    organizationName,
    url,
    decreption,
    email,
    phoneNumber
    // picture
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
      // userPicture,
    },
    UseStatsVariables: {
      organizationNameV: { organizationName, setOrganizationName },
      urlV: { url, setUrl },
      decreptionV: { decreption, setDecreption },
      firstNameV: { firstName, setFirstName },
      lastNameV: { lastName, setLastName },
      emailV: { email, setEmail },
      phoneNumberV: { phoneNumber, setPhoneNumber },
      // pictureV: { picture, setPicture },
    },
    UserDataRowV: { userDataRow },
  };
};
