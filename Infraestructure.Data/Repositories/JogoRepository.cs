using Domain.Model.Interfaces.Repositories;
using Domain.Model.Models;
using Infraestructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Data.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        private readonly JogoContext _jogoContext;

        public JogoRepository(JogoContext jogoContext)
        {
            _jogoContext = jogoContext;
        }

        public async Task<int> AddAsync(Jogo jogo)
        {
            var entityEntry = await _jogoContext.Jogos.AddAsync(jogo);
            await _jogoContext.SaveChangesAsync();
            return entityEntry.Entity.Id;
        }

        public async Task EditAsync(Jogo jogo)
        {
            _jogoContext.Jogos.Update(jogo);
            await _jogoContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Jogo>> GetAllAsync(string search) // reclama (cs1998), normal, de novo (não pira, Samara!)
        {
          
            if (string.IsNullOrWhiteSpace(search))
            {
                return _jogoContext.Jogos.Include(x => x.Jogador); // lista os josgadors//
            }

            return _jogoContext.Jogos.Include(x => x.Jogador).Where(c => c.NomeJogo.Contains(search)); 
        }

        public async Task<Jogo> GetByIdAsync(int id)
        {
            
            return await _jogoContext.Jogos
                .Include(x => x.Jogador) //é um join com a tabela do jogadores//
                .FirstOrDefaultAsync(c => c.Id == id);
            
        }

        public async Task RemoveAsync(Jogo jogo)
        {
            var jogoRemoveID = await GetByIdAsync(jogo.Id); // não a propriedade e sim o parametro /// 
            _jogoContext.Jogos.Remove(jogoRemoveID);
            await _jogoContext.SaveChangesAsync();

           
        }
    }
}
