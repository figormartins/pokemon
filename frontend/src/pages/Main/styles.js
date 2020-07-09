import styled from 'styled-components'
import valor from '../../assets/Intersect.svg'

const Container = styled.div`
  background: #15172B;
  border-radius: 15px;
  min-height: calc(100vh - 60px);
  height: 100%;
  max-width: 1600px;
  padding: 40px;
  margin: 0 auto;
  z-index: 1;
`

const Dashboard = styled.div`
  width: 100%;
  height: 100%;
  display: flex;
  align-items: stretch;
  justify-content: space-around;
`

const Presentation = styled.div`
  margin-right: 0px;
  flex: 1;
  border-radius: 15px;
  z-index: 1;

  div {
    padding: 20px 40px 20px 0;
  }
`

const ImageBack = styled.img.attrs((props) => ({
  src: props.image
}))`
  position: absolute;
  width: 100px;
  bottom: -100px;
  left: 0px;
  filter: opacity(50%);
  z-index: 10;
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

    span {
      font-weight: 700;
      color: #565790;
    }
  }
`

const Board = styled.div`
  background: #F0F0FF url(${valor}) no-repeat 100% bottom;
  flex: 2;
  border-radius: 15px;
`

const Error = styled.div`
  max-width: 70%;
  margin: 50px auto;

  img {
    width: 100%;
  }
`

export { Container, Dashboard, Presentation, Header, Board, ImageBack, Error }
