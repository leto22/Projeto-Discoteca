using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDiscoteca.Repositorio.Comum
{
    public interface IRepositorioGenerico<TEntidade, TChave>
        where TEntidade : class
    {
        List<TEntidade> Selecionar();
        TEntidade SelecionarPorID(TChave id);
        void InserirDados(TEntidade entidade);
        void AlterarDados(TEntidade entidade);
        void ExcluirDados(TEntidade entidade);
        void ExcluirDadosPorId(TChave id);
    }
}
