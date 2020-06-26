import React from 'react'
import { Container, Input, PokemonList } from './styles'
import PokemonMiniature from '../PokemonMiniature'

const Search = (
  {
    pokemons,
    pokemon,
    setPokemon,
    pokemonSearch,
    setPokemonSearch
  }
) => {
  const handleOnChange = (event) => {
    setPokemonSearch(event.target.value)
  }

  return (
    <Container>
      <Input value={pokemonSearch} onChange={handleOnChange} />
      <PokemonList>
        {pokemons.length > 0 &&
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
