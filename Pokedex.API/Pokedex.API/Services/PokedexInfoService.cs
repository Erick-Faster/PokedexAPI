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
    public class PokedexInfoService : IPokedexInfoService
    {
        private readonly IPokedexInfoRepository _pokedexInfoRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PokedexInfoService(IPokedexInfoRepository pokedexInfoRepository, IUnitOfWork unitOfWork)
        {
            _pokedexInfoRepository = pokedexInfoRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<PokedexInfo>> ListAsync()
        {
            return await _pokedexInfoRepository.ListAsync();
        }

        public async Task<SavePokedexInfoResponse> SaveAsync(PokedexInfo pokedexInfo)
        {
            try
            {
                await _pokedexInfoRepository.AddAsync(pokedexInfo);
                await _unitOfWork.CompleteAsync();

                return new SavePokedexInfoResponse(pokedexInfo);
            }
            catch(Exception ex)
            {
                return new SavePokedexInfoResponse($"Erro ao salvar pokedex: {ex.Message}");
            }
        }

        public async Task<SavePokedexInfoResponse> UpdateAsync(int id, PokedexInfo pokedexInfo)
        {
            var existingRepository = await _pokedexInfoRepository.FindByIdAsync(id);

            if (existingRepository == null)
                return new SavePokedexInfoResponse("Informacao nao encontrada");

            existingRepository.Numero = pokedexInfo.Numero;
            existingRepository.Name = pokedexInfo.Name;
            existingRepository.Type_1 = pokedexInfo.Type_1;
            existingRepository.Type_2 = pokedexInfo.Type_2;
            existingRepository.Total = pokedexInfo.Total;
            existingRepository.HP = pokedexInfo.HP;
            existingRepository.Attack = pokedexInfo.Attack;
            existingRepository.Defense = pokedexInfo.Defense;
            existingRepository.SP_Atk = pokedexInfo.SP_Atk;
            existingRepository.SP_Def = pokedexInfo.SP_Def;
            existingRepository.Speed = pokedexInfo.Speed;
            existingRepository.Generation = pokedexInfo.Generation;
            existingRepository.Legendary = pokedexInfo.Legendary;

            try
            {
                _pokedexInfoRepository.Update(existingRepository);
                await _unitOfWork.CompleteAsync();

                return new SavePokedexInfoResponse(existingRepository);
            }
            catch(Exception ex)
            {
                return new SavePokedexInfoResponse($"Erro ao Atualizar: {ex.Message}");
            }

        }

        public async Task<SavePokedexInfoResponse> DeleteAsync(int id)
        {
            var existingRepository = await _pokedexInfoRepository.FindByIdAsync(id);

            if (existingRepository == null)
                return new SavePokedexInfoResponse("Informacao nao encontrada");

            try
            {
                _pokedexInfoRepository.Remove(existingRepository);
                await _unitOfWork.CompleteAsync();

                return new SavePokedexInfoResponse(existingRepository);
            }
            catch(Exception ex)
            {
                return new SavePokedexInfoResponse($"Erro ao Deletar: {ex.Message}");
            }

        }
    }
}
