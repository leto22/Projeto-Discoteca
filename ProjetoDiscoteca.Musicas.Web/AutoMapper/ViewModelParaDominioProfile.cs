using AutoMapper;
using ProjetoDiscoteca.Musicas.Dominio;
using ProjetoDiscoteca.Musicas.Web.ViewModels.Album;
using ProjetoDiscoteca.Musicas.Web.ViewModels.Musica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static ProjetoDiscoteca.Musicas.Dominio.Musica;

namespace ProjetoDiscoteca.Musicas.Web.AutoMapper
{
    public class ViewModelParaDominioProfile : Profile
    {
        protected override void Configure()
        {
            //Mapeamento por AutoMapper - DesignPattern(ViewModel), Views para Domínio
            Mapper.CreateMap<AlbumViewModel, Album>();
            Mapper.CreateMap<MusicaViewModel, Musica>();
        }
    }
}