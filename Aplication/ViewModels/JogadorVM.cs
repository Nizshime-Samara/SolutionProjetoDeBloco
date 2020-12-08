using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;// esse pacote é do mvc porém é necessário para o Remote//
using System.Text;

namespace Aplication.ViewModels
{
   public class JogadorVM
    {
        public int Id { get; set; }

        [Required] // campo obrigatorio para nome //

        public string Nome { get; set; }
      
        [DataType(DataType.Date)] // aqio configuro o front end para setar apenas a data sem o Horario no combobox//
        public DateTime DataNascimento { get; set; }
        public string FotoUri { get; set; }

        public List<JogoVM> Jogos { get; set; }

        // public DateTime? UltimaVisualizacao { get; set; } 
    }
}
