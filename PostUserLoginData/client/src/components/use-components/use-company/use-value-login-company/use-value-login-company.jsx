import { useState } from "react";

import { useAuth0 } from "@auth0/auth0-react";
let count = 0;
export const UseValueLoginCompany = ({ userDetails }) => {
  console.log("amn");
  const { user } = useAuth0();
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

  if (userDetails === null) {
    userFirstName = user.name;
    userEmail = user.email;
    userLastName = user.family_name;
    userPhoneNumber = user.phone_number;
  }
  console.log(
    count++,
    "!!!!!!!!!!!!!!!!!!!!",
    firstName,
    lastName,
    companyName,
    url,
    email,
    phoneNumber
  );
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
  };
};
