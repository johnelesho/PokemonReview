using PokemonReview.Dtos;

namespace PokemonReview.Models
{
    public class Owner : AppModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gymn { get; set; }
        public Country Country { get; set; }
        public ICollection<PokemonOwner> PokeMonOwners { get; set; }

        public static implicit operator Owner(OwnerRequest v)
        {
            return new Owner()
            {
                Name = v.Name,
                Gymn = v.Gymn,
             

            };
        }
    }
}
