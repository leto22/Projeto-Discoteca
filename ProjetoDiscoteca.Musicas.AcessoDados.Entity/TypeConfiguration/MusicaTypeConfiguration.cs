using ProjetoDiscoteca.Comum.Entity;
using ProjetoDiscoteca.Musicas.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDiscoteca.Musicas.AcessoDados.Entity.TypeConfiguration
{
    class MusicaTypeConfiguration : ProjetoDiscotecaEntityAbstractConfig<Musica>
    {
        protected override void ConfiguraCamposTabela()
        {
            Property(p => p.MusicaID).IsRequired()
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)
                .HasColumnName("MUS_ID");

            Property(p => p.Nome).IsRequired()
                .HasColumnName("MUS_NOME")
                .HasMaxLength(50);

            Property(p => p.IdAlbum).IsRequired()
                .HasColumnName("ALB_ID");
        }

        protected override void ConfiguraChavePrimaria()
        {
            HasKey(pk => pk.MusicaID);
        }

        protected override void ConfiguraChavesEstrangeiras()
        {
            HasRequired(p => p.Album)
                .WithMany(p => p.Musicas)
                .HasForeignKey(fk => fk.IdAlbum);
        }

        protected override void ConfiguraNomeTabela()
        {
            ToTable("MUS_MUSICAS");
        }
    }
}
