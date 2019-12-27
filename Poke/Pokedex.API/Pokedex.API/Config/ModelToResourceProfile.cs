using AutoMapper;
using Pokedex.API.Domain.Models;
using Pokedex.API.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.API.Config
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Trainer, TrainerResource>();
            CreateMap<Endereco, EnderecoResource>();
            CreateMap<PokedexInfo, PokedexInfoResource>();
            CreateMap<Pokemon, PokemonResource>();
        }
    }
}
