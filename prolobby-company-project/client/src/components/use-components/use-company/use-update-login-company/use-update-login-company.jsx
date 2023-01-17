import { UpdateUserAsync } from "../../../../services/services.js";

//sending data to cs
//update the details of company user
export const UseUpdateLoginCompany = ({ UseStatsVariables, userDataRow }) => {
  let {
    companyNameV: { companyName },
    urlV: { url },
    firstNameV: { firstName },
    lastNameV: { lastName },
    emailV: { email },
    phoneNumberV: { phoneNumber },
  } = UseStatsVariables;

  const handleCompanyUserData = async () => {
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
