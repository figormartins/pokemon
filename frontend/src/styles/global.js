import { createGlobalStyle } from 'styled-components'

export default createGlobalStyle`
  @import url('https://fonts.googleapis.com/css2?family=Roboto:wght@400;500;700&display=swap');

  * {
    margin: 0;
    padding: 0;
    outline: 0;
    box-sizing: border-box;
  }

  html, body, #root {
    min-height: 100%;
    height: 100%;
  }

  body {
    padding: 30px;
    background: #0B0A0D;
    -webkit-font-smoothing: antialiased !important;
  }

  body, input, button {
    color: #DCDCDF;
    font-size: 14px;
    font-family: 'Roboto', sans-serif;
  }

  button {
    cursor: pointer;
  }
`
