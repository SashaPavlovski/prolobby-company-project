import React from "react";

import { UpdateUserAsync } from "../../../../services/services.js";

export const UseUpdateLoginOrganization = ({
  UseStatsVariables,
  userDataRow,
}) => {
  if (userDataRow !== 0) {
    console.log(`AAAAAAAAAAAAAAAAAAAAAAAAAAAA : ${userDataRow}`);
  }

  let {
    organizationNameV: { organizationName },
    urlV: { url },
    decreptionV: { decreption },
    firstNameV: { firstName },
    lastNameV: { lastName },
    emailV: { email },
    phoneNumberV: { phoneNumber },
  } = UseStatsVariables;

  const handleOrganizationUserData = async () => {
    console.log(
      userDataRow.NonProfitOrganization_Id,
      firstName,
      lastName,
      organizationName,
      url,
      decreption,
      email,
      phoneNumber
    );
    let updateOrganization = {
      NonProfitOrganization_Id: userDataRow.NonProfitOrganization_Id,
      NonProfitOrganizationName: organizationName,
      Url: url,
      decreption: decreption,
      RepresentativeFirstName: firstName,
      RepresentativeLastName: lastName,
      Email: email,
      Phone_number: phoneNumber,
    };
    await UpdateUserAsync(
      "NonProfitOrganization",
      "updateData",
      updateOrganization,
      updateOrganization.NonProfitOrganization_Id
    );
  };
  return { handleOrganizationUserData };
};
