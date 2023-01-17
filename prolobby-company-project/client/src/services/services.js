import axios from "axios";

//Sends the user's ID to check if he has permission to log in
export const GetRolesAsync = async (userID) => {
  let result = await axios.get(
    `http://localhost:7251/api/roles/roles/${userID}`
  );
  if (result.status === 200) {
    return result.data;
  } else {
    return {};
  }
};

//Receiving data according to an identity value
export const GetDataAsync = async (userAccess, action, userID) => {
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

//Sending Json and identity value
export const addUserDataAsync = async (userAccess, action, userData) => {
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

//Sending Json and identity value
//without getting an answer
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

//Receiving data according to an identity value for Delet
export const DeleteAsync = async (userAccess, action, id) => {
  console.log(`DeleteAsync : ${(userAccess, action, id)}`);
  const res = await axios.delete(
    `http://localhost:7251/api/${userAccess}/${action}/${id}`
  );
  console.log(res);
};
