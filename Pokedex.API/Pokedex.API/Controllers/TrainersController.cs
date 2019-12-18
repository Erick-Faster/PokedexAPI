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

namespace Pokedex.API.Controllers
{
    [Route("/api/[controller]")]
    public class TrainersController : Controller
    {
        private readonly ITrainerService _trainerService;
        private readonly IMapper _mapper;

        public TrainersController(ITrainerService trainerService, IMapper mapper)
        {
            _trainerService = trainerService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<TrainerResource>> GetAllAsync()
        {
            var trainers = await _trainerService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Trainer>, IEnumerable<TrainerResource>>(trainers);

            return resources;
        }
        
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveTrainerResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var trainer = _mapper.Map<SaveTrainerResource, Trainer>(resource);
            var result = await _trainerService.SaveAsync(trainer);

            if (!result.Success)
                return BadRequest(result.Message);

            var trainerResource = _mapper.Map<Trainer, TrainerResource>(result.Trainer);
            return Ok(trainerResource);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveTrainerResource resource)
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
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
