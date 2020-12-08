using Aplication.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.AppServices
{
   public interface IJogadorAppService
    {
        Task<IEnumerable<JogadorVM>> GetAllAsync(string search);
        Task<JogadorVM> GetByIdAsync(int id);
        Task<int> AddAsync(JogadorVM jogadorvm);
        Task EditAsync(JogadorVM jogadorvm);

     //   Task InsertAsync(JogadorVM jogadorVM, Stream stream);

        Task RemoveAsync(JogadorVM jogadorvm);
    }
}
