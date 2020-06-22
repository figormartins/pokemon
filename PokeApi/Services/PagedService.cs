using System;
using System.Collections.Generic;
using System.Linq;

namespace PokeApi.Services
{
  public class PagedService<T> where T : class
  {
    public PagedService(IEnumerable<T> data, int page, int quantity)
    {
      PageSize = quantity;
      PageNumber = page;
      Data = data
        .Skip((page - 1) * quantity)
        .Take(quantity);
      TotalItems = data.Count();
    }

    public IEnumerable<T> Data { get; }

    public int PageNumber { get; }

    public int PageSize { get; }
    public int TotalItems { get; }
    public int TotalPages
    {
      get { return (int)Math.Ceiling(TotalItems / (double)PageSize); }
    }
  }
}