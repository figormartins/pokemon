import styled from 'styled-components'

const Container = styled.div`
  background: #15172B;
  border-radius: 15px;
  height: calc(100vh - 60px);
  max-width: 1600px;
  padding: 40px;
  margin: 0 auto;
`

const Dashboard = styled.div`
  width: 100%;
  height: 100%;
  display: flex;
  align-items: stretch;
  justify-content: space-around;
`

const Presentation = styled.div`
  margin-right: 40px;
  flex: 1;
  border-radius: 15px;
  position: relative;

  div {
    padding: 20px 40px;
  }
`

const ImageBack = styled.img.attrs((props) => ({
  src: props.image
}))`
  position: absolute;
  width: 120px;
  bottom: 0px;
  left: 0px;
  filter: opacity(50%);
`

const Header = styled.div`
  margin-top: 50px;

  h1 {
    font-size: 28px;
  }

  p {
    margin-top: 10px;
    color: #565766;
    font-size: 12px;
  }
`

const Board = styled.div`
  background: #fff;
  flex: 2;
  border-radius: 15px;
`

export { Container, Dashboard, Presentation, Header, Board, ImageBack }
