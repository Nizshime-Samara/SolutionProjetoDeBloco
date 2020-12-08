using Aplication.ViewModels;
using AutoMapper;
using Domain.Model.Interfaces.Services;
using Domain.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.AppServices.Implementations
{
    public class JogoApp : IJogoAppService
    {
        private readonly IMapper _mapper;
        private readonly IJogoService _jogoService;

        public JogoApp(IMapper mapper, IJogoService jogoService)
        {
            _mapper = mapper;
            _jogoService = jogoService;
        }

        public async Task<int> AddAsync(JogoVM jogovm)
        {
            var jogo = _mapper.Map<Jogo>(jogovm); // coverter antes//
            var id = await _jogoService.AddAsync(jogo);
            return id;
        }

        public async Task EditAsync(JogoVM jogovm)
        {
            var jogo = _mapper.Map<Jogo>(jogovm);
            await _jogoService.EditAsync(jogo);
        }

        public async Task<IEnumerable<JogoVM>> GetAllAsync(string search)
        {
            var jogo = await _jogoService.GetAllAsync(search);

            return _mapper.Map<IEnumerable<JogoVM>>(jogo);
        }

        public async Task<JogoVM> GetByIdAsync(int id)
        {
            var jogo = await _jogoService.GetByIdAsync(id);

            return _mapper.Map<JogoVM>(jogo);
        }

        public async Task RemoveAsync(JogoVM jogovm)
        {
            var jogo = _mapper.Map<Jogo>(jogovm);
            await _jogoService.RemoveAsync(jogo);
        }
    }
}
