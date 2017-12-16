using ProjetoDiscoteca.Repositorio.Comum;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDiscoteca.Repositorios.Comum.Entity
{
    public class RepositorioGenericoEntity<TEntidade, TChave> : IRepositorioGenerico<TEntidade, TChave> 
        where TEntidade : class
    {
        /* CLASSE UTILIZADA PARA A IMPLEMENTAÇÃO DOS DADOS COM ENTITY, ONDE ESTÁ CHAMANDO A CLASSE INTERFACE E IMPLEMENTADONDO
        SEUS METODOS */

        protected DbContext _contexto;

        public RepositorioGenericoEntity(DbContext contexto)
        {
            _contexto = contexto;
        }

        public virtual List<TEntidade> Selecionar()
        {
            return _contexto.Set<TEntidade>().ToList();
        }

        public virtual TEntidade SelecionarPorID(TChave id)
        {
            return _contexto.Set<TEntidade>().Find(id);
        }

        public void InserirDados(TEntidade entidade)
        {
            _contexto.Set<TEntidade>().Add(entidade);
            _contexto.SaveChanges();
        }

        public void AlterarDados(TEntidade entidade)
        {
            _contexto.Set<TEntidade>().Attach(entidade);
            _contexto.Entry(entidade).State = EntityState.Modified;
            _contexto.SaveChanges();
        }

        public void ExcluirDados(TEntidade entidade)
        {
            _contexto.Set<TEntidade>().Attach(entidade);
            _contexto.Entry(entidade).State = EntityState.Deleted;
            _contexto.SaveChanges();
        }

        public void ExcluirDadosPorId(TChave id)
        {
            TEntidade entidade = SelecionarPorID(id);
            ExcluirDados(entidade);

        }
    }
}
