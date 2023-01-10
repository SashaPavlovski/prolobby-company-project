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
];

export const NavBarCompany = () => {
  return <NavBar pathArr={navBarArr} />;
};
