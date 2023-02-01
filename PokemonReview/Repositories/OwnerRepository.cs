using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using PokemonReview;
using PokemonReview.Contexts;
using PokemonReview.Dtos;
using PokemonReview.Interface;
using PokemonReview.Models;

namespace PokemonReview.Repositories
{
    public class OwnerRepository : IAppRepository<Owner>
    {
        public OwnerRepository(AppDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public readonly AppDbContext DbContext;

        public async Task<ICollection<Owner>> GetAll()
        {
            return await DbContext.Owners.OrderBy(p => p.Id).ToListAsync();
        }

        public async Task<Owner> GetOne(int id)
        {
            var  o =  await DbContext.Owners.FindAsync(id);
            if (o == null)
                throw new BadHttpRequestException("Invalid Owner Id");
            return o;
        }

        public async Task<Owner> AddOne(Owner requestBody)
        {
            Owner body = requestBody;
            await DbContext.Owners.AddAsync(body);
            await DbContext.SaveChangesAsync();


            return body;
        }

        public async Task<Owner> PutOne(int id, Owner requestBody)
        {
            var Owner = await DbContext.Owners.FindAsync(id);
            if(Owner == null)
            {
                throw new BadHttpRequestException("Invalid Id");
            }

           
            Owner.Name = requestBody.Name;
            Owner.Gymn = requestBody.Gymn;
            //Owner.Country = requestBody.Country;

            await DbContext.SaveChangesAsync();

            return Owner;
        }

        public async Task<Owner> DeleteOne(int id)
        {
            var Owner = await DbContext.Owners.FindAsync(id);
            if (Owner == null)
            {
                throw new BadHttpRequestException("Invalid Id");
            }

            DbContext.Owners.Remove(Owner);

            return Owner;
        }
    }
}
