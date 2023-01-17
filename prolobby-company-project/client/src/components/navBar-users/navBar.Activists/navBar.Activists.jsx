import React from "react";
import { NavBar } from "../../navBar-components/navBar-body/navBar-body-components";

//creation NavBarActivists
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

export const NavBarActivists = () => {
  return <NavBar pathArr={navBarArr} />;
};
