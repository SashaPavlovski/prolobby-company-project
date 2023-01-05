import { useState } from "react";

import { useAuth0 } from "@auth0/auth0-react";
let count = 0;
export const UseValueLoginActivists = ({ userDetails }) => {
  const { user } = useAuth0();
  const [firstName, setFirstName] = useState(user.name);
  const [lastName, setLastName] = useState(user.family_name);
  const [email, setEmail] = useState(user.email);
  const [twitterUser, setTwitterUser] = useState(user.phone_number);
  const [address, setAddress] = useState(user.phone_number);
  const [phoneNumber, setPhoneNumber] = useState(user.phone_number);

  let userFirstName = "";
  let userLastName = "";
  let userEmail = "";
  let userTwitterUser = "";
  let userAddress = "";
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
    email,
    twitterUser,
    address,
    phoneNumber
  );
  return {
    defaultVariables: {
      userFirstName,
      userLastName,
      userEmail,
      userPhoneNumber,
      userTwitterUser,
      userAddress,
    },
    UseStatsVariables: {
      firstNameV: { firstName, setFirstName },
      lastNameV: { lastName, setLastName },
      emailV: { email, setEmail },
      phoneNumberV: { phoneNumber, setPhoneNumber },
      twitterUserV: { twitterUser, setTwitterUser },
      addressV: { address, setAddress },
    },
  };
};
