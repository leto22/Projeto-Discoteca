using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetoDiscoteca.Musicas.Web.ViewModels.Album
{
    public class AlbumIndexViewModel
    {
        public int AlbumID { get; set; }

        [Display(Name = "Ano do Álbum")]
        public int Ano { get; set; }

        [Display(Name ="Nome do Álbum")]
        public string Nome { get; set; }

        [Display(Name = "Descrições")]
        public string Descricao { get; set; }

        [Display(Name = "Email de Contato")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}