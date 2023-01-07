import React from "react";

import { UpdateUserAsync } from "../../../../services/services.js";

export const UseUpdateLoginCompany = ({ UseStatsVariables, userDataRow }) => {
  if (userDataRow != null) {
    console.log(`AAAAAAAAAAAAAAAAAAAAAAAAAAAA : ${userDataRow}`);
  }

  let {
    companyNameV: { companyName },
    urlV: { url },
    firstNameV: { firstName },
    lastNameV: { lastName },
    emailV: { email },
    phoneNumberV: { phoneNumber },
  } = UseStatsVariables;

  const handleCompanyUserData = async () => {
    console.log(
      userDataRow.BusinessCompany_Id,
      firstName,
      lastName,
      companyName,
      url,
      email,
      phoneNumber
    );
    let updateCompany = {
      BusinessCompany_Id: userDataRow.BusinessCompany_Id,
      RepresentativeFirstName: firstName,
      RepresentativeLastName: lastName,
      CompanyName: companyName,
      Url: url,
      Email: email,
      Phone_number: phoneNumber,
    };
    await UpdateUserAsync(
      "BusinessCompanyRepresentative",
      "updateData",
      updateCompany,
      updateCompany.BusinessCompany_Id
    );
  };
  return { handleCompanyUserData };
};
