using Microsoft.EntityFrameworkCore;
using PokemonReview.Models;

namespace PokemonReview.Contexts
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options ): base(options)
        {
                
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<PokemonCategory>().HasKey(sc => new { sc.CategoryId, sc.PokemonId });

            //modelBuilder.Entity<PokemonCategory>().HasOne(sc => sc.Pokemon)
            //  .WithMany(sc => sc.PokemonCategories)
            //  .HasForeignKey(sc => sc.CategoryId);
            modelBuilder.Entity<PokemonOwner>().HasKey(sc => new { sc.OwnerId, sc.PokemonId });
            //modelBuilder.Entity<PokemonOwner>().HasOne(sc => sc.Pokemon)
            //    .WithMany( sc => sc.PokeMonOwners)
            //    .HasForeignKey(sc=>sc.OwnerId);
        }

        public DbSet<Pokemon> Pokemons { get; set; }

        public DbSet<Owner> Owners { get; set; }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Reviewer> Reviewers { get; set; }
        public DbSet<PokemonCategory> PokemonCategories { get; set; }
        public DbSet<PokemonOwner > PokemonOwners { get; set; }
        
    }
}
