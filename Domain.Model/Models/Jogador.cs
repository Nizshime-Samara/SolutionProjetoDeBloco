using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Model.Models
{
    public class Jogador
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string FotoUri { get; set; }

        public List<Jogo> Jogos { get; set; }

        // public DateTime? UltimaVisualizacao { get; set; } 
    }
}
