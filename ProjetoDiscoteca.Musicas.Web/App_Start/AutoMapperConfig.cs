﻿using AutoMapper;
using ProjetoDiscoteca.Musicas.Web.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoDiscoteca.Musicas.Web.App_Start
{
    public static class AutoMapperConfig
    {
        public static void Configurar()
        {
            //Criação de um Perfil de Mapeamento para Domínio e View
            Mapper.AddProfile<DominioParaViewModelProfile>();
            Mapper.AddProfile<ViewModelParaDominioProfile>();
        }
    }
}