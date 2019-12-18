using Pokedex.API.Domain.Models;
using Pokedex.API.Domain.Repositories;
using Pokedex.API.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.API.Services
{
    public class EnderecoService : IEnderecoService
    {
        private readonly IEnderecoRepository _enderecoRepository;
        private readonly IUnitOfWork _unitOfWork;

        public EnderecoService(IEnderecoRepository enderecoRepository, IUnitOfWork unitOfWork)
        {
            _enderecoRepository = enderecoRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Endereco>> ListAsync()
        {
            return await _enderecoRepository.ListAsync();
        }

        public async Task<SaveEnderecoResponse> SaveAsync(Endereco endereco)
        {
            try
            {
                await _enderecoRepository.AddAsync(endereco);
                await _unitOfWork.CompleteAsync();

                return new SaveEnderecoResponse(endereco);
            }
            catch(Exception ex)
            {
                return new SaveEnderecoResponse($"Erro ao salvar o endereco: {ex.Message}");
            }
        }

        public async Task<SaveEnderecoResponse> UpdateASync(int id, Endereco endereco)
        {
            var existingRepository = await _enderecoRepository.FindByIdAsync(id);

            if (existingRepository == null)
                return new SaveEnderecoResponse("Endereco nao encontrado");

            existingRepository.Bairro = endereco.Bairro;
            existingRepository.Estado = endereco.Estado;
            existingRepository.Pais = endereco.Pais;
            existingRepository.Id_Trainer = endereco.Id_Trainer;

            try
            {
                _enderecoRepository.Update(existingRepository);
                await _unitOfWork.CompleteAsync();

                return new SaveEnderecoResponse(existingRepository);
                
            }
            catch(Exception ex)
            {
                return new SaveEnderecoResponse($"Erro ao atualizar o endereco: {ex.Message}");
            }

        }
        public async Task<SaveEnderecoResponse> DeleteAsync(int id)
        {
            var existingRepository = await _enderecoRepository.FindByIdAsync(id);

            if (existingRepository == null)
                return new SaveEnderecoResponse("Nao foi possivel encontrar o endereco");

            try
            {
                _enderecoRepository.Delete(existingRepository);
                await _unitOfWork.CompleteAsync();

                return new SaveEnderecoResponse(existingRepository);
            }
            catch(Exception ex)
            {
                return new SaveEnderecoResponse($"Erro ao deletar o endereco: {ex.Message}");
            }


        }
    }
}
