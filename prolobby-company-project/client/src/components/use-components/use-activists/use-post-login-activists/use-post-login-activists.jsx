import { useAuth0 } from "@auth0/auth0-react";

import { addUserDataAsync } from "../../../../services/services";
import { useNavigate } from "react-router-dom";

export const UsePostLoginActivists = ({ UseStatsVariables }) => {
  let navigate = useNavigate();
  const { user } = useAuth0();

  let {
    firstNameV: { firstName },
    lastNameV: { lastName },
    emailV: { email },
    twitterUserV: { twitterUser },
    addressV: { address },
    phoneNumberV: { phoneNumber },
  } = UseStatsVariables;

  const handleUserData = async () => {
    console.log(firstName, lastName, email, twitterUser, address, phoneNumber);

    await addUserDataAsync("SocialActivists", "addData", {
      FirstName: firstName,
      LastName: lastName,
      Address: address,
      Email: email,
      Twitter_user: twitterUser,
      Phone_number: phoneNumber,
      User_Id: user.sub,
    });

    navigate("/");
  };
  return { handleUserData };
};
