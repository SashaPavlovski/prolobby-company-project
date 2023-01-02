import React from "react";

import { LoginProLobbyOwner } from "../../login-components";
import { HomeOwner } from "./../../../pages/home/home-owner/home-owner";
import { ExistRowUser } from "./../../repeat/user-if-exist-repeat";

export const ProLobbyOwnerHP = () => {
  const handleRowUser = () => {
    let userData = ExistRowUser();
    return userData;
  };

  if (!(handleRowUser() === null)) {
    return (
      <>
        <HomeOwner />
      </>
    );
  } else {
    return <LoginProLobbyOwner />;
  }
};
