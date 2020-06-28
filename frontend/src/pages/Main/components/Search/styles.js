import styled from 'styled-components'

const Container = styled.div`
  display: flex;
  flex-direction: column;
`

const Input = styled.input.attrs(() => ({
  placeholder: "Search your pokemon..."
}))`
  color: #f1f1f5;
  border: none;
  padding: 15px 15px;
  border-radius: 10px;
  width: 510px;
  font-size: 14px;
  font-weight: 500;
  background: #26273a;
  flex: 1;
`

const PokemonList = styled.ul`
  margin-top: 40px;
  display: grid;
  grid-template-columns: 1fr 1fr 1fr;
  grid-template-rows: 1fr 1fr 1fr;
  gap: 30px;
`

export { Container, Input, PokemonList }
