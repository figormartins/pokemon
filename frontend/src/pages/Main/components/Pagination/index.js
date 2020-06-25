import React, { useState } from 'react'
import { Container, List, Item } from './styles'
import { useEffect } from 'react'


const Pagination = (props) => {
  const [totalPages, setTotalPages] = useState(0)
  const [selectedPage, setSelectedPage] = useState(0)

  const paginate = (totalPages, selectedPage) => {
    let pages = []
    let pageBefore = 0

    for (let currPage = 1; currPage <= totalPages; currPage++) {
      const firstOrLastPage = currPage === 1 || currPage === totalPages
      const pageAfterSelectedPage = selectedPage + 2 >= currPage
      const pageBeforeSelectedPage = selectedPage - 2 <= currPage

      if (firstOrLastPage || (pageAfterSelectedPage && pageBeforeSelectedPage)) {
        if (currPage - pageBefore > 1)
          pages.push("...")

        pages.push(currPage)
        pageBefore = currPage
      }
    }

    return pages
  }

  const changePage = (page) => {
    props.setPage(page)
  }

  useEffect(() => {
    setTotalPages(props.totalPages)
    setSelectedPage(props.page)
  }, [props])

  return (
    <Container>
      <List>
        {
          paginate(totalPages, selectedPage)
            .map((page, index) =>
              <Item
                key={index}
                onClick={() => !isNaN(page) && changePage(page)}
                className={selectedPage === page ? "selected" : ""}
              >
                {page}
              </Item>
            )
        }
      </List>
    </Container>
  )
}

export default Pagination
