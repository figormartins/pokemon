import React from 'react'
import { Card, Types, Dot } from './styles'

const PokemonMiniature = ({ pokemon }) => {
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
          <p>Altura: {pokemon?.height} <span>m</span></p>
          <p>Peso: {pokemon?.weight} <span>kg</span></p>
        </div>
      </div>
    </Card>
  )
}

export default PokemonMiniature
