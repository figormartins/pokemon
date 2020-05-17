using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PokeApi.Model;
using System.Linq;

namespace PokeApi.Data
{
  public class ApplicationContext : DbContext
  {
    public ApplicationContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      modelBuilder.Entity<Pokemon>()
        .HasKey(p => p.Id);
      modelBuilder.Entity<Pokemon>()
        .HasMany(p => p.NextEvolution)
        .WithOne(p => p.Pokemon);
      modelBuilder.Entity<Pokemon>()
        .HasMany(p => p.PrevEvolution)
        .WithOne(p => p.Pokemon);
      modelBuilder.Entity<Pokemon>()
        .HasMany(p => p.Weaknesses)
        .WithOne(p => p.Pokemon);
      modelBuilder.Entity<Pokemon>()
        .HasMany(p => p.Type)
        .WithOne(p => p.Pokemon);

      modelBuilder.Entity<TypeElement>()
        .HasKey(t => t.Id);

      modelBuilder.Entity<PokemonNextEvolution>()
        .HasKey(n => n.Id);
      modelBuilder.Entity<PokemonNextEvolution>()
        .HasOne(n => n.Pokemon)
        .WithMany(n => n.NextEvolution);
      modelBuilder.Entity<PokemonNextEvolution>()
        .HasOne(n => n.NextPokemon);

      modelBuilder.Entity<PokemonPrevEvolution>()
        .HasKey(p => p.Id);
      modelBuilder.Entity<PokemonPrevEvolution>()
        .HasOne(n => n.Pokemon)
        .WithMany(n => n.PrevEvolution);
      modelBuilder.Entity<PokemonPrevEvolution>()
        .HasOne(n => n.PrevPokemon);

      modelBuilder.Entity<PokemonTypeElement>()
        .HasKey(p => p.Id);
      modelBuilder.Entity<PokemonTypeElement>()
        .HasOne(p => p.TypeElement);
      modelBuilder.Entity<PokemonTypeElement>()
        .HasOne(p => p.Pokemon)
        .WithMany(p => p.Type);

      modelBuilder.Entity<PokemonWeakness>()
        .HasKey(p => p.Id);
      modelBuilder.Entity<PokemonWeakness>()
        .HasOne(p => p.TypeElement);
      modelBuilder.Entity<PokemonWeakness>()
        .HasOne(p => p.Pokemon)
        .WithMany(p => p.Weaknesses);
    }
  }
}