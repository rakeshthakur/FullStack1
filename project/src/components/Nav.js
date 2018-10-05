import React from "react";
import { NavLink } from "react-router-dom";

class Nav extends React.Component {
  render() {
    return (
      <nav className="nav">
        <div>
          <NavLink activeClassName="activeMenu" to="/department-list">
            Department
          </NavLink>
        </div>
        <div>
          <NavLink activeClassName="activeMenu" to="/employee-list">
            Employee
          </NavLink>
        </div>
        <div>
          <NavLink activeClassName="activeMenu" to="/logout">
            Logout
          </NavLink>
        </div>
      </nav>
    );
  }
}

export default Nav;
