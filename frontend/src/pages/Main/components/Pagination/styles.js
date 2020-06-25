import styled from 'styled-components'

const Container = styled.div`
  display: flex;
  justify-content: center;
  margin-right: 40px;
`

const List = styled.ul`
  display: flex;
  align-items: center;
  justify-content: center;
  padding: 10px;
  border-radius: 3px;
  list-style: none;
`

const Item = styled.li`
  border-color: #bb315a;
  background: #26273a;
  min-height: 30px;
  min-width: 30px;
  display: flex;
  align-items: center;
  justify-content: center;
  text-align: center;
  border-radius: 3px;
  transition: 150ms;
  box-shadow:
    0 1px 1px rgba(0,0,0,0.08),
    0 2px 2px rgba(0,0,0,0.12),
    0 4px 4px rgba(0,0,0,0.16),
    0 8px 8px rgba(0,0,0,0.20);

  & + li {
    margin-left: 10px;
  }

  &:hover {
    cursor: ${({ children }) => isNaN(children) ? "default": "pointer"};
    border: ${({ children }) => isNaN(children) ? "" : "solid 2px #bb315a !important"};
  }

  &.selected {
    border: solid 2px #1d43a0;
  }
`

export { Container, List, Item }
