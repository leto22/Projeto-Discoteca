using ProjetoDiscoteca.Musicas.AcessoDados.Entity.TypeConfiguration;
using ProjetoDiscoteca.Musicas.Dominio;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDiscoteca.Musicas.AcessoDados.Entity.Context
{
    public class MusicasDbContext : DbContext
    {
        public MusicasDbContext()
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Album> Albuns { get; set; }
        public DbSet<Musica> Musicas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AlbumTypeConfiguration());
            modelBuilder.Configurations.Add(new MusicaTypeConfiguration());
        }
    }
}
