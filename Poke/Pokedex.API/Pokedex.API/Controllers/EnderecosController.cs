using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pokedex.API.Domain.Models;
using Pokedex.API.Domain.Repositories;
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
    public class EnderecosController : Controller
    {
        private readonly IEnderecoService _enderecoService;
        private readonly IMapper _mapper;

        public EnderecosController(IEnderecoService enderecoService, IMapper mapper)
        {
            _enderecoService = enderecoService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IEnumerable<EnderecoResource>> ListAsync()
        {
            var enderecos = await _enderecoService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Endereco>, IEnumerable<EnderecoResource>>(enderecos);
            return resources;
        }

        [AllowAnonymous]
        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var result = await _enderecoService.GetById(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var enderecoResource = _mapper.Map<Endereco, EnderecoResource>(result.Endereco);
            return Ok(enderecoResource);
        }

        [ClaimsAuthorize("Endereco","PostAsync")]
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveEnderecoResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var endereco = _mapper.Map<SaveEnderecoResource, Endereco>(resource);
            var result = await _enderecoService.SaveAsync(endereco);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var enderecoResource = _mapper.Map<Endereco, EnderecoResource>(result.Endereco);
            return Ok(enderecoResource);
        }

        [ClaimsAuthorize("Endereco","PutAsync")]
        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> PutASync(Guid id, [FromBody] SaveEnderecoResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var endereco = _mapper.Map<SaveEnderecoResource, Endereco>(resource);
            var result = await _enderecoService.UpdateASync(id, endereco);

            if(!result.Success)
                return BadRequest(result.Message);

            var enderecoResource = _mapper.Map<Endereco, EnderecoResource>(result.Endereco);
            return Ok(enderecoResource);
        }

        [ClaimsAuthorize("Endereco","DeleteAsync")]
        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var result = await _enderecoService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var enderecoResource = _mapper.Map<Endereco, EnderecoResource>(result.Endereco);
            return Ok(enderecoResource);
        }
    }

}
