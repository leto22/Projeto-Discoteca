using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using ProjetoDiscoteca.Musicas.AcessoDados.Entity.Context;
using ProjetoDiscoteca.Musicas.Dominio;
using ProjetoDiscoteca.Musicas.Web.ViewModels.Album;
using ProjetoDiscoteca.Repositorio.Comum;
using ProjetoDiscoteca.Musicas.Repositorios.Entity;

namespace ProjetoDiscoteca.Musicas.Web.Controllers
{
    [Authorize]
    public class AlbumController : Controller
    {
        private IRepositorioGenerico<Album, int> repositorioAlbuns = new AlbumRepositorio(new MusicasDbContext());

        // GET: Album
        public ActionResult Index()
        {
            //Realização de um Mapa do Domínio-Álbum, para uma ViewModel- Álbum Exibição
            return View(Mapper.Map<List<Album>, List<AlbumExibicaoViewModel>>(repositorioAlbuns.Selecionar()));
        }

        public ActionResult FiltroNome(string pesquisa)
        {
            List<Album> albuns = repositorioAlbuns.Selecionar().Where(a => a.Nome.Contains(pesquisa)).ToList();
            List<AlbumExibicaoViewModel> albViewModel = Mapper.Map<List<Album>, List<AlbumExibicaoViewModel>>(albuns);
            return Json(albViewModel, JsonRequestBehavior.AllowGet);
        }

        // GET: Album/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = repositorioAlbuns.SelecionarPorID(id.Value);
            if (album == null)
            {
                return HttpNotFound();
            }

            //Mapa para realizar a converção do Domínio-Álbum para ViewModel-Álbum Exibição
            return View(Mapper.Map<Album, AlbumExibicaoViewModel>(album));
        }

        // GET: Album/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Album/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AlbumID,Ano,Nome,Descricao,Email")] AlbumViewModel albViewModel)
        {
            if (ModelState.IsValid)
            {
                //Mapa para realizar a converção do ViewModel-Álbum Exibição para Domínio-Álbum 
                Album album = Mapper.Map<AlbumViewModel, Album>(albViewModel);
                repositorioAlbuns.InserirDados(album);
                return RedirectToAction("Index");
            }

            return View(albViewModel);
        }

        // GET: Album/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = repositorioAlbuns.SelecionarPorID(id.Value);
            if (album == null)
            {
                return HttpNotFound();
            }

            //Mapa para realizar a converção do Domínio-Álbum para ViewModel-Álbum Exibição
            return View(Mapper.Map<Album, AlbumViewModel>(album));
        }

        // POST: Album/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AlbumID,Ano,Nome,Descricao,Email")] AlbumViewModel albViewModel)
        {
            if (ModelState.IsValid)
            {
                //Mapa para realizar a converção do ViewModel-Álbum Exibição para Domínio-Álbum 
                Album album = Mapper.Map<AlbumViewModel, Album>(albViewModel);
                repositorioAlbuns.AlterarDados(album);
                return RedirectToAction("Index");
            }
            return View(albViewModel);
        }

        // GET: Album/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = repositorioAlbuns.SelecionarPorID(id.Value);
            if (album == null)
            {
                return HttpNotFound();
            }

            //Mapa para realizar a converção do Domínio-Álbum para ViewModel-Álbum Exibição
            return View(Mapper.Map<Album, AlbumExibicaoViewModel>(album));
        }

        // POST: Album/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            repositorioAlbuns.ExcluirDadosPorId(id);
            return RedirectToAction("Index");
        }
    }
}
