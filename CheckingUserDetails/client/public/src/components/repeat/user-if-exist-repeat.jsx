import React, { useState, useContext, useEffect } from "react";

import { UserContext } from "../../context/userData.context.js";
import { GetUserDataAsync } from "../../services/services.js";
import { useAuth0 } from "@auth0/auth0-react";

export const ExistRowUser = () => {
  const [userData, setUserData] = useState([]);
  const { user } = useAuth0();
  const { role1 } = useContext(UserContext);
  console.log("bdeka");
  console.log(role1.name + "ssssssssssss");
  let userAuthId = user.sub;

  const handleGetUserData = async (userId) => {
    let userRow = await GetUserDataAsync(role1[0].name, userId);
    setUserData(userRow);
  };

  useEffect(() => {
    console.log("j");
    handleGetUserData(userAuthId);
  }, []);
  return userData;
};
