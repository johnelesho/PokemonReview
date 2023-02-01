using PokemonReview.Models;

namespace PokemonReview.Interface
{
    public interface IAppRepository<T>
    {
        Task<T> AddOne(T requestBody);
        Task<ICollection<T>> GetAll();
         Task<T> GetOne(int id);
         Task<T> DeleteOne(int id);
        Task<T> PutOne(int id, T requestBody);
    }
}
