using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetoDiscoteca.Musicas.Web.ViewModels.Album
{
    public class AlbumViewModel
    {
        [Required(ErrorMessage = "ID Obrigatório!")]
        public int AlbumID { get; set; }

        [Display(Name = "Ano do Álbum")]
        [Required(ErrorMessage = "Ano do Álbum Obrigatório!")]
        public int Ano { get; set; }

        [Display(Name = "Nome do Álbum")]
        [Required(ErrorMessage = "Nome Obrigatório!")]
        [MaxLength(100, ErrorMessage = "Máximo de 100 Caracteres!")]
        public string Nome { get; set; }

        [Display(Name = "Descrições")]
        [Required(ErrorMessage = "Nome Obrigatório!")]
        [MaxLength(100, ErrorMessage = "Quantidade de Caracteres Excedidas (Máximo de 1000!)")]
        public string Descricao { get; set; }

        [Display(Name = "Email de Contato")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "E-mail Obrigatório!")]
        [MaxLength(80, ErrorMessage = "Quantidade de Caracteres Excedidas (Máximo de 1000!)")]
        public string Email { get; set; }
    }
}