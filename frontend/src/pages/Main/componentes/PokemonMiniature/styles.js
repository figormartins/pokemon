import styled from 'styled-components'
import ElementTypes from '../../../../utils/functions/elementsTypes'

const Card = styled.li`
  list-style: none;
  background: #26273a;
  width: 150px;
  height: 120px;
  padding: 5px;
  border: 1px solid #71717310;
  border-radius: 10px;
  display: flex;
  flex-direction: row;
  justify-content: flex-end;
  transition: 150ms;
  box-shadow:
    0 1px 1px rgba(0,0,0,0.08),
    0 2px 2px rgba(0,0,0,0.12),
    0 4px 4px rgba(0,0,0,0.16),
    0 8px 8px rgba(0,0,0,0.20),
    inset 0 1px 1px  rgb(33, 55, 109, 0.11),
    inset 0 2px 2px  rgb(33, 55, 109, 0.11),
    inset 0 3px 4px  rgb(33, 55, 109, 0.11),
    inset 0 2px 8px  rgb(33, 55, 109, 0.11),
    inset 0 1px 16px rgb(33, 55, 109, 0.11);

  &:hover {
    cursor: pointer;
    border: solid 3px #565790;
    padding: 3px;
    transform: translate(2px, -3px);
  }

  &:active {
    background: #71717f00;
    border-color: #565790aa;
  }

  div.infos {
    display: flex;
    flex-direction: column;
    align-items: flex-start;
    padding: 5px;
  }

  div {
    margin: 0;
    padding: 0;
    display: flex;
    flex-direction: column;
    align-items: flex-end;
    justify-content: initial;
    flex: 1;

    img {
      width: 70px;
      height: 70px;
      border: none;
      margin-bottom: 10px;
      position: relative;
    }

    div {
      display: flex;
      flex-direction: column;
      justify-content: stretch;

      p {
        font-size: 9px;
        font-weight: 700;
        color: #717173;
        display: block;

        span {
          font-size: 8px;
        }
      }
    }
  }
`

const Types = styled.div.attrs((element) => ({
  color: ElementTypes[element]
}))`
  display: flex !important;
  flex: 1;
  justify-content: space-around !important;
  align-items: stretch !important;
  flex-direction: row !important;
`
const Dot = styled.span.attrs(({ element }) => ({
  color: ElementTypes[element]
}))`
  flex: 1;
  width: 10px;
  height: 10px;
  border-radius: 50%;
  margin: 1px;
  background: ${({ color }) => color};
`

export { Card, Types, Dot }
