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
    public class TrainerService : ITrainerService
    {

        private readonly ITrainerRepository _trainerRepository;
        private readonly IUnitOfWork _unitOfWork;

        public TrainerService(ITrainerRepository trainerRepository, IUnitOfWork unitOfWork)
        {
            _trainerRepository = trainerRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Trainer>> ListAsync()
        {
            return await _trainerRepository.ListAsync();
        }

        public async Task<SaveTrainerResponse> GetById(Guid id)
        {
            var existingTrainer = await _trainerRepository.FindByIdAsync(id);

            if (existingTrainer == null)
                return new SaveTrainerResponse("Treinador nao encontrado");

            return new SaveTrainerResponse(existingTrainer);
        }

        public async Task<SaveTrainerResponse> SaveAsync(Trainer trainer)
        {
            try
            {
                await _trainerRepository.AddAsync(trainer);
                await _unitOfWork.CompleteAsync();

                return new SaveTrainerResponse(trainer);
            }
            catch (Exception ex)
            {
                return new SaveTrainerResponse($"Erro ao salvar: {ex.Message}");
            }
        }

        public async Task<SaveTrainerResponse> UpdateAsync(Guid id, Trainer trainer)
        {
            var existingTrainer = await _trainerRepository.FindByIdAsync(id);

            if(existingTrainer == null)
            {
                return new SaveTrainerResponse("Treinador nao encontrado");
                
            }
            existingTrainer.Nome = trainer.Nome;
            existingTrainer.Email = trainer.Email;
            existingTrainer.Liga = trainer.Liga;

            try
            {
                _trainerRepository.Update(existingTrainer);
                await _unitOfWork.CompleteAsync();

                return new SaveTrainerResponse(existingTrainer);
            }
            catch(Exception ex)
            {
                return new SaveTrainerResponse($"Erro ao atualizar treinador: {ex.Message}");
            }
        }

        public async Task<SaveTrainerResponse> DeleteAsync(Guid id)
        {
            var existingTrainer = await _trainerRepository.FindByIdAsync(id);

            if (existingTrainer == null)
                return new SaveTrainerResponse("Treinador nao encontrado");

            try
            {
                _trainerRepository.Remove(existingTrainer);
                await _unitOfWork.CompleteAsync();

                return new SaveTrainerResponse(existingTrainer);
            }
            catch (Exception ex)
            {
                return new SaveTrainerResponse($"Erro ao deletar o arquivo: {ex.Message}");
            }
        }

        
    }
}
