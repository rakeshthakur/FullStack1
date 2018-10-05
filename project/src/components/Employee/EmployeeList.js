import React from "react";

class EmployeeList extends React.Component {
  render() {
    return (
      <section className="content">
        <h1>Employees</h1>
        <form action="">
          <div>
            <input type="button" value="Create" />
            <input type="button" value="Update" />
            <input type="button" value="Delete" />
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

              <tbody>
                <tr>
                  <td>100</td>
                  <td>Human Resources</td>
                  <td>
                    <input name="dept" type="radio" />
                  </td>
                </tr>
                <tr>
                  <td>100</td>
                  <td>Human Resources</td>
                  <td>
                    <input name="dept" type="radio" />
                  </td>
                </tr>
              </tbody>
            </table>
          </div>
        </form>
      </section>
    );
  }
}

export default EmployeeList;
