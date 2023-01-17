import React from "react";
import { NavBar } from "../../navBar-components/navBar-body/navBar-body-components";

//creation NavBarCompany
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
    path: "/delivery-List",
    pathName: "delivery List",
  },
];

export const NavBarCompany = () => {
  return <NavBar pathArr={navBarArr} />;
};
