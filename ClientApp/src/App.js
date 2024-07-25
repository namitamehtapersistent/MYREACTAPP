import { useEffect, useState } from "react";

const App = () => {
  //1. create usestate
  const [employees, setEmployees] = useState([])

//2. Call api
useEffect(() => {
  fetch("api/employee/GetEmployees")
  .then(response => {
    console.log(response);
    var obj = response.json();
    console.log(obj);
     return obj;
  }).then(responseJson => {
      setEmployees(responseJson)
  })
}, []) 

// 3. Create div & table
  return(
    <div className="container">
       <h1> Employees </h1>
       <div className="row">
          <div className="col-sm-12">
            <table className="table tables-striped">
              <thead>
                <tr>
                <th>IdEmployee</th>
                <th>Name</th>
                <th>Email</th>
                <th>Full Address</th>
                <th>Phone</th>
                </tr>
              </thead>
              <tbody>
                {
                  employees.map((item) => (
                    <tr>
                       <td>{ item.idEmployee }</td>
                       <td>{ item.name }</td>
                       <td>{ item.email }</td>
                       <td>{ item.address }</td>
                       <td>{ item.phone }</td>
                       </tr>
                  ))
                }
              </tbody>
            </table>
          </div>
       </div>
    </div>
  )
}

export default App;
