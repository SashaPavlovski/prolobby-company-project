import React, { useEffect } from "react";

import { useNavigate } from "react-router-dom";
import { UseValueLoginOwner } from "./../../../components/use-components/use-owner/use-value-login-owner/use-value-login-owner";
import { UsePostLoginOwner } from "./../../../components/use-components/use-owner/use-post-login-owner/use-post-login-owner";
import { UseUpdateLoginOwner } from "../../../components/use-components/use-owner/use-update-login-owner/use-update-login-owner";
import { ValueFormOwner } from "./value-form-owner/value-form-owner";

export const LoginProLobbyOwner = () => {
  let navigate = useNavigate();
  let { defaultVariables, UseStatsVariables, UserDataRowV } =
    UseValueLoginOwner({});
  let { userFirstName, userLastName, userEmail, userPhoneNumber } =
    defaultVariables;

  let {
    firstNameV: { firstName, setFirstName },
    lastNameV: { lastName, setLastName },
    emailV: { email, setEmail },
    phoneNumberV: { phoneNumber, setPhoneNumber },
  } = UseStatsVariables;

  let { userDataRow } = UserDataRowV;
  if (userDataRow != null) {
    console.log(`else : sendingData : ${userDataRow.ProLobbyOwner_Id} `);
  }

  useEffect(() => {
    setFirstName(userFirstName);
    setLastName(userLastName);
    setEmail(userEmail);
    setPhoneNumber(userPhoneNumber);
  }, [userPhoneNumber]);

  console.log(firstName, lastName, email, phoneNumber);
  let { handleUserData } = UsePostLoginOwner({ UseStatsVariables });
  let { handleOwnerUserData } = UseUpdateLoginOwner({
    UseStatsVariables,
    userDataRow,
  });
  let sendingData1 = () => {
    if (userDataRow === null) {
      navigate("/");
      handleUserData();
    } else {
      console.log(`else : sendingData : ${userDataRow.ProLobbyOwner_Id} `);
      handleOwnerUserData();
    }
  };
  return (
    <ValueFormOwner
      userFirstName={userFirstName}
      setFirstName={setFirstName}
      userLastName={userLastName}
      setLastName={setLastName}
      userEmail={userEmail}
      setEmail={setEmail}
      userPhoneNumber={userPhoneNumber}
      setPhoneNumber={setPhoneNumber}
      sendingData1={sendingData1}
    />
  );
};
