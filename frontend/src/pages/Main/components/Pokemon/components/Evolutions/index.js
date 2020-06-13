import React, { useState, useEffect } from 'react'

import { Title, Container, Evolution } from './styles'

import { api } from '../../../../../../services/api'

const Evolutions = ({ prev, next }) => {
  const [evolutions, setEvolutions] = useState([])

  const fetchPokemon = async (number) => {
    const response = await api.get(`pokemon/${number}`)

    return response.data
  }

  useEffect(() => {
    if (prev && next) {
      const prevs = prev.map(async p => {
        const pokemon = await fetchPokemon(p.number)

        return pokemon
      })

      const nexts = next.map(async n => {
        const pokemon = await fetchPokemon(n.number)

        return pokemon
      })

      const all = [...prevs, ...nexts]
      Promise.all(all)
        .then(values => setEvolutions(values))
    }
  }, [prev, next])

  return (

    evolutions.length > 0 && (
      <>
        <Title>Evolutions</Title>
        <Container>
          {
            evolutions && (
              evolutions.map(evolution => (
                <Evolution key={evolution.number}>
                  <img src={evolution.image} alt={evolution.name} />
                </Evolution>
              ))
            )
          }
        </Container>
      </>
    )


  )
}

export default Evolutions
