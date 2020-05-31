import React from 'react'
import { Card, Types, Dot } from './styles'

const PokemonMiniature = ({ pokemon }) => {
  return (
    <Card>
      <div>
        <Types>
          {pokemon?.type?.map(currType => (
            <Dot key={currType} element={currType}></Dot>
          ))}
        </Types>
      </div>

      <div>
        <img src={pokemon?.image} alt="" />
        <div>
          <p>Altura: {pokemon?.height} m</p>
          <p>Peso: {pokemon?.weight} kg</p>
        </div>
      </div>
    </Card>
  )
}

export default PokemonMiniature
