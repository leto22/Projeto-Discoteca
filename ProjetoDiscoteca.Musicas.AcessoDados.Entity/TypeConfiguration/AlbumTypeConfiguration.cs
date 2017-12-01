using ProjetoDiscoteca.Musicas.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDiscoteca.Musicas.AcessoDados.Entity.TypeConfiguration
{
    class AlbumTypeConfiguration : ProjetoDiscoteca.Comum.Entity.ProjetoDiscotecaEntityAbstractConfig<Album>
    {
        protected override void ConfiguraCamposTabela()
        {
            Property(p => p.AlbumID).IsRequired()
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)
                .HasColumnName("ALB_ID");

            Property(p => p.Nome).IsRequired()
                .HasColumnName("ALB_NOME")
                .HasMaxLength(100);

            Property(p => p.Ano).IsRequired()
                .HasColumnName("ALB_ANO");

            Property(p => p.Descricao).IsOptional()
                .HasColumnName("ALB_OBSERVACOES")
                .HasMaxLength(1000);
        }

        protected override void ConfiguraChavePrimaria()
        {
            HasKey(pk => pk.AlbumID);
        }

        protected override void ConfiguraChavesEstrangeiras()
        {
            
        }

        protected override void ConfiguraNomeTabela()
        {
            ToTable("ALB_ALBUNS");
        }
    }
}
