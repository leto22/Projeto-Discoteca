using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetoDiscoteca.Musicas.Web.ViewModels.Musica
{
    public class MusicaViewModel
    {
        [Required(ErrorMessage = "ID Obrigatório!")]
        public int MusicaID { get; set; }

        [Required(ErrorMessage = "Nome da Obrigatória")]
        [Display(Name = "Nome da Música")]
        [MaxLength(50, ErrorMessage = "Quantidade de Caracteres Excedidas (Máximo de 50!)")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Selecione um Álbum Válido")]
        public int IdAlbum { get; set; }
    }
}