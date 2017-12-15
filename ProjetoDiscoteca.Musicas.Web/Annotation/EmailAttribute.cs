using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetoDiscoteca.Musicas.Web.Annotation
{
    public class EmailAttribute : ValidationAttribute
    {
        //Sobre escrita do metóde de validação
        public override bool IsValid(object value)
        {
            //Annotation personalizada para verificação de um e-mail com terminos (...)
            return value.ToString().EndsWith("@hotmail.com");
        }
    }
}