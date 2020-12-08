using Aplication.ViewModels;
using AutoMapper;
using Domain.Model.Interfaces.Services;
using Domain.Model.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.AppServices.Implementations
{
    public class JogadorApp : IJogadorAppService
    {
        private readonly IJogadorService _jogadorService;
       // private readonly IBlobService _blobService;
        private readonly IMapper _mapper;

        public JogadorApp(IJogadorService jogadorService, IMapper mapper)
        {
            _mapper = mapper;
           _jogadorService = jogadorService;
          //  _blobService = blobService;
        }

        public async Task<int> AddAsync(JogadorVM jogadorvm)
        {
           var jogador = _mapper.Map<Jogador>(jogadorvm);
           var id = await _jogadorService.AddAsync(jogador);
            return id;
        }

        public async Task EditAsync(JogadorVM jogadorvm)
        {
            var jogador = _mapper.Map<Jogador>(jogadorvm);
            await _jogadorService.EditAsync(jogador);
        }

        public async Task<IEnumerable<JogadorVM>> GetAllAsync(string search)
        {

            var jogador = await _jogadorService.GetAllAsync(search);

            return _mapper.Map<IEnumerable<JogadorVM>>(jogador);
        }

        public async Task<JogadorVM> GetByIdAsync(int id)
        {
            var jogador = await _jogadorService.GetByIdAsync(id);

            return _mapper.Map<JogadorVM>(jogador);
        }

    //    public Task InsertAsync(JogadorVM jogadorVM, Stream stream)
     //   {
    //        throw new NotImplementedException();
      //  }

        public async Task RemoveAsync(JogadorVM jogadorvm)
        {
            var jogador = _mapper.Map<Jogador>(jogadorvm);
            await _jogadorService.RemoveAsync(jogador);
        }

        

    }
}
