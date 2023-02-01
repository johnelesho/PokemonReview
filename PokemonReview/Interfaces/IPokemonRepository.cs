using PokemonReview.Models;

namespace PokemonReview.Interface
{
    public interface IPokemonRepository
    {
         Task<ICollection<Pokemon>> GetPokemons();
         Task<Pokemon> GetSinglePokemon(int id);
    }
}
