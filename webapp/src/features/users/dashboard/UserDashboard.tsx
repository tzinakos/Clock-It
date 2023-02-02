import React from 'react';
import { Grid, List } from 'semantic-ui-react';
import { User } from '../../../app/models/User';

interface Props {
    users: User[];
}

export default function UserDashBoard({users}: Props) {
    return (
        <Grid>
            <Grid.Column width='10'>
            <List>
              {users.map((user) => (
                  <List.Item key={user.id}>
                      {user.firstName}
                  </List.Item>
              ))}
          </List>
            </Grid.Column>
        </Grid>
    )
}