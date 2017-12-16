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
        /* CLASSE GENERICA DE INTERFACE, UTILIZADA PARA INSERÇÃO DE DADOS FAZENDO UMA PONTE ENTRE WEB-DOMINIO-ACESSO A DADOS 
            DESSA MANEIRA, PODEMOS DIZER QUE MANTEN AS CLASSES POCOS SEMPRE PURAS */

        List<TEntidade> Selecionar();
        TEntidade SelecionarPorID(TChave id);
        void InserirDados(TEntidade entidade);
        void AlterarDados(TEntidade entidade);
        void ExcluirDados(TEntidade entidade);
        void ExcluirDadosPorId(TChave id);
    }
}
