using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Model.Models
{
   public  class Jogo
    {
        public int Id { get; set; }
        public string NomeJogo { get; set; }
        public string ProdutoraJogo { get; set; }
        public string Descricao { get; set; }
        public string FotoUriJogo { get; set; }

        public int JogadorId { get; set; }
        public Jogador Jogador { get; set; }
    }
}
