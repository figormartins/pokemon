import React from 'react'
import { Container, Input, PokemonList } from './styles'
import PokemonMiniature from '../PokemonMiniature'

const Search = ({ pokemons, pokemon, setPokemon }) => {
  return (
    <Container>
      <Input />
      <PokemonList>
        {pokemons.length &&
          pokemons.map(poke =>
            <PokemonMiniature
              key={poke.number}
              pokemon={poke}
              className={poke.number === pokemon.number ? "selected" : ""}
              setPokemon={setPokemon}
            />
          )
        }
      </PokemonList>
    </Container>
  )
}

export default Search
