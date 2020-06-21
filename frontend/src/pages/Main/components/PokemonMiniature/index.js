import React from 'react'
import { Card, Types, Dot } from './styles'

import elementsTypes from '../../../../utils/functions/elementsTypes'

const PokemonMiniature = ({ pokemon, className, setPokemon }) => {
  const formatNumber = (number) => {
    const numList = String(number).split('.')
    let numFormated = numList[0]

    if (numList[1]) {
      numFormated += "." + `${numList[1]}0`.slice(-2)
    }

    return numFormated
  }

  const handleSelectPokemon = () => {
    setPokemon(pokemon)
  }

  return (
    <Card className={className} color={elementsTypes[pokemon.type[0]]}onClick={handleSelectPokemon}>
      <div className="infos">
        <p>{pokemon?.name}</p>
        <Types>
          {pokemon?.type?.map(currType => (
            <Dot key={currType} element={currType}></Dot>
          ))}
        </Types>
        <div>
          <p>Height: {formatNumber(pokemon?.height)} <span>m</span></p>
          <p>Weight: {formatNumber(pokemon?.weight)} <span>kg</span></p>
        </div>
      </div>

      <div>
        <img src={pokemon?.image} alt="" />
      </div>
    </Card>
  )
}

export default PokemonMiniature
