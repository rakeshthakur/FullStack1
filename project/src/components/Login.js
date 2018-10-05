import React from "react";
import { loginAction } from "../actions/loginActions";

class Login extends React.Component {
  constructor(props) {
    super(props);

    this.state = {
      un: "",
      pwd: "",
      loginStatus: false,
      loginMessage: "",
    };

    this.unChanged = this.unChanged.bind(this);
    this.pwdChanged = this.pwdChanged.bind(this);
    this.submitControlled = this.submitControlled.bind(this);
  }

  unChanged(ev) {
    this.setState({ un: ev.target.value });
  }

  pwdChanged(ev) {
    this.setState({ pwd: ev.target.value });
  }

  submitControlled() {
    const submitValues = {
      uname: this.state.un,
      pword: this.state.pwd,
    };

    console.log(submitValues);

    if (submitValues.uname === "admin" && submitValues.pword === "test") {
      console.log("Login Success!");
      this.props.dispatch(loginAction());
      this.setState({ loginStatus: true, loginMessage: "" });
    } else {
      this.setState({
        loginStatus: false,
        loginMessage:
          "Login Failed! Please check the credentials provided by you.",
      });
      console.log("Login Failed!");
    }
  }

  render() {
    if (this.state.loginStatus) {
      return (
        <section className="content">
          <h1>Login</h1>
          <br />
          <br />
          <br />
          <br />
          <br />
          <h1 style={{ color: "green" }}>Congrats! You are now logged in!</h1>
        </section>
      );
    }
    return (
      <section className="content">
        <h1>Login</h1>
        <form action="">
          <div className="form-input">
            <label htmlFor="un">Username:</label>
            <input
              name="un"
              type="text"
              value={this.state.un}
              onChange={this.unChanged}
            />
          </div>

          <div className="form-input">
            <label htmlFor="pwd">Password:</label>
            <input
              name="pwd"
              type="password"
              value={this.state.pwd}
              onChange={this.pwdChanged}
            />
          </div>

          <div className="form-input">
            <input
              type="button"
              value="Login"
              onClick={this.submitControlled}
            />
            <input type="button" value="Reset" />
          </div>
        </form>

        <h3 style={{ color: "red" }}>{this.state.loginMessage}</h3>
      </section>
    );
  }
}

export default Login;
