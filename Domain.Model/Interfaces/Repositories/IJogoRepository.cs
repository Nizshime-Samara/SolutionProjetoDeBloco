﻿using Domain.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Interfaces.Repositories
{
  public  interface IJogoRepository
    {
        Task<IEnumerable<Jogo>> GetAllAsync(string search);
        Task<Jogo> GetByIdAsync(int id);
        Task<int> AddAsync(Jogo jogo);
        Task EditAsync(Jogo jogo);
        Task RemoveAsync(Jogo jogo);
    }
}
