﻿using Microsoft.EntityFrameworkCore;
using PokemonReview.Models;

namespace PokemonReview.Contexts
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options ): base(options)
        {
                
        }

        public DbSet<Pokemon> Pokemons { get;set }

        public DbSet<Owner> Owners { get; set; }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Reviewer> Reviewers { get; set; }
        public DbSet<PokemonCategory> PokemonCategories { get; set; }
        public DbSet<PokemonOwner > PokemonCategories { get; set; }
        
    }
}
