using PokemonReview.Models;

namespace PokemonReview.Dtos
{
    public class OwnerResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gymn { get; set; }
        public Country Country { get; set; }

        public static implicit operator OwnerResponse(Owner o)
        {
         

            return new OwnerResponse
            {
                Id = o.Id,
                Name = o.Name,
                Gymn = o.Gymn,
                Country = o.Country
            };
        }
    }
}