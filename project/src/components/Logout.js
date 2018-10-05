import React from "react";
import { Redirect } from "react-router-dom";
import { connect } from "react-redux";

import { logoutAction } from "../actions/loginActions";

class Logout extends React.Component {
  render() {
    this.props.dispatch(logoutAction());
    return <Redirect to="/login" />;
  }
}

export default connect()(Logout);
