import styled from 'styled-components'

const Header = styled.div`
  color: #565790;
  font-weight: 700;
  font-size: 36px;
  text-align: center;
  margin-top: 15px;
`

const Container = styled.div`
  margin-top: 50px;
  padding: 20px;
  display: grid;
  grid-template-columns: 1fr 1fr;
  gap: 20px;
`

const Information = styled.div`
  color: #0B0A0Dee;
`

const Image = styled.img.attrs(({ image }) => ({
  src: image
}))`
  max-width: 500px;
`

export { Header, Container, Information, Image }
