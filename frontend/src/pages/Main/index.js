import React from 'react'

import { Container, Dashboard, Presentation, Header, Board } from './styles'

import img from '../../assets/dots.svg'


const Main = () => {
  return (
    <Container>
      <Dashboard>
        <Presentation>
          <Header>
            <h1>Hi Igor</h1>
            <p>Let's search a amazing <span>Pokemon</span></p>
          </Header>
          <img src={img} alt="dots"/>
        </Presentation>

        <Board>
        </Board>
      </Dashboard>
    </Container>
  )
}

export default Main
