import React, { useState, useContext, useEffect } from "react";

import { UserContext } from "../../context/userData.context.js";
import { GetDataAsync } from "../../services/services.js";
import { useAuth0 } from "@auth0/auth0-react";

export const ExistRowUser = () => {
  const [userData, setUserData] = useState([]);
  const { user } = useAuth0();
  const { role1, setUserData1 } = useContext(UserContext);
  let userAuthId = user.sub;

  const handleGetUserData = async (userId) => {
    let userRow = await GetDataAsync(role1[0].name, "userData", userId);
    setUserData(userRow);
    // setUserData1(userRow);
  };

  useEffect(() => {
    handleGetUserData(userAuthId);
  }, []);
  return { userData, role1 };
};
