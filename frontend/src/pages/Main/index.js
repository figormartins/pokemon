import React, { useState, useEffect } from 'react'

import { Container, Dashboard, Presentation, Header, Board } from './styles'
import Search from './components/Search'
import Pokemon from './components/Pokemon'

import { api } from '../../services/api'

const Main = () => {
  const [pokemons, setPokemons] = useState({})
  const [pokemon, setPokemon] = useState({})

  useEffect(() => {
    const fetchPokemons = async () => {
      const response = await api.get('pokemon')
      const filteredData = response.data.filter((p) => p.number <= 9)

      setPokemons(filteredData)
      setPokemon(response.data[0] || {})
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

          <Search pokemons={pokemons} pokemon={pokemon} setPokemon={setPokemon} />
        </Presentation>

        <Board>
          <Pokemon pokemon={pokemon} />
        </Board>
      </Dashboard>
    </Container>
  )
}

export default Main
