using Pokedex.API.Domain.Models;
using Pokedex.API.Domain.Repositories;
using Pokedex.API.Domain.Services;
using Pokedex.API.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.API.Services
{
    public class PokemonService : IPokemonService
    {
        private readonly IPokemonRepository _pokemonRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PokemonService(IPokemonRepository pokemonRepository, IUnitOfWork unitOfWork)
        {
            _pokemonRepository = pokemonRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Pokemon>> ListAsync()
        {
            return await _pokemonRepository.ListAsync();
        }

        public async Task<SavePokemonResponse> GetById(Guid id)
        {
            var existingRepository = await _pokemonRepository.FindByIdAsync(id);

            if (existingRepository == null)
                return new SavePokemonResponse("Pokemon nao encontrado");

            return new SavePokemonResponse(existingRepository);
        }

        public async Task<SavePokemonResponse> SaveAsync(Pokemon pokemon)
        {
            try
            {
                await _pokemonRepository.AddAsync(pokemon);
                await _unitOfWork.CompleteAsync();

                return new SavePokemonResponse(pokemon);
            }
            catch (Exception ex)
            {
                return new SavePokemonResponse($"Nao foi possivel salvar o Pokemon: {ex.Message}");
            }
        }

        public async Task<SavePokemonResponse> UpdateAsync(Guid id, Pokemon pokemon)
        {
            var existingRepository = await _pokemonRepository.FindByIdAsync(id);

            if (existingRepository == null)
                return new SavePokemonResponse("Pokemon nao encontrado");

            existingRepository.Name_Custom = pokemon.Name_Custom;
            existingRepository.Nivel = pokemon.Nivel;
            existingRepository.Id_Trainer = pokemon.Id_Trainer;
            existingRepository.Id_Pokedex = pokemon.Id_Pokedex;

            try
            {
                _pokemonRepository.Update(existingRepository);
                await _unitOfWork.CompleteAsync();

                return new SavePokemonResponse(existingRepository);

            }
            catch (Exception ex)
            {
                return new SavePokemonResponse($"Um erro ocorreu ao atualizar o pokemon: {ex.Message}");
            }
        }

        public async Task<SavePokemonResponse> DeleteAsync(Guid id)
        {
            var existingRepository = await _pokemonRepository.FindByIdAsync(id);

            if (existingRepository == null)
            {
                return new SavePokemonResponse("Pokemon nao encontrado");
            }

            try
            {
                _pokemonRepository.Remove(existingRepository);
                await _unitOfWork.CompleteAsync();

                return new SavePokemonResponse(existingRepository);
            }
            catch(Exception ex)
            {
                return new SavePokemonResponse($"Erro ao Deletar Pokemon: {ex.Message}");
            }
        }

        
    }
}
