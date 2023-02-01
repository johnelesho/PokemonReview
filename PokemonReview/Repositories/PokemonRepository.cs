using Microsoft.EntityFrameworkCore;
using PokemonReview.Contexts;
using PokemonReview.Interface;
using PokemonReview.Models;

namespace PokemonReview.Repositories
{
    public class PokemonRepository : IPokemonRepository
    {
        public PokemonRepository(AppDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public readonly AppDbContext DbContext;

        public async Task<ICollection<Pokemon>> GetPokemons()
        {
           return await DbContext.Pokemons.OrderBy(p => p.Id).ToListAsync();
        }

        public async Task<Pokemon> GetSinglePokemon(int id)
        {
            return await DbContext.Pokemons.FindAsync(id);
        }
    }
}
