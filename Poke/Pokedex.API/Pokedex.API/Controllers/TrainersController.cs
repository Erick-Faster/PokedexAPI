using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pokedex.API.Domain.Models;
using Pokedex.API.Domain.Services;
using Pokedex.API.Resources;
using Pokedex.API.Extensions;
using Microsoft.AspNetCore.Authorization;
using Pokedex.API.Domain.Repositories;

namespace Pokedex.API.Controllers
{
    [Authorize]
    [Route("/api/[controller]")]
    public class TrainersController : Controller
    {
        private readonly ITrainerService _trainerService;
        private readonly IMapper _mapper;

        //Atributos para identificar o Usuario e poder interagir com eles -- opcional --
        public readonly IUser AppUser;
        protected Guid UsuarioId { get; set; }
        protected bool UsuarioAutenticado { get; set; }

        public TrainersController(ITrainerService trainerService, IMapper mapper, IUser appUser)
        {
            _trainerService = trainerService;
            _mapper = mapper;
            AppUser = appUser;

            if (AppUser.IsAuthenticated())
            {
                UsuarioId = appUser.GetUserId();
                UsuarioAutenticado = true;
            }
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IEnumerable<TrainerResource>> GetAllAsync()
        {
            var trainers = await _trainerService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Trainer>, IEnumerable<TrainerResource>>(trainers);

            return resources;
        }

        [AllowAnonymous]
        [HttpGet("{id:Guid}")]
        public async Task<ActionResult> GetById(Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());


            var result = await _trainerService.GetById(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var trainerResource = _mapper.Map<Trainer, TrainerResource>(result.Trainer);
            return Ok(trainerResource);
        }
        
        [ClaimsAuthorize("Trainer", "PostAsync")]
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveTrainerResource resource)
        {
            if (User.Identity.IsAuthenticated)
            {
                var userName = User.Identity.Name;
            }

            if (UsuarioAutenticado)
            {
                var userName = UsuarioId; //Se eu precisar das infos do usuario (como Id), posso usar essa implementacao
            }



            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var trainer = _mapper.Map<SaveTrainerResource, Trainer>(resource);
            var result = await _trainerService.SaveAsync(trainer);

            if (!result.Success)
                return BadRequest(result.Message);

            var trainerResource = _mapper.Map<Trainer, TrainerResource>(result.Trainer);
            return Ok(trainerResource);
        }

        [ClaimsAuthorize("Trainer", "PutAsync")]
        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> PutAsync(Guid id, [FromBody] SaveTrainerResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var trainer = _mapper.Map<SaveTrainerResource, Trainer>(resource);
            var result = await _trainerService.UpdateAsync(id, trainer);

            if (!result.Success)
                return BadRequest(result.Message);

            var trainerResource = _mapper.Map<Trainer, TrainerResource>(result.Trainer);
            return Ok(trainerResource);
        }

        [ClaimsAuthorize("Trainer", "DeleteAsync")]
        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var result = await _trainerService.DeleteAsync(id);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var trainerResource = _mapper.Map<Trainer, TrainerResource>(result.Trainer);
            return Ok(trainerResource);
        }

        

    }
}
