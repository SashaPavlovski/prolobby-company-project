import React from "react";

//import { UpdateUserAsync } from "../../../../services/services.js";
import { UseValueLoginOrganization } from "../use-value-login-organization/use-value-login-organization";

export const UseUpdataLoginOrganization = ({ userDetails }) => {
  let { UseStatsVariables } = UseValueLoginOrganization(userDetails);

  let {
    organizationNameV: { organizationName },
    urlV: { url },
    decreptionV: { decreption },
    firstNameV: { firstName },
    lastNameV: { lastName },
    emailV: { email },
    phoneNumberV: { phoneNumber },
    pictureV: { picture },
  } = UseStatsVariables;

  const handleOrganizationUserData = async () => {
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
    let updateOrganization = {
      NonProfitOrganizationName: organizationName,
      Url: url,
      decreption: decreption,
      RepresentativeFirstName: firstName,
      RepresentativeLastName: lastName,
      Email: email,
      Phone_number: phoneNumber,
      Logo: picture,
    };
    //   await UpdateUserAsync(updateOrganization);
  };
  return { handleOrganizationUserData };
};
