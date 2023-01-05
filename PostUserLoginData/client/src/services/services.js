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

export const GetUserDataAsync = async (userAccess, userID) => {
  console.log(userID);
  let result = await axios.get(
    `http://localhost:7251/api/${userAccess}/userData/${userID}`
  );
  if (result.status === 200) {
    console.log(`seccsed : ${result.data}`);
    return result.data;
  } else {
    return {};
  }
};

export const addUserDataAsync = async (userAccess, action, userData) => {
  console.log(userData, action, "hhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhh");

  await axios.post(
    `http://localhost:7251/api/${userAccess}/${action}`,
    userData
  );
};

// export const UpdateUserAsync = async (userAccess,action, updateUser) => {
//   console.log(`updateUser : ${updateUser.ProductID}`);
//   const res = await axios.put(
//     `http://localhost:7251/api/${userAccess}/${action}/${updateUser.ProductID}`,
//     updateUser
//   );
//   console.log(res);
// };
