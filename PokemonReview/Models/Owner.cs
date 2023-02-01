namespace PokemonReview.Models
{
    public class Owner
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gymn { get; set; }
        public Country Country { get; set; }
        public ICollection<PokemonOwner> PokeMonOwners { get; set; }
    }
}
