using System.Globalization;

namespace PokemonReview.Models
{
    public class Country : AppModel
    {
        public int Id { get; set; }
        public string   Name   { get; set; }
        public ICollection<Owner> Owners { get; set; }

    }
}
