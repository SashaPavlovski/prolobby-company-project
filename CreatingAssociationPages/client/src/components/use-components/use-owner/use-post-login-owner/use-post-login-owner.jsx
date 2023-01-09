import { useAuth0 } from "@auth0/auth0-react";

import { addUserDataAsync } from "../../../../services/services";
import { useNavigate } from "react-router-dom";

export const UsePostLoginOwner = ({ UseStatsVariables }) => {
  const { user } = useAuth0();
  let navigate = useNavigate();

  let {
    firstNameV: { firstName },
    lastNameV: { lastName },
    emailV: { email },
    phoneNumberV: { phoneNumber },
  } = UseStatsVariables;

  const handleUserData = async () => {
    console.log(firstName, lastName, email, phoneNumber);

    await addUserDataAsync("ProLobbyOwner", "addData", {
      FirstName: firstName,
      LastName: lastName,
      Email: email,
      Phone_number: phoneNumber,
      User_Id: user.sub,
    });
    navigate("/");
  };
  return { handleUserData };
};
