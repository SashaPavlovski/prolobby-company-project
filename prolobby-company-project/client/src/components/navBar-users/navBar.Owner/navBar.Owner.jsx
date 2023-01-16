import React from "react";
import { NavBar } from "../../navBar-components/navBar-body/navBar-body-components";

let navBarArr = [
  {
    path: "/",
    pathName: "home",
  },
  {
    path: "/profile",
    pathName: "profile",
  },
  {
    path: "/send-active-money",
    pathName: "send active money",
  },
];

export const NavBarOwner = () => {
  return <NavBar pathArr={navBarArr} />;
};
