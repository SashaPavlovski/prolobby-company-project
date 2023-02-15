import { useState, useContext, useEffect } from "react";

import { UserContext } from "../../context/userData.context.js";
import { GetDataAsync } from "../../services/services.get.data.js";
import { useAuth0 } from "@auth0/auth0-react";

//Checking if the user exists
//Sends the ID
//If he gets the details, it means he exists
//otherwise it will get null
export const ExistRowUser = () => {
  const [userData, setUserData] = useState([]);
  const { user } = useAuth0();
  const { role1 } = useContext(UserContext);
  let userAuthId = user.sub;

  const handleGetUserData = async (userId) => {
    let userRow = await GetDataAsync(role1[0].name, "userData", userId);
    setUserData(userRow);
  };

  useEffect(() => {
    handleGetUserData(userAuthId);
  }, []);
  return { userData, role1 };
};
