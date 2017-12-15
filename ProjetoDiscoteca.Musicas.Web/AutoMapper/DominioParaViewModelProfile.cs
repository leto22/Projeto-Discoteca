using AutoMapper;
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
            //Mapeamento por AutoMapper - DesignPattern(ViewModel), Domínio para Views
            Mapper.CreateMap<Album, AlbumExibicaoViewModel>()

                //Personalização de Mapeamento
                .ForMember(p => p.Nome, opt =>
                {
                    //Altera o valor gerado na propriedade "Nome" - opt.MapFrom
                    //"scr" - é um Álbum de origem, e como apartir do Álbum, será abastecido a propriedade "Nome"
                    //{0} - parametro = nome, "({1})" - parametro = ano, de maneira que à junção de ambos saia "Nome(Ano)"
                    opt.MapFrom(src => string.Format("{0} ({1})", src.Nome, src.Ano.ToString()));
                });

            Mapper.CreateMap<Album, AlbumViewModel>();
        }
    }
}