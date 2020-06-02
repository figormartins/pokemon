import axios from 'axios'

const api = axios.create({
  baseURL: 'https://localhost:5001/'
})

const apiV2 = axios.create({
  baseURL: 'https://pokeapi.co/api/v2/pokemon-species/'
})


export {api, apiV2}
