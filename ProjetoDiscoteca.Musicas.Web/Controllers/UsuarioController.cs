using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ProjetoDiscoteca.Musicas.Web.Identity;
using ProjetoDiscoteca.Musicas.Web.ViewModels.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoDiscoteca.Musicas.Web.Controllers
{
    [AllowAnonymous]
    public class UsuarioController : Controller
    {
        public ActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastro(UsuarioViewModel usrViewModel)
        {
            if (ModelState.IsValid)
            {
                var userStore = new UserStore<IdentityUser>(new MusicaIdentityDbContext());
                var userManager = new UserManager<IdentityUser>(userStore);
                var identityUser = new IdentityUser
                {
                    UserName = usrViewModel.Email,
                    Email = usrViewModel.Email
                };

                IdentityResult resultado = userManager.Create(identityUser, usrViewModel.Senha);
                if (resultado.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("error", resultado.Errors.First());
                    return View(usrViewModel);
                }
            }

            return View(usrViewModel);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UsuarioViewModel usrViewModel)
        {
            if (ModelState.IsValid)
            {
                var userStore = new UserStore<IdentityUser>(new MusicaIdentityDbContext());
                var userManager = new UserManager<IdentityUser>(userStore);
                var usuario = userManager.Find(usrViewModel.Email, usrViewModel.Senha);
                if (usuario == null)
                {
                    ModelState.AddModelError("error", "Usúario e/ou senhas incorretas!");
                    return View(usrViewModel);
                }

                var authManager = HttpContext.GetOwinContext().Authentication;
                var identityUser = userManager.CreateIdentity(usuario, DefaultAuthenticationTypes.ApplicationCookie);
                authManager.SignIn(new Microsoft.Owin.Security.AuthenticationProperties
                {
                    IsPersistent = false
                }, identityUser);

                return RedirectToAction("Index", "Home");
            }

            return View(usrViewModel);
        }

        [Authorize]
        public ActionResult Logoff()
        {
            var authManager = HttpContext.GetOwinContext().Authentication;
            authManager.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}