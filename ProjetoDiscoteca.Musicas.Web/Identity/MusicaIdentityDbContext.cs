using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoDiscoteca.Musicas.Web.Identity
{
    public class MusicaIdentityDbContext : IdentityDbContext<IdentityUser> 
    {
        public MusicaIdentityDbContext() : base ("MusicasDbContext")
        {

        }
    }
}