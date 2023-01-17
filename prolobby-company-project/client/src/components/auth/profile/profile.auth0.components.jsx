import React from "react";

import { useAuth0 } from "@auth0/auth0-react";

import "./profile.auth0.components.css";

//display a user with the useAuth0
export const Profile = () => {
  const { user } = useAuth0();
  return (
    <>
      <img src={user.picture} alt={user.name} className="my-picture" />
      <h2 className="my-user">{user.name}</h2>
      <p className="my-user">{user.email}</p>
    </>
  );
};
