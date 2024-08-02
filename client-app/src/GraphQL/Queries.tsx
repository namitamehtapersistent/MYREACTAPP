import { gql } from "@apollo/client";

export const LOAD_USERS = gql`
  query{
  weathers{
    temperatureC,
    temperatureF,
    summary
  }
}
`;
