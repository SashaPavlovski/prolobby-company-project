import React from "react";

import { UpdateUserAsync } from "../../../../services/services.js";

export const UseUpdateLoginOwner = ({ UseStatsVariables, userDataRow }) => {
  if (userDataRow != null) {
    console.log(`AAAAAAAAAAAAAAAAAAAAAAAAAAAA : ${userDataRow}`);
  }

  let {
    firstNameV: { firstName },
    lastNameV: { lastName },
    emailV: { email },
    phoneNumberV: { phoneNumber },
  } = UseStatsVariables;

  const handleOwnerUserData = async () => {
    console.log(
      userDataRow.ProLobbyOwner_Id,
      firstName,
      lastName,
      email,
      phoneNumber
    );
    let updateOwner = {
      ProLobbyOwner_Id: userDataRow.ProLobbyOwner_Id,
      FirstName: firstName,
      LastName: lastName,
      Email: email,
      Phone_number: phoneNumber,
    };
    await UpdateUserAsync(
      "ProLobbyOwner",
      "updateData",
      updateOwner,
      updateOwner.ProLobbyOwner_Id
    );
  };
  return { handleOwnerUserData };
};
