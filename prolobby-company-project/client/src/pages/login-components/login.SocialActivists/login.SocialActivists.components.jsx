import React, { useEffect } from "react";

import { useNavigate } from "react-router-dom";
import { UseValueLoginActivists } from "./../../../components/use-components/use-activists/use-value-login-activists/use-value-login-activists";
import { UsePostLoginActivists } from "./../../../components/use-components/use-activists/use-post-login-activists/use-post-login-activists";
import { UseUpdateLoginActivists } from "../../../components/use-components/use-activists/use-update-login-activists/use-update-login-activists";
import { ValueFormActivists } from "./value-form-activists/value-form-activists";

//Functions that perform the operation of sending the input data
//button that leading to the money tracking view
//Button that leading products bought
export const LoginSocialActivists = () => {
  let navigate = useNavigate();
  let { defaultVariables, UseStatsVariables, UserDataRowV } =
    UseValueLoginActivists({});
  let {
    userFirstName,
    userTwitterUser,
    userAddress,
    userLastName,
    userEmail,
    userPhoneNumber,
  } = defaultVariables;

  let {
    twitterUserV: { twitterUser, setTwitterUser },
    addressV: { address, setAddress },
    firstNameV: { firstName, setFirstName },
    lastNameV: { lastName, setLastName },
    emailV: { email, setEmail },
    phoneNumberV: { phoneNumber, setPhoneNumber },
  } = UseStatsVariables;
  let { userDataRow } = UserDataRowV;

  useEffect(() => {
    setTwitterUser(userTwitterUser);
    setAddress(userAddress);
    setFirstName(userFirstName);
    setLastName(userLastName);
    setEmail(userEmail);
    setPhoneNumber(userPhoneNumber);
  }, [userTwitterUser]);

  console.log(firstName, lastName, email, twitterUser, address, phoneNumber);
  let { handleUserData } = UsePostLoginActivists({ UseStatsVariables });
  let { handleActivistsUserData } = UseUpdateLoginActivists({
    UseStatsVariables,
    userDataRow,
  });
  let sendingData1 = () => {
    if (userDataRow === null) {
      navigate("/");
      handleUserData();
    } else {
      handleActivistsUserData();
    }
  };
  const showMoney = () => {
    if (userDataRow !== null) {
      let activistId = userDataRow.SocialActivists_Id;
      navigate("/my-money", {
        state: {
          activistId,
        },
      });
    }
  };

  const showMyProduct = () => {
    if (userDataRow !== null) {
      let activistId = userDataRow.SocialActivists_Id;
      navigate("/my-products", {
        state: {
          activistId,
        },
      });
    }
  };
  return (
    <>
      <ValueFormActivists
        userFirstName={userFirstName}
        setFirstName={setFirstName}
        userLastName={userLastName}
        setLastName={setLastName}
        userEmail={userEmail}
        setEmail={setEmail}
        userTwitterUser={userTwitterUser}
        setTwitterUser={setTwitterUser}
        userAddress={userAddress}
        setAddress={setAddress}
        userPhoneNumber={userPhoneNumber}
        setPhoneNumber={setPhoneNumber}
        sendingData1={sendingData1}
        showMoney={showMoney}
        showMyProduct={showMyProduct}
        firstName={firstName}
        lastName={lastName}
        email={email}
        twitterUser={twitterUser}
        address={address}
        phoneNumber={phoneNumber}
      />
      {/* <UseMoneyTrackingShow activistUser={userDataRow} /> */}
    </>
  );
};
