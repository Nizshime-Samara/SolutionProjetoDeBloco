using Domain.Model.Interfaces.Repositories;
using Domain.Model.Interfaces.Services;
using Domain.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service.Services
{
    public class JogoService : IJogoService
    {
        private readonly IJogoRepository _jogoRepository;

        public JogoService(IJogoRepository jogoRepository)
        {
            _jogoRepository = jogoRepository;
        }

        public async Task<int> AddAsync(Jogo jogo)
        {
            return await _jogoRepository.AddAsync(jogo);
        }

        public async Task EditAsync(Jogo jogo)
        {
            await _jogoRepository.EditAsync(jogo);
        }

        public async Task<IEnumerable<Jogo>> GetAllAsync(string search)
        {
            return await _jogoRepository.GetAllAsync(search);
        }

        public async Task<Jogo> GetByIdAsync(int id)
        {
            return await _jogoRepository.GetByIdAsync(id);
        }

        public async Task RemoveAsync(Jogo jogo)
        {
            await _jogoRepository.RemoveAsync(jogo);
        }
    }
}
