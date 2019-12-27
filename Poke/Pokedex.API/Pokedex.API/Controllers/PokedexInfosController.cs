using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    [Route("/api/[controller]")]
    public class PokedexInfosController : Controller
    {
        private readonly IPokedexInfoService _pokedexInfoService;
        private readonly IMapper _mapper;

        public PokedexInfosController(IPokedexInfoService pokedexInfoService, IMapper mapper)
        {
            _pokedexInfoService = pokedexInfoService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IEnumerable<PokedexInfoResource>> GetAllAsync()
        {
            var pokedexes = await _pokedexInfoService.ListAsync();
            var resources = _mapper.Map<IEnumerable<PokedexInfo>, IEnumerable<PokedexInfoResource>> (pokedexes);
            return resources;
        }

        [AllowAnonymous]
        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var result = await _pokedexInfoService.GetById(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var pokedexInfoResource = _mapper.Map<PokedexInfo, PokedexInfoResource>(result.PokedexInfo);
            return Ok(pokedexInfoResource);
        }

        [ClaimsAuthorize("PokedexInfo","PostAsync")]
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody]SavePokedexInfoResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var pokedexInfo = _mapper.Map<SavePokedexInfoResource, PokedexInfo>(resource);
            var result = await _pokedexInfoService.SaveAsync(pokedexInfo);

            if (!result.Success)
                return BadRequest(result.Message);

            var pokedexInfoResource = _mapper.Map<PokedexInfo, PokedexInfoResource>(result.PokedexInfo);
            return Ok(pokedexInfoResource); 
        }

        [ClaimsAuthorize("PokedexInfo","PutAsync")]
        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> PutAsync(Guid id, [FromBody] SavePokedexInfoResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var pokedexInfo = _mapper.Map<SavePokedexInfoResource, PokedexInfo>(resource);
            var result = await _pokedexInfoService.UpdateAsync(id, pokedexInfo);

            if (!result.Success)
                return BadRequest(result.Message);

            var pokedexInfoResource = _mapper.Map<PokedexInfo, PokedexInfoResource>(result.PokedexInfo);
            return Ok(pokedexInfoResource);
        }

        [ClaimsAuthorize("PokedexInfo","DeleteAsync")]
        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var result = await _pokedexInfoService.DeleteAsync(id);


            if (!result.Success)
                return BadRequest(result.Message);

            var pokedexInfoResource = _mapper.Map<PokedexInfo, PokedexInfoResource>(result.PokedexInfo);
            return Ok(pokedexInfoResource);
            
        }
            

    }
}
