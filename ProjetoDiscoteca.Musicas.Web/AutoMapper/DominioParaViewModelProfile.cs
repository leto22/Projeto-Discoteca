﻿using AutoMapper;
using ProjetoDiscoteca.Musicas.Dominio;
using ProjetoDiscoteca.Musicas.Web.ViewModels.Album;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoDiscoteca.Musicas.Web.AutoMapper
{
    public class DominioParaViewModelProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Album, AlbumIndexViewModel>();
        }
    }
}