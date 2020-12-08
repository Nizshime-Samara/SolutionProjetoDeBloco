using Domain.Model.Interfaces.Repositories;
using Domain.Model.Interfaces.Services;
using Domain.Model.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service.Services
{
    public class JogadorService : IJogadorService   // a regra de negocio vem aqui///
    {
        private readonly IJogadorRepository _jogadorRepository;
       // private readonly IBlobService _blobService;

        public JogadorService(IJogadorRepository jogadorRepository)
        {
           _jogadorRepository = jogadorRepository;
          //  _blobService = blobService;
        }

        public async Task<int> AddAsync(Jogador jogador)
        {
            return await _jogadorRepository.AddAsync(jogador);
        }

        public async Task EditAsync(Jogador jogador)
        {
            await _jogadorRepository.EditAsync(jogador);
        }

        public async Task<IEnumerable<Jogador>> GetAllAsync(string search)
        {
            return await _jogadorRepository.GetAllAsync(search);
        }

        public async Task<Jogador> GetByIdAsync(int id)
        {
            return await _jogadorRepository.GetByIdAsync(id);
        }

       // public async Task InsertAsync(Jogador jogador, Stream stream)
      //  {
       //     var newUri = await _blobService.UploadAsync(stream);
       //     jogador.FotoUri = newUri;

     //       await _jogadorRepository.InsertAsync(jogador);
      //  }

        public async Task RemoveAsync(Jogador jogador)
        {
            await _jogadorRepository.RemoveAsync(jogador);
        }
    }
}
