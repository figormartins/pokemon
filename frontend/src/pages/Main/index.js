import React, { useState, useEffect } from 'react'

import { Container, Dashboard, Presentation, Header, Board } from './styles'
import Search from './componentes/Search'
import Pokemon from './componentes/Pokemon'

import { api } from '../../services/api'

const Main = () => {
  const [pokemons, setPokemons] = useState({})
  const [pokemon, setPokemon] = useState({})

  useEffect(() => {
    const fetchPokemons = async () => {
      const response = await api.get('pokemon')

      setPokemons(response.data)
      setPokemon(response.data[5] || {})
    }

    fetchPokemons()
  }, [])

  return (
    <Container>
      <Dashboard>
        <Presentation>
          <Header>
            <h1>Hi Igor,</h1>
            <p>Let's search an amazing <span>Pokemon</span></p>
          </Header>

          <Search pokemons={pokemons} />
        </Presentation>

        <Board>
          <Pokemon pokemon={pokemon} />
        </Board>
      </Dashboard>
    </Container>
  )
}

export default Main
