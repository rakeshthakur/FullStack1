import React from "react";
import { Route, Switch } from "react-router-dom";

import EmployeeList from "./Employee/EmployeeList";
import DepartmentList from "./Department/DepartmentList";
import AddDepartment from "./Department/AddDepartment";

import LoginContainer from "../containers/LoginContainer";
import Logout from "./Logout";
import PrivateRoute from "./PrivateRoute";

class Content extends React.Component {
  render() {
    return (
      <div>
        <Switch>
          <Route exact path="/" component={LoginContainer} />
          <Route exact path="/login" component={LoginContainer} />
          <PrivateRoute path="/employee-list" component={EmployeeList} />
          <PrivateRoute path="/department-list" component={DepartmentList} />
          <PrivateRoute path="/add-department" component={AddDepartment} />
          <PrivateRoute path="/logout" component={Logout} />
          <Route
            path="*"
            render={() => (
              <h1 style={{ color: "red" }}>404 - Page not found!</h1>
            )}
          />
        </Switch>
      </div>
    );
  }
}

export default Content;
