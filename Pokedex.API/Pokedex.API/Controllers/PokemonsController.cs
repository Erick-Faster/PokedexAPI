using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pokedex.API.Domain.Models;
using Pokedex.API.Domain.Services;
using Pokedex.API.Extensions;
using Pokedex.API.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.API.Controllers
{

    [Route("/api/[controller]")]
    public class PokemonsController : Controller
    {
        private readonly IPokemonService _pokemonService;
        private readonly IMapper _mapper;

        public PokemonsController(IPokemonService pokemonService, IMapper mapper)
        {
            _pokemonService = pokemonService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<PokemonResource>> ListAsync()
        {
            var pokemons = await _pokemonService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Pokemon>, IEnumerable<PokemonResource>> (pokemons);
            return resources;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody]SavePokemonResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var pokemon = _mapper.Map<SavePokemonResource, Pokemon>(resource);
            var result = await _pokemonService.SaveAsync(pokemon);

            if (!result.Success)
                return BadRequest(result.Message);

            var pokemonResource = _mapper.Map<Pokemon, PokemonResource>(result.Pokemon);
            return Ok(pokemonResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody]SavePokemonResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var pokemon = _mapper.Map<SavePokemonResource, Pokemon>(resource);
            var result = await _pokemonService.UpdateAsync(id, pokemon);

            if (!result.Success)
                return BadRequest(result.Message);

            var pokemonResource = _mapper.Map<Pokemon, PokemonResource>(result.Pokemon);
            return Ok(pokemonResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _pokemonService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var pokemonResource = _mapper.Map<Pokemon, PokemonResource>(result.Pokemon);
            return Ok(pokemonResource);
        }

    }
}
