import styled from 'styled-components'

const Header = styled.div.attrs(({ number }) => ({
  number
}))`
  color: #15172B;
  font-weight: 700;
  font-size: 36px;
  text-align: center;
  margin-top: 15px;
  position: relative;

  &:after {
    content: "${({ number }) => number}";

    position: absolute;
    font-size: 28px;
    line-height: 60px;
    border-radius: 50%;
    width: 60px;
    height: 60px;
    background: #15172B;
    color: #F0F0FF;
    top: 0;
    left: 15px;
  }
`

const Container = styled.div`
  margin-top: 50px;
  padding: 20px;
  display: grid;
  grid-template-columns: 1fr 1fr;
  gap: 20px;
`

const Information = styled.div`
  color: #151720;

  h1 {
    font-size: 18px;
  }
`

const Image = styled.img.attrs(({ image }) => ({
  src: image
}))`
  max-width: 500px;
  justify-self: end;
  align-self: end;
  transition: 150ms;

  &:hover {
    transform: scale(1.2);
  }
`

export { Header, Container, Information, Image }
