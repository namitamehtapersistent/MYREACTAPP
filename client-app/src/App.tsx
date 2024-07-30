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
       <h1> Device Details </h1>
       <div className="row">
          <div className="col-sm-12">
            <table className="table table-striped table-dark">
              <thead>
                <tr>
                <th>Device ID</th>
                <th>Name</th>
                <th>Location</th>
                <th>Status</th>
                <th>Stage</th>
                </tr>
              </thead>
              <tbody>
                {
                  employees.map((item : any) => (
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
