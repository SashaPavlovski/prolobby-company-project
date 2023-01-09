import { useState } from "react";

import { Ifexist } from "../../../repeat/user-if-exist";

export const UseValueLoginActivists = () => {
  let { userDataRow, user } = Ifexist({});
  const [firstName, setFirstName] = useState(user.name);
  const [lastName, setLastName] = useState(user.family_name);
  const [email, setEmail] = useState(user.email);
  const [twitterUser, setTwitterUser] = useState({});
  const [address, setAddress] = useState({});
  const [phoneNumber, setPhoneNumber] = useState(user.phone_number);

  let userFirstName = "";
  let userLastName = "";
  let userEmail = "";
  let userTwitterUser = "";
  let userAddress = "";
  let userPhoneNumber = "";

  // if (userDataRow === null) {
  //   userFirstName = user.name;
  //   userEmail = user.email;
  //   userLastName = user.family_name;
  //   userPhoneNumber = user.phone_number;
  // }
  if (userDataRow !== null) {
    userFirstName = userDataRow.FirstName;
    userEmail = userDataRow.Email;
    userLastName = userDataRow.LastName;
    userPhoneNumber = userDataRow.Phone_number;
    userTwitterUser = userDataRow.Twitter_user;
    userAddress = userDataRow.Address;
  }

  console.log(firstName, lastName, email, twitterUser, address, phoneNumber);
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
    UserDataRowV: { userDataRow },
  };
};
