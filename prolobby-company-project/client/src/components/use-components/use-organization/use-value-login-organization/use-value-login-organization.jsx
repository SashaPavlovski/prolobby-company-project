import { useState } from "react";

import { Ifexist } from "../../../repeat/user-if-exist";

//The values ​​of the Organization for login component
export const UseValueLoginOrganization = () => {
  let { userDataRow, user } = Ifexist({});
  const [organizationName, setOrganizationName] = useState("");
  const [url, setUrl] = useState("");
  const [decreption, setDecreption] = useState("");
  const [firstName, setFirstName] = useState("");
  const [lastName, setLastName] = useState(user.family_name);
  const [email, setEmail] = useState(user.email);
  const [phoneNumber, setPhoneNumber] = useState(user.phone_number);

  let userFirstName = "";
  let userOrganizationName = "";
  let userUrl = "";
  let userDecreption = "";
  let userLastName = "";
  let userEmail = "";
  let userPhoneNumber = "";

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
    },
    UseStatsVariables: {
      organizationNameV: { organizationName, setOrganizationName },
      urlV: { url, setUrl },
      decreptionV: { decreption, setDecreption },
      firstNameV: { firstName, setFirstName },
      lastNameV: { lastName, setLastName },
      emailV: { email, setEmail },
      phoneNumberV: { phoneNumber, setPhoneNumber },
    },
    UserDataRowV: { userDataRow },
  };
};
