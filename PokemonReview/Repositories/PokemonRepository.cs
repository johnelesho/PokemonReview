using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using PokemonReview.Contexts;
using PokemonReview.Dtos;
using PokemonReview.Interface;
using PokemonReview.Models;

namespace PokemonReview.Repositories
{
    public class PokemonRepository : IAppRepository<Pokemon>
    {
        public PokemonRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public readonly AppDbContext _dbContext;

        public async Task<ICollection<Pokemon>> GetAll()
        {
           return await _dbContext.Pokemons.OrderBy(p => p.Id).ToListAsync();
        }

        public async Task<Pokemon> GetOne(int id)
        {
            var pokemon = await _dbContext.Pokemons.FindAsync(id);
            if (pokemon == null)
                throw new BadHttpRequestException("Invalid Pokemon Id");

            return pokemon;
        }

        public async Task<Pokemon> AddOne(Pokemon requestBody)
        {
            Pokemon body = requestBody;
             await _dbContext.Pokemons.AddAsync(body);
            await _dbContext.SaveChangesAsync();

           
            return body;
        }

        public async Task<Pokemon> PutOne(int id, Pokemon requestBody)
        {
            var pokemon = await _dbContext.Pokemons.FindAsync(id);
            if (pokemon == null)
                throw new BadHttpRequestException("Invalid Pokemon Id");

            //pokemon.Id = id;
            pokemon.Name= requestBody.Name;
            pokemon.BirthDay = requestBody.BirthDay;

            await _dbContext.SaveChangesAsync();

            return pokemon;
            
        }

        public async Task<Pokemon> DeleteOne(int id)
        {
            var Pokemon = await _dbContext.Pokemons.FindAsync(id);
            if (Pokemon == null)
            {
                throw new BadHttpRequestException("Invalid Id");
            }

            _dbContext.Pokemons.Remove(Pokemon);

            return Pokemon;
        }
    }
}
