import React, { useState, useEffect } from 'react'

import { Header, Container, Information, Image, Display } from './styles'
import Field from './components/Field'
import Evolutions from './components/Evolutions'
import Chart from './components/Chart'
import NotFound from './components/NotFound'
import Loading from './components/Loading'

import elementsTypes from '../../../../utils/functions/elementsTypes'

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
  }, [props, pokemon])

  return (
    <>
      {
        Object.keys(pokemon).length > 0 ?
          <>
            <Header number={pokemon.number}>{pokemon.name}</Header>
            <Container>
              <Information>
                <section>
                  <h1>{formatDescription(description)}</h1>
                  <Field legend="Types" types={pokemon.type} />
                  <Field legend="Weaknesses" types={pokemon.weaknesses} />
                </section>

                <section>
                  <Chart
                    number={pokemon.number}
                    name={pokemon.name}
                    color={elementsTypes[pokemon.type[0]]}
                  />
                </section>

                <section>
                  <Evolutions next={pokemon.nextEvolution} prev={pokemon.prevEvolution} />
                </section>
              </Information>
              <Display>
                <Image image={pokemon.image} />
              </Display>
            </Container>
          </>
          :
          <>
            {
              !props.isFound && !props.loading ?
                <NotFound /> :
                <Loading />
            }
          </>
      }
    </>
  )
}

export default Pokemon
