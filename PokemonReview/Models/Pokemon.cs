using PokemonReview.Dtos;

namespace PokemonReview.Models
{
    public class Pokemon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDay { get; set; }

        public ICollection<Review> Reviews { get; set; }
        public ICollection<PokemonOwner> PokeMonOwners { get; set; }
        public ICollection<PokemonCategory> PokemonCategories { get; set; }

        public static implicit operator Pokemon(PokemonRequest request)
        {
            return new Pokemon()
            {
                Name = request.Name,
                BirthDay = request.BirthDay
            };
        }

     
    }
}
 