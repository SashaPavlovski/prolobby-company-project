import axios from "axios";

export const GetRolesAsync = async (userID) => {
  console.log(userID);
  let result = await axios.get(
    `http://localhost:7251/api/roles/roles/${userID}`
  );
  if (result.status === 200) {
    return result.data;
  } else {
    return {};
  }
};

export const GetDataAsync = async (userAccess, action, userID) => {
  console.log("enter to GetDataAsync");
  console.log(userID);
  let result = await axios.get(
    `http://localhost:7251/api/${userAccess}/${action}/${userID}`
  );
  if (result.status === 200) {
    console.log(`seccsed : ${result.data}`);
    return result.data;
  } else {
    console.log("enter GetDataAsync else");
    return {};
  }
};

export const addUserDataAsync = async (userAccess, action, userData) => {
  console.log(userData, action, "hhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhh");

  let result = await axios.post(
    `http://localhost:7251/api/${userAccess}/${action}`,
    userData
  );
  if (result.status === 200) {
    console.log(`seccsed : ${result.data}`);
    return result.data;
  } else {
    return {};
  }
};

export const UpdateUserAsync = async (
  userAccess,
  action,
  updateUser,
  userId
) => {
  console.log(`updateUser : ${userId}`);
  const res = await axios.put(
    `http://localhost:7251/api/${userAccess}/${action}/${userId}`,
    updateUser
  );
  console.log(res);
};

//************************************************************************* */
// export const GetAllDataAsync = async (userAccess, action) => {
//   let serverUrl = `http://localhost:7251/api/${userAccess}/${action}`;
//   let ProductsFromServer = await axios.get(serverUrl);
//   if (ProductsFromServer.status === 200) {
//     console.log(`seccsed : ${ProductsFromServer.data}`);
//     return ProductsFromServer.data;
//   } else {
//     return {};
//   }
// };
