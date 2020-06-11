import React from 'react'

import { Fieldset, Dot } from './styles'

const Field = (props) => {
  if (!props.types)
    return null

  const types = props.types

  return (
    <Fieldset>
      <legend>{props.legend}</legend>
      {
        types.map(type =>
          <Dot element={type} key={type}>{type}</Dot>
        )
      }
    </Fieldset>
  )
}

export default Field
