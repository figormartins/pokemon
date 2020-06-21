import styled from 'styled-components'

const Title = styled.h1`
  margin-top: 15px;
  margin-bottom: 10px;
`

const Container = styled.div`
  max-height: 250px;
  display: flex;
  flex-direction: row;
  justify-content: flex-start;
`

const Evolution = styled.div`
  display: flex;
  align-items: flex-end;
  max-width: 100px;
  padding: 5px;


  img {
    height: 100px;
  }
`

export { Title, Container, Evolution }
