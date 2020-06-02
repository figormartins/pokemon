import React, { useState, useEffect } from 'react'

import { Header, Container, Information, Image } from './styles'

import { apiV2 } from '../../../../services/api'

const Pokemon = (props) => {
  const [pokemon, setPokemon] = useState({})
  const [description, setDescription] = useState("")

  useEffect(() => {
    setPokemon(props.pokemon)

    const getDescription = async (number) => {
      if (!isNaN(number)) {
        const descriptions = await apiV2.get(`${number}`)
        const desc = descriptions
          .data
          .flavor_text_entries
          .find(p => p.language.name === "en")
          .flavor_text

        setDescription(desc)
      }
    }

    getDescription(props.pokemon.number)
  }, [props.pokemon, pokemon])

  return (
    <>
      <Header>{pokemon.name}</Header>
      <Container>
        <Information>
          {(!pokemon.number) ?
            <h1>An amazing Pokemon</h1> :
            <h1>{description}</h1>
          }
        </Information>
        <Image image={pokemon.image} />
      </Container>
    </>
  )
}

export default Pokemon
