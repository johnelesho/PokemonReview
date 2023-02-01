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
    public class PokemonController : Controller
    {
        private readonly IAppRepository<Pokemon> pokemonRepository;

        public PokemonController(IAppRepository<Pokemon> pokemonRepository)
        {
            this.pokemonRepository = pokemonRepository;
        }
        // GET: api/<PokemonController>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable < Pokemon >))]
        public async Task<IEnumerable<PokemonResponse>> GetAsync()
        {
            return (IEnumerable<PokemonResponse>)await pokemonRepository.GetAll();
        }

        // GET api/<PokemonController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Pokemon))]
        public async Task<PokemonResponse> GetAsync(int id)
        {
            return await pokemonRepository.GetOne(id);
        }

        // POST api/<PokemonController>
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(PokemonResponse))]
        public async Task<PokemonResponse> PostAsync([FromBody] PokemonRequest requestBody)
        {
            return await pokemonRepository.AddOne(requestBody);

        }

        // PUT api/<PokemonController>/5
        [HttpPut("{id:int}")]
        [ProducesResponseType(200)]
        public async Task<IActionResult>  Put(int id, [FromBody] PokemonRequest requestBody)
        {
            return Ok(await pokemonRepository.PutOne(id,requestBody));
        }

        // DELETE api/<PokemonController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await pokemonRepository.DeleteOne(id));
        }
    }
}