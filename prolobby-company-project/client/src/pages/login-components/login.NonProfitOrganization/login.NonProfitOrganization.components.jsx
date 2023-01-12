import React, { useEffect } from "react";

import { UseValueLoginOrganization } from "../../../components/use-components/use-organization/use-value-login-organization/use-value-login-organization";
import { UseUpdateLoginOrganization } from "../../../components/use-components/use-organization/use-update-login-organization/use-update-login-organization";
import { UsePostLoginOrganization } from "../../../components/use-components/use-organization/use-post-login-organization/use-post-login-organization";
import { useNavigate } from "react-router-dom";
import { ValueFormOrganization } from "./value-form-organization/value-form-organization";

export const LoginNonProfitOrganization = () => {
  console.log("hh");
  let navigate = useNavigate();

  let { defaultVariables, UseStatsVariables, UserDataRowV } =
    UseValueLoginOrganization({});
  let {
    userFirstName,
    userOrganizationName,
    userUrl,
    userDecreption,
    userLastName,
    userEmail,
    userPhoneNumber,
  } = defaultVariables;
  let {
    organizationNameV: { organizationName, setOrganizationName },
    urlV: { url, setUrl },
    decreptionV: { decreption, setDecreption },
    firstNameV: { firstName, setFirstName },
    lastNameV: { lastName, setLastName },
    emailV: { email, setEmail },
    phoneNumberV: { phoneNumber, setPhoneNumber },
    pictureV: { picture, setPicture },
  } = UseStatsVariables;
  let { userDataRow } = UserDataRowV;
  if (userDataRow != null) {
    console.log(
      `else : sendingData : ${userDataRow.NonProfitOrganization_Id} `
    );
  }

  useEffect(() => {
    setOrganizationName(userOrganizationName);
    setUrl(userUrl);
    setDecreption(userDecreption);
    setFirstName(userFirstName);
    setLastName(userLastName);
    setEmail(userEmail);
    setPhoneNumber(userPhoneNumber);
  }, [userOrganizationName]);

  console.log(
    firstName,
    lastName,
    organizationName,
    url,
    decreption,
    email,
    phoneNumber,
    picture
  );
  let { handleUserData } = UsePostLoginOrganization({ UseStatsVariables });
  let { handleOrganizationUserData } = UseUpdateLoginOrganization({
    UseStatsVariables,
    userDataRow,
  });
  let sendingData = () => {
    if (userDataRow === null) {
      console.log(`else : sendingData : ${userDataRow} `);
      handleUserData();
      navigate("/");
    } else {
      console.log(
        `else : sendingData : ${userDataRow.NonProfitOrganization_Id} `
      );
      handleOrganizationUserData();
    }
  };
  return (
    <ValueFormOrganization
      userOrganizationName={userOrganizationName}
      setOrganizationName={setOrganizationName}
      userUrl={userUrl}
      setUrl={setUrl}
      userDecreption={userDecreption}
      setDecreption={setDecreption}
      userFirstName={userFirstName}
      setFirstName={setFirstName}
      userLastName={userLastName}
      setLastName={setLastName}
      userEmail={userEmail}
      setEmail={setEmail}
      userPhoneNumber={userPhoneNumber}
      setPhoneNumber={setPhoneNumber}
      setPicture={setPicture}
      sendingData={sendingData}
    />
  );
};
