using Domain.Model.Interfaces.Repositories;
using Domain.Model.Models;
using Infraestructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//nota quando der ruim  (achei que havia quebradro a aplicação anterior com o Gnerics , por não passar as informações gravadas no bd da apk anterior, procurar pelo erro no Repo onde está o contexto da aplicação neste caso atual aqui)

namespace Infraestructure.Data.Repositories
{
    public class JogadorRepository : IJogadorRepository // A dependencia externa do Repository é o contextDB da Aplicação//
    {
        private readonly JogoContext _jogoContext;

        public JogadorRepository(JogoContext jogoCotext)
        {
            _jogoContext = jogoCotext;
        }

        public async Task<int> AddAsync(Jogador jogador) // metodo de escrita no banco//
        {
            var entityEntry = await _jogoContext.Jogadores.AddAsync(jogador);

            await _jogoContext.SaveChangesAsync(); 

            return entityEntry.Entity.Id;
        }

        public async Task EditAsync(Jogador jogador)
        {
            _jogoContext.Jogadores.Update(jogador);

            await _jogoContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Jogador>> GetAllAsync(string search) // vai reclamar a falta do await (normal, não pira)//
        {
            if (string.IsNullOrWhiteSpace(search))
            {
                return _jogoContext.Jogadores;
            }

            return _jogoContext.Jogadores.Where(x => x.Nome.Contains(search)); // caso chamar o metodo toList, irá retornrnar a lista inteira de jogadores//
        }

        public async Task<Jogador> GetByIdAsync(int id)
        {
            return await _jogoContext.Jogadores.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task RemoveAsync(Jogador jogador)
        {
            var JogadorRemoveId = await GetByIdAsync(jogador.Id);
            _jogoContext.Jogadores.Remove(JogadorRemoveId);

            await _jogoContext.SaveChangesAsync();
        }

    //    public async Task InsertAsync(Jogador jogador)
   //     {
    //        _jogoContext.Add(jogador);
   //         await _jogoContext.SaveChangesAsync();
    //    }
    }
}
