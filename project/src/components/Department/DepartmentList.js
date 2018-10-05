import React from "react";
import axios from "axios";
import { Link } from "react-router-dom";

class DepartmentList extends React.Component {
  constructor(props) {
    super(props);

    this.state = {
      departments: [],
      idToDelete: 0,
    };

    this.departmentSelected = this.departmentSelected.bind(this);
    this.deleteSelected = this.deleteSelected.bind(this);
  }

  componentDidMount() {
    // api call
    axios
      .get("http://localhost:3004/departments")
      .then(response => {
        // handle success
        this.setState({ departments: response.data });
      })
      .catch(error => {
        // handle error
        console.log("Error: ", error);
      });
  }

  deleteSelected() {
    // validation
    if (this.state.idToDelete === 0) {
      alert("Select a record to delete!");
      return;
    }

    axios
      .delete(`http://localhost:3004/departments/${this.state.idToDelete}`)
      .then(response => {
        this.setState({ idToDelete: 0 });
        return axios.get("http://localhost:3004/departments");
      })
      .then(response => {
        // handle success
        this.setState({ departments: response.data });
      })
      .catch(error => {
        console.log("Error: ", error);
      });
  }

  departmentSelected(id) {
    this.setState({ idToDelete: id });
  }

  render() {
    const departmentListJSX = this.state.departments.map(element => (
      <tr key={element.id}>
        <td>{element.id}</td>
        <td>{element.name}</td>
        <td>
          <input
            name="dept"
            type="radio"
            onChange={() => {
              this.departmentSelected(element.id);
            }}
          />
        </td>
      </tr>
    ));

    return (
      <section className="content">
        <h1>Departments</h1>
        <form>
          <div>
            <Link to="/add-department">
              <input type="button" value="Create" />
            </Link>
            <input type="button" value="Delete" onClick={this.deleteSelected} />
          </div>
          <div>
            <table id="tab">
              <thead>
                <tr>
                  <th>Id</th>
                  <th>Name</th>
                  <th>&nbsp;</th>
                </tr>
              </thead>

              <tbody>{departmentListJSX}</tbody>
            </table>
          </div>
        </form>
      </section>
    );
  }
}

export default DepartmentList;
