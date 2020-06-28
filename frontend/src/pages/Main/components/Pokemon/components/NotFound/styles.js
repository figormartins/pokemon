import styled from 'styled-components'

const Title = styled.div`
  display: flex;
  flex: 1;
  align-items: center;
  justify-content: center;
  margin-top: 50px;
`

const Main = styled.div`
  display: flex;
  justify-content: flex-end;
  align-items: center;
  padding: 0 60px;
  margin-top: 40px;

  img {
    margin: 50px 0;
  }
`
export { Title, Main }
