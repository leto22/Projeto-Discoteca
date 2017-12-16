using ProjetoDiscoteca.Musicas.AcessoDados.Entity.Context;
using ProjetoDiscoteca.Musicas.Dominio;
using ProjetoDiscoteca.Repositorios.Comum.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ProjetoDiscoteca.Musicas.Repositorios.Entity
{
    public class AlbumRepositorio : RepositorioGenericoEntity<Album, int>
    {
        /* CLASSE UTILIZADA PARA SER INSTANCIADA NA CAMADA WEB PARA QUE SEJA RETIRADA O FORTE ACOPLAMENTO */

        public AlbumRepositorio(MusicasDbContext contexto) : base(contexto)
        { }

        public override List<Album> Selecionar()
        {
            return _contexto.Set<Album>().Include(p => p.Musicas).ToList();
        }

        public override Album SelecionarPorID(int id)
        {
            return _contexto.Set<Album>().Include(p => p.Musicas).SingleOrDefault(a => a.AlbumID == id);
        }
    }
}
