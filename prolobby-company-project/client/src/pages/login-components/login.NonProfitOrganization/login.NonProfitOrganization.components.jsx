import React, { useEffect } from "react";

import { UseValueLoginOrganization } from "../../../components/use-components/use-organization/use-value-login-organization/use-value-login-organization";
import { UseUpdateLoginOrganization } from "../../../components/use-components/use-organization/use-update-login-organization/use-update-login-organization";
import { UsePostLoginOrganization } from "../../../components/use-components/use-organization/use-post-login-organization/use-post-login-organization";
import { useNavigate } from "react-router-dom";
import { ValueFormOrganization } from "./value-form-organization/value-form-organization";

//The functions that perform the sending operations of the organization login
export const LoginNonProfitOrganization = () => {
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
  } = UseStatsVariables;
  let { userDataRow } = UserDataRowV;

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
    phoneNumber
  );
  let { handleUserData } = UsePostLoginOrganization({ UseStatsVariables });
  let { handleOrganizationUserData } = UseUpdateLoginOrganization({
    UseStatsVariables,
    userDataRow,
  });
  let sendingData = () => {
    if (userDataRow === null) {
      handleUserData();
      navigate("/");
    } else {
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
      sendingData={sendingData}
      organizationName={organizationName}
      url={url}
      decreption={decreption}
      firstName={firstName}
      lastName={lastName}
      email={email}
      phoneNumber={phoneNumber}
    />
  );
};
