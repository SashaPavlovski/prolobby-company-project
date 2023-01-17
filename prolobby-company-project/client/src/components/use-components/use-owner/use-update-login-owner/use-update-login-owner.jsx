import { UpdateUserAsync } from "../../../../services/services.js";

//Sending updated data to Cs of Owner
export const UseUpdateLoginOwner = ({ UseStatsVariables, userDataRow }) => {
  let {
    firstNameV: { firstName },
    lastNameV: { lastName },
    emailV: { email },
    phoneNumberV: { phoneNumber },
  } = UseStatsVariables;

  const handleOwnerUserData = async () => {
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
