using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetoDiscoteca.Musicas.Web.ViewModels.Usuario
{
    public class UsuarioViewModel
    {
        [Required(ErrorMessage = "Email Obrigatório!")]
        [MaxLength(80, ErrorMessage = "Máximo de 80 caracteres...")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Senha Obrigatória!")]
        [MaxLength(20, ErrorMessage = "Máximo de 20 caracteres...")]
        [MinLength(6, ErrorMessage = "Minímo de 6 carcteres")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
    }
}