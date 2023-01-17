import { UpdateUserAsync } from "../../../../services/services.js";

//update the Activists details
export const UseUpdateLoginActivists = ({ UseStatsVariables, userDataRow }) => {
  let {
    firstNameV: { firstName },
    lastNameV: { lastName },
    emailV: { email },
    twitterUserV: { twitterUser },
    addressV: { address },
    phoneNumberV: { phoneNumber },
  } = UseStatsVariables;

  const handleActivistsUserData = async () => {
    console.log(
      userDataRow.SocialActivists_Id,
      firstName,
      lastName,
      email,
      twitterUser,
      address,
      phoneNumber
    );
    let updateActivist = {
      SocialActivists_Id: userDataRow.SocialActivists_Id,
      FirstName: firstName,
      LastName: lastName,
      Address: address,
      Email: email,
      Twitter_user: twitterUser,
      Phone_number: phoneNumber,
    };
    await UpdateUserAsync(
      "SocialActivists",
      "updateData",
      updateActivist,
      updateActivist.SocialActivists_Id
    );
  };
  return { handleActivistsUserData };
};
