import React, { useEffect, useState } from 'react';
import axios from 'axios';
import { User } from '../models/User';
import NavBar from '../layout/NavBar'
import { Button, Container, Header, List } from 'semantic-ui-react';
import UserDashBoard from '../../features/users/dashboard/UserDashboard';


function App() {
    const [users, setUsers] = useState<User[]>([]);

    useEffect(() => {
        axios.get('https://localhost:7265/api/users')
            .then(response => {
            setUsers(response.data);
            })
    }, [])
  return (
      <>
          <NavBar/>
          <Container style = {{marginTop:"7em"}} >
          <UserDashBoard users = { users } />
          </Container>
          
    </>
  );
}

export default App;
