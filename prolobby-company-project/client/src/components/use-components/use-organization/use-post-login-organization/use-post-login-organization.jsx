import { useAuth0 } from "@auth0/auth0-react";

import { addUserDataAsync } from "./../../../../services/services.add.data.js";
import { useNavigate } from "react-router-dom";

//Entering the details of the user of the sql
export const UsePostLoginOrganization = ({ UseStatsVariables }) => {
  let navigate = useNavigate();
  const { user } = useAuth0();

  let {
    organizationNameV: { organizationName },
    urlV: { url },
    decreptionV: { decreption },
    firstNameV: { firstName },
    lastNameV: { lastName },
    emailV: { email },
    phoneNumberV: { phoneNumber },
  } = UseStatsVariables;

  const handleUserData = async () => {
    await addUserDataAsync("NonProfitOrganization", "addData", {
      NonProfitOrganizationName: organizationName,
      Url: url,
      decreption: decreption,
      RepresentativeFirstName: firstName,
      RepresentativeLastName: lastName,
      Email: email,
      Phone_number: phoneNumber,
      User_Id: user.sub,
    });
    navigate("/");
  };
  return { handleUserData };
};
