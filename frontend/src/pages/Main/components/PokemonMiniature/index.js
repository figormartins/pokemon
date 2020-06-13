import React from 'react'
import { Card, Types, Dot } from './styles'

const PokemonMiniature = ({ pokemon }) => {
  const formatNumber = (number) => {
    const numList = String(number).split('.')
    let numFormated = numList[0]

    if (numList[1]) {
      numFormated += "." + `${numList[1]}0`.slice(-2)
    }

    return numFormated
  }

  return (
    <Card>
      <div className="infos">
        <p>{pokemon?.name}</p>
        <Types>
          {pokemon?.type?.map(currType => (
            <Dot key={currType} element={currType}></Dot>
          ))}
        </Types>
      </div>

      <div>
        <img src={pokemon?.image} alt="" />
        <div>
          <p>Height: {formatNumber(pokemon?.height)} <span>m</span></p>
          <p>Weight: {formatNumber(pokemon?.weight)} <span>kg</span></p>
        </div>
      </div>
    </Card>
  )
}

export default PokemonMiniature
