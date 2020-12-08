using Aplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.AppServices
{
   public interface IJogoAppService
    {
        Task<IEnumerable<JogoVM>> GetAllAsync(string search);
        Task<JogoVM> GetByIdAsync(int id);
        Task<int> AddAsync(JogoVM jogovm);
        Task EditAsync(JogoVM jogovm);
        Task RemoveAsync(JogoVM jogovm);
    }
}
