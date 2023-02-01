using PokemonReview.Models;

namespace PokemonReview.Dtos

{
    public class PokemonResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDay { get; set; }

        public static implicit operator PokemonResponse(Pokemon pokemon)
        {
            return new PokemonResponse
            {
                Id = pokemon.Id,
                Name = pokemon.Name,
                BirthDay = pokemon.BirthDay,
            };
        }
    }
}