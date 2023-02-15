import { UpdateUserAsync } from "../../../../services/services.update.data.js";
//Updating the Organization details
export const UseUpdateLoginOrganization = ({
  UseStatsVariables,
  userDataRow,
}) => {
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
