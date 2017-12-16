using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDiscoteca.Musicas.Dominio
{
    public class Album
    {
        public int AlbumID { get; set; }
        public int Ano { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Email { get; set; }

        public virtual List<Musica> Musicas { get; set; }
    }
}
