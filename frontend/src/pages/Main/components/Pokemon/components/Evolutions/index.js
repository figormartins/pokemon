import React, { useState, useEffect } from 'react'

import { Container } from './styles'

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
        setEvolutions([...evolutions, pokemon])
      })
    }

    if (next) {
      next.forEach(async n => {
        const pokemon = await fetchPokemon(n.number)
        setEvolutions([...evolutions, pokemon])
      })
    }
    console.log(evolutions)

  }, [prev, next])

  return (
    <Container>
      {true && (
        <>
          <h1>Evolutions</h1>
          {
            <p>{JSON.stringify(evolutions)}</p>

          }
          {
            evolutions && (
              evolutions.map(ev => <h1 key={ev.name}>{ev.name}</h1>)
            )
          }
        </>
      )}
    </Container>
  )
}

export default Evolutions
