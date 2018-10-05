import React from "react";
import { Redirect } from "react-router-dom";
import axios from "axios";

class AddDepartment extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      created: false,
      mandatoryNameError: "",
    };

    this.submitForm = this.submitForm.bind(this);
  }

  submitForm(ev) {
    const deptName = this.deptName.value;

    if (deptName === "") {
      this.setState({ mandatoryNameError: "Required" });
      return;
    }

    this.setState({ mandatoryNameError: "" });

    const submitValues = {
      name: deptName,
    };

    axios
      .post("http://localhost:3004/departments", submitValues)
      .then(response => {
        this.setState({ created: true });
      })
      .catch(error => {
        console.log("Error: ", error);
      });
  }

  render() {
    if (this.state.created === true) {
      return <Redirect to="department-list" />;
    }

    return (
      <section className="content">
        <h1>Create Department</h1>
        <form>
          <div className="form-input">
            <label htmlFor="dname">Name:</label>
            <input
              name="dname"
              type="text"
              ref={node => {
                this.deptName = node;
              }}
            />
            &nbsp;
            <span style={{ color: "maroon" }}>
              {this.state.mandatoryNameError}
            </span>
          </div>

          <div className="form-input">
            <input type="button" value="Create" onClick={this.submitForm} />
            <input type="reset" value="Reset" />
          </div>
        </form>
      </section>
    );
  }
}

export default AddDepartment;
