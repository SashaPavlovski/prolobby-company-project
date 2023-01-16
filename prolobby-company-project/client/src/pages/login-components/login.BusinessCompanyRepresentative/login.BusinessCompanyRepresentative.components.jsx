import React, { useEffect } from "react";

import { useNavigate } from "react-router-dom";
import { UseValueLoginCompany } from "./../../../components/use-components/use-company/use-value-login-company/use-value-login-company";
import { UsePostLoginCompany } from "./../../../components/use-components/use-company/use-post-login-company/use-post-login-company";
import { UseUpdateLoginCompany } from "../../../components/use-components/use-company/use-update-login-company/use-update-login-company";
import { ValueFormCompany } from "./value-form-company/value-form-company";

export const LoginBusinessCompanyRepresentative = () => {
  let navigate = useNavigate();
  let { defaultVariables, UseStatsVariables, UserDataRowV } =
    UseValueLoginCompany({});
  let {
    userFirstName,
    userCompanyName,
    userUrl,
    userLastName,
    userEmail,
    userPhoneNumber,
  } = defaultVariables;

  let {
    companyNameV: { companyName, setCompanyName },
    urlV: { url, setUrl },
    firstNameV: { firstName, setFirstName },
    lastNameV: { lastName, setLastName },
    emailV: { email, setEmail },
    phoneNumberV: { phoneNumber, setPhoneNumber },
  } = UseStatsVariables;

  let { userDataRow } = UserDataRowV;
  if (userDataRow != null) {
    console.log(`else : sendingData : ${userDataRow.BusinessCompany_Id} `);
  }

  useEffect(() => {
    setCompanyName(userCompanyName);
    setUrl(userUrl);
    setFirstName(userFirstName);
    setLastName(userLastName);
    setEmail(userEmail);
    setPhoneNumber(userPhoneNumber);
  }, [userCompanyName]);

  console.log(firstName, lastName, companyName, url, email, phoneNumber);
  let { handleUserData } = UsePostLoginCompany({ UseStatsVariables });
  let { handleCompanyUserData } = UseUpdateLoginCompany({
    UseStatsVariables,
    userDataRow,
  });

  let sendingData1 = () => {
    if (userDataRow === null) {
      navigate("/");
      handleUserData();
    } else {
      console.log(`else : sendingData : ${userDataRow.BusinessCompany_Id} `);
      handleCompanyUserData();
    }
  };
  return (
    <ValueFormCompany
      userFirstName={userFirstName}
      setFirstName={setFirstName}
      userLastName={userLastName}
      setLastName={setLastName}
      userCompanyName={userCompanyName}
      setCompanyName={setCompanyName}
      userUrl={userUrl}
      setUrl={setUrl}
      userEmail={userEmail}
      setEmail={setEmail}
      userPhoneNumber={userPhoneNumber}
      setPhoneNumber={setPhoneNumber}
      sendingData1={sendingData1}
      companyName={companyName}
      url={url}
      firstName={firstName}
      lastName={lastName}
      email={email}
      phoneNumber={phoneNumber}
    />
  );
};
// <form className="row g-3 needs-validation">

// type="submit"
//</form>
//
