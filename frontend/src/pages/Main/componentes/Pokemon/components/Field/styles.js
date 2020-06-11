import styled from 'styled-components'
import ElementTypes from '../../../../../../utils/functions/elementsTypes'


const Fieldset = styled.fieldset`
  border-radius: 8px;
  border: none;
  padding: 10px 0px 5px;
  padding-top: 5px;
  margin-top: 10px;
  background: linear-gradient(to right, #F0F0Ff, #F0F0FF );

  legend {
    font-size: 12px;
    font-weight: 700;
  }
`

const Dot = styled.span.attrs(({ element }) => ({
  color: ElementTypes[element]
}))`
  background: ${({ color }) => color};
  border-radius: 5px;
  margin: 10px 5px;
  padding: 2px 10px;
  color: #fff;
  filter: opacity(0.95);
`

export { Fieldset, Dot }
