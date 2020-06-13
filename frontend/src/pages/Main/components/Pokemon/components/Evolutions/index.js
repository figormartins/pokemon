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
    if (prev) {
      prev.forEach(async p => {
        const pokemon = await fetchPokemon(p.number)
        setEvolutions(state => [...state, pokemon])
      })
    }

    if (next) {
      next.forEach(async n => {
        const pokemon = await fetchPokemon(n.number)
        setEvolutions(state => [...state, pokemon])
      })
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
