import React, { useEffect, useState } from "react";
import { useQuery, gql } from "@apollo/client";
import { LOAD_USERS } from "../GraphQL/Queries";

function GetUsers() {
  const { error, loading, data } = useQuery(LOAD_USERS);
  const [users, setUsers] = useState([]);
  useEffect(() => {
    if (data) {
      console.log(data);
      setUsers(data.getAllUsers);
    }
  }, [data]);

  return (
    <div>
      {" Graph QL Integration "}
      {users.map((val: any) => {
        return <h1> {val.temperatureC}</h1>;
      })}
    </div>
  );
}

export default GetUsers;
