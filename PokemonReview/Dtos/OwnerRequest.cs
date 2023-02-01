using PokemonReview.Models;

namespace PokemonReview.Dtos
{
    public class OwnerRequest
    {
        public string Name { get; set; }
        public string Gymn { get; set; }
        public int Country { get; set; }
    }
}