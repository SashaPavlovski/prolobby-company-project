import { useAuth0 } from "@auth0/auth0-react";

import { addUserDataAsync } from "../../../../services/services";
import { useNavigate } from "react-router-dom";

export const UsePostLoginCompany = ({ UseStatsVariables }) => {
  let navigate = useNavigate();

  const { user } = useAuth0();

  let {
    companyNameV: { companyName },
    urlV: { url },
    firstNameV: { firstName },
    lastNameV: { lastName },
    emailV: { email },
    phoneNumberV: { phoneNumber },
  } = UseStatsVariables;

  const handleUserData = async () => {
    console.log(firstName, lastName, companyName, url, email, phoneNumber);

    await addUserDataAsync("BusinessCompanyRepresentative", "addData", {
      RepresentativeFirstName: firstName,
      RepresentativeLastName: lastName,
      CompanyName: companyName,
      Url: url,
      Email: email,
      Phone_number: phoneNumber,
      User_Id: user.sub,
    });
    navigate("/");
  };
  return { handleUserData };
};
