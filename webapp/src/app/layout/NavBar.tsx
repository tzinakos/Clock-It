import React from "react"
import { Button, Container, Menu } from "semantic-ui-react"

export default function NavBar() {
  return (
    <Menu inverted fixed="top">
      <Container>
        <Menu.Item header>
          <img src ="/assers/logo.png" />
          Clock Them All
        </Menu.Item>
        <Menu.Item name = "Users"/>
        <Menu.Item>
          <Button positive content = "Create User" />
        </Menu.Item>
      </Container>
    </Menu>
  )
}
   
