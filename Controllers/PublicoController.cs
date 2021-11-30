using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NextConta.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NextConta.Controllers
{
    public class PublicoController : Controller
    {
        private readonly Context _context;

        public PublicoController(Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Logar()
        {
            return View();
        }
       

        public IActionResult Logout()
        {
            CookieOptions cookie = new CookieOptions();
            cookie.Expires = DateTime.Now.AddMinutes(5);
            Response.Cookies.Append("Email", "", cookie);

            return RedirectToAction("Logar", "Publico");
        }
        
        [HttpPost]
        public IActionResult Logar(string email, string senha)
        {
            string user = AutenticarUser(email, senha);

            if (user == "")
            {
                ViewBag.Error = "E-mail e/ou senha incorreto(s)";

                return View();
            }

            else
            {
                CookieOptions cookie = new CookieOptions();
                cookie.Expires = DateTime.Now.AddMinutes(5);
                Response.Cookies.Append("Email", user, cookie);

                return RedirectToAction("Index", "Home");



            }
        }


        public string AutenticarUser(string email, string senha)
        {
            var query = (from u in _context.Nova_Contas
                         where u.Email == email &&
                         u.Senha == senha
                         select u).SingleOrDefault();

            if (query == null)
            {
                return "";
            }

            else
            {
                return query.Email;
            }
        }



    }
}
