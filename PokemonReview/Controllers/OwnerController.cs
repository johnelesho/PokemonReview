using Microsoft.AspNetCore.Mvc;
using PokemonReview.Dtos;
using PokemonReview.Interface;
using PokemonReview.Models;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PokemonReview
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : Controller
    {
        private readonly IAppRepository<Owner> OwnerRepository;

        public OwnerController(IAppRepository<Owner> OwnerRepository)
        {
            this.OwnerRepository = OwnerRepository;
        }
        // GET: api/<OwnerController>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Owner>))]
        public async Task<IEnumerable<OwnerResponse>> GetAll()
        {
            return (IEnumerable<OwnerResponse>)await OwnerRepository.GetAll();
        }

        // GET api/<OwnerController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Owner))]
        public async Task<OwnerResponse> GetOneAsync(int id)
        {
            return await OwnerRepository.GetOne(id);
        }

        // POST api/<OwnerController>
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(OwnerResponse))]
        public async Task<OwnerResponse> PostAsync([FromBody] OwnerRequest requestBody)
        {
            return await OwnerRepository.AddOne(requestBody);

        }

        // PUT api/<OwnerController>/5
        [HttpPut("{id:int}")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> PutOne(int id, [FromBody] OwnerRequest requestBody)
        {
            return Ok(await OwnerRepository.PutOne(id, requestBody));
        }

        // DELETE api/<OwnerController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOne(int id)
        {
            return Ok(await OwnerRepository.DeleteOne(id));
        }
    }
}