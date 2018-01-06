using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjetoDiscoteca.Musicas.AcessoDados.Entity.Context;
using ProjetoDiscoteca.Musicas.Dominio;
using ProjetoDiscoteca.Repositorio.Comum;
using ProjetoDiscoteca.Musicas.Repositorios.Entity;
using AutoMapper;
using ProjetoDiscoteca.Musicas.Web.ViewModels.Musica;
using ProjetoDiscoteca.Musicas.Web.ViewModels.Album;

namespace ProjetoDiscoteca.Musicas.Web.Controllers
{
    [Authorize]
    public class MusicaController : Controller
    {
        private IRepositorioGenerico<Musica, long> repositorioMusicas = new MusicaRepositorio(new MusicasDbContext());
        private IRepositorioGenerico<Album, int> repositorioAlbuns = new AlbumRepositorio(new MusicasDbContext());

        // GET: Musica
        public ActionResult Index()
        {
            //var musicas = db.Musicas.Include(m => m.Album);
            return View(Mapper.Map<List<Musica>, List<MusicaExibicaoViewModel>>(repositorioMusicas.Selecionar()));
        }

        // GET: Musica/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Musica musica = repositorioMusicas.SelecionarPorID(id.Value);
            if (musica == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<Musica, MusicaExibicaoViewModel>(musica));
        }

        // GET: Musica/Create
        public ActionResult Create()
        {
            List<AlbumExibicaoViewModel> albuns = Mapper.Map<List<Album>, List<AlbumExibicaoViewModel>>(repositorioAlbuns.Selecionar());
            SelectList dropDownAlbuns = new SelectList(albuns, "AlbumID", "Nome");
            ViewBag.DropDownAlbuns = dropDownAlbuns;
            return View();
        }

        // POST: Musica/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MusicaID,Nome,IdAlbum")] MusicaViewModel mscViewModel)
        {
            if (ModelState.IsValid)
            {
                Musica musica = Mapper.Map<MusicaViewModel, Musica>(mscViewModel);
                repositorioMusicas.InserirDados(musica);
                return RedirectToAction("Index");
            }

            //ViewBag.IdAlbum = new SelectList(db.Albuns, "AlbumID", "Nome", musica.IdAlbum);
            return View(mscViewModel);
        }

        // GET: Musica/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Musica musica = repositorioMusicas.SelecionarPorID(id.Value);
            if (musica == null)
            {
                return HttpNotFound();
            }

            List<AlbumExibicaoViewModel> albuns = Mapper.Map<List<Album>, List<AlbumExibicaoViewModel>>(repositorioAlbuns.Selecionar());
            SelectList dropDownAlbuns = new SelectList(albuns, "AlbumID", "Nome");
            ViewBag.DropDownAlbuns = dropDownAlbuns;
            return View(Mapper.Map<Musica, MusicaViewModel>(musica));
        }

        // POST: Musica/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MusicaID,Nome,IdAlbum")] MusicaViewModel musicaViewModel)
        {
            if (ModelState.IsValid)
            {
                Musica musica = Mapper.Map<MusicaViewModel, Musica>(musicaViewModel);
                repositorioMusicas.AlterarDados(musica);
                return RedirectToAction("Index");
            }
            return View(musicaViewModel);
        }

        // GET: Musica/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Musica musica = repositorioMusicas.SelecionarPorID(id.Value);
            if (musica == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<Musica, MusicaExibicaoViewModel>(musica));
        }

        // POST: Musica/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            repositorioMusicas.ExcluirDadosPorId(id);
            return RedirectToAction("Index");
        }
    }
}
