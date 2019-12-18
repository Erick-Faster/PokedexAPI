using AutoMapper;
using Pokedex.API.Domain.Models;
using Pokedex.API.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.API.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveTrainerResource, Trainer>();
            CreateMap<SaveEnderecoResource, Endereco>();
            CreateMap<SavePokedexInfoResource, PokedexInfo>();
            CreateMap<SavePokemonResource, Pokemon>();
        }
    }
}
