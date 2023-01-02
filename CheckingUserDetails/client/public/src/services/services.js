import axios from "axios";

export const GetRolesAsync = async (userID) => {
  console.log(userID);
  let result = await axios.get(`http://localhost:7251/api/roles/${userID}`);
  if (result.status === 200) {
    return result.data;
  } else {
    return {};
  }
};

export const GetUserDataAsync = async (userAccess, userID) => {
  console.log(userID);
  let result = await axios.get(
    `http://localhost:7251/api/${userAccess}/${userID}`
  );
  if (result.status === 200) {
    console.log(`seccsed : ${result.data}`);
    return result.data;
  } else {
    return {};
  }
};
