import { useState } from "react";

import { Ifexist } from "../../../repeat/user-if-exist";

//The functions that are required to
// make you a component of the login of company user
export const UseValueLoginCompany = () => {
  let { userDataRow, user } = Ifexist({});
  const [firstName, setFirstName] = useState(user.name);
  const [lastName, setLastName] = useState(user.family_name);
  const [companyName, setCompanyName] = useState("");
  const [url, setUrl] = useState("");
  const [email, setEmail] = useState(user.email);
  const [phoneNumber, setPhoneNumber] = useState(user.phone_number);

  let userFirstName = "";
  let userCompanyName = "";
  let userUrl = "";
  let userLastName = "";
  let userEmail = "";
  let userPhoneNumber = "";

  if (userDataRow != null) {
    userFirstName = userDataRow.RepresentativeFirstName;
    userEmail = userDataRow.Email;
    userLastName = userDataRow.RepresentativeLastName;
    userPhoneNumber = userDataRow.Phone_number;
    userCompanyName = userDataRow.CompanyName;
    userUrl = userDataRow.Url;
  }

  console.log(firstName, lastName, companyName, url, email, phoneNumber);
  return {
    defaultVariables: {
      userFirstName,
      userCompanyName,
      userUrl,
      userLastName,
      userEmail,
      userPhoneNumber,
    },
    UseStatsVariables: {
      companyNameV: { companyName, setCompanyName },
      urlV: { url, setUrl },
      firstNameV: { firstName, setFirstName },
      lastNameV: { lastName, setLastName },
      emailV: { email, setEmail },
      phoneNumberV: { phoneNumber, setPhoneNumber },
    },
    UserDataRowV: { userDataRow },
  };
};
