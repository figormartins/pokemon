using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PokeApi.Data;
using PokeApi.Model;

namespace PokeApi.Repositories
{
  public class BaseRepository<T> where T : class 
  {
    protected readonly ApplicationContext context;
    protected readonly DbSet<T> dbSet;

    public BaseRepository(ApplicationContext context)
    {
      this.context = context;
      dbSet = context.Set<T>();
    }
  }
}