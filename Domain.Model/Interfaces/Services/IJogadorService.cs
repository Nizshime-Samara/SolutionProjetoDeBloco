using Domain.Model.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Interfaces.Services
{
    public interface IJogadorService 
    {
        Task<IEnumerable<Jogador>> GetAllAsync(string search);
        Task<Jogador> GetByIdAsync(int id);
        Task<int> AddAsync(Jogador jogador);

       

        Task EditAsync(Jogador jogador);
        Task RemoveAsync(Jogador jogador);
     //   Task InsertAsync(Jogador jogador, Stream stream);
       
    }
}
