using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.ViewModels
{ // jogo precisa ter uma FK para autor, para dizer de qual jogador é aquele jogo //
     public class JogoVM
    {
        public int Id { get; set; }
        public string NomeJogo { get; set; }
        public string ProdutoraJogo { get; set; }
        public string Descricao { get; set; }
        
        public string FotoUriJogo { get; set; }

        public int JogadorId { get; set; }
        public JogadorVM Jogador { get; set; }

    }
}
