using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDiscoteca.Musicas.Dominio
{
    public class Musica
    {
        public long MusicaID { get; set; }
        public string Nome { get; set; }

        public virtual Album Album { get; set; }
        public int IdAlbum { get; set; }
    }
}
