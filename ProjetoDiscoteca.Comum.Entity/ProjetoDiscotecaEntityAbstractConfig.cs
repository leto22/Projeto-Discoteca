using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDiscoteca.Comum.Entity
{
    public abstract class ProjetoDiscotecaEntityAbstractConfig<TEntidade> : EntityTypeConfiguration<TEntidade>
        where TEntidade : class
    {
        public ProjetoDiscotecaEntityAbstractConfig()
        {
            ConfiguraNomeTabela();
            ConfiguraCamposTabela();
            ConfiguraChavePrimaria();
            ConfiguraChavesEstrangeiras();
        }

        protected abstract void ConfiguraChavesEstrangeiras();
        protected abstract void ConfiguraChavePrimaria();
        protected abstract void ConfiguraCamposTabela();
        protected abstract void ConfiguraNomeTabela();
    }
}
