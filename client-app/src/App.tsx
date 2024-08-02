import { useEffect, useState } from "react";
import {
  ApolloClient,
  InMemoryCache,
  ApolloProvider,
  HttpLink,
  from,
} from "@apollo/client";
import { onError } from "@apollo/client/link/error";
import GetUsers from "./Components/GetUsers";

const errorLink = onError(({ graphQLErrors, networkError }) => {
  if (graphQLErrors) {
    
    graphQLErrors.map(({ message, locations, path }) => {
      alert(`Graphql error ${message}`);
    });
  }
});

const link = from([
  errorLink,
  new HttpLink({ uri: "https://localhost:7258/graphql"}),
]);

const client = new ApolloClient({
  cache: new InMemoryCache(),
  link: link,
});

const App = () => {
  //1. create usestate
  const [devices, setDevices] = useState([])

//2. Call api
useEffect(() => {
    fetch("api/device/GetDevices")
  .then(response => {
    console.log(response);
    var obj = response.json();
    console.log(obj);
     return obj;
  }).then(responseJson => {
      setDevices(responseJson)
  })
}, []) 

// 3. Create div & table
  return(
    <div className="container">
    <ApolloProvider client={client}>
        {" "}
        <GetUsers />
    </ApolloProvider>

       {/* <h1> Device Details </h1>
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
                  devices.map((item : any) => (
                    <tr>
                          <td>{item.deviceId }</td>
                          <td>{item.name }</td>
                          <td>{item.location }</td>
                          <td>{item.status }</td>
                          <td>{item.stage }</td>
                       </tr>
                  ))
                }
              </tbody>
            </table>
          </div>
       </div> */}
    </div>
  )
}

export default App;
