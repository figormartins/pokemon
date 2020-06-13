import React from 'react'
import { Container, Input, PokemonList } from './styles'
import PokemonMiniature from '../PokemonMiniature'

const Search = ({ pokemons }) => {
  return (
    <Container>
      <Input />
      <PokemonList>
        <PokemonMiniature pokemon={pokemons[2]} />
        <PokemonMiniature pokemon={pokemons[123]} />
        <PokemonMiniature pokemon={pokemons[41]} />
        <PokemonMiniature pokemon={pokemons[5]} />
        <PokemonMiniature pokemon={pokemons[149]} />
        <PokemonMiniature pokemon={pokemons[91]} />
        <PokemonMiniature pokemon={pokemons[127]} />
        <PokemonMiniature pokemon={pokemons[11]} />
        <PokemonMiniature pokemon={pokemons[64]} />
      </PokemonList>
    </Container>
  )
}

export default Search
