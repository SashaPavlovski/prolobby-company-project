import React from "react";
import { Link } from "react-router-dom";

export const NavBarLink = ({ path, pathName }) => {
  return (
    <li className="nav-item" role="presentation">
      <button className="nav-link">
        <Link to={path}>{pathName}</Link>
      </button>
    </li>
  );
};
