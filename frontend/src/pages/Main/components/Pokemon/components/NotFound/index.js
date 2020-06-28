import React from 'react'

import { Title, Main } from './styles'

import notfound from '../../../../../../assets/not-found.png'
import loading from '../../../../../../assets/loading.gif'

const NotFound = () => (
  <>
    <Title>
      <img src={notfound} alt="Pokemon not found" />
    </Title>
    <Main>
      <img src={loading} alt="Pokemon not found" />
    </Main>
  </>
)

export default NotFound
