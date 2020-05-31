import React, { useState, useEffect } from 'react'

import { Container, Dashboard, ImageBack, Presentation, Header, Board } from './styles'
import Search from './componentes/Search'

import api from '../../services/api'

import img from '../../assets/dots.svg'


const Main = () => {
  const [pokemons, setPokemons] = useState({})

  useEffect(() => {
    const fetchPokemons = async () => {
      const response = await api.get('pokemon')

      setPokemons(response.data)
    }

    fetchPokemons()
  }, [])

  return (
    <Container>
      <Dashboard>
        <Presentation>
          <Header>
            <h1>Hi Igor,</h1>
            <p>Let's search a amazing <span>Pokemon</span></p>
          </Header>

          <Search pokemons={pokemons} />
          <ImageBack image={img}/>
        </Presentation>

        <Board>
        </Board>
      </Dashboard>
    </Container>
  )
}

export default Main
