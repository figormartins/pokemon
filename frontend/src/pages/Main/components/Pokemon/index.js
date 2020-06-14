import React, { useState, useEffect } from 'react'

import { Header, Container, Information, Image, Display } from './styles'
import Field from './components/Field'
import Evolutions from './components/Evolutions'
import Chart from './components/Chart'

import { apiV2 } from '../../../../services/api'

const formatDescription = (description) => {
  return description.replace("", "").replace(".", ". ")
}

const Pokemon = (props) => {
  const [pokemon, setPokemon] = useState({})
  const [description, setDescription] = useState("")

  useEffect(() => {
    setPokemon(props.pokemon)

    const getDescription = async (number) => {
      if (!isNaN(number)) {
        const descriptions = await apiV2.get(`pokemon-species/${number}`)
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
      <Header number={pokemon.number}>{pokemon.name}</Header>
      <Container>
        <Information>
          <h1>{formatDescription(description)}</h1>
          <Field legend="Types" types={pokemon.type} />
          <Field legend="Weaknesses" types={pokemon.weaknesses} />
          <Chart number={pokemon.number} name={pokemon.name} />
          <Evolutions next={pokemon.nextEvolution} prev={pokemon.prevEvolution} />
        </Information>
        <Display>
          <Image image={pokemon.image} />
        </Display>
      </Container>
    </>
  )
}

export default Pokemon
