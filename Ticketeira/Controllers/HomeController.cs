using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ticketeira.Controllers
{
    public class HomeController : Controller
    {
        
        

        public ActionResult Index()
        {
            if (Session["user"] == null)
                return View("Login");
            else
            {
                return View();
            }
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Cadastra()
        {
            return View();
        }

        public ActionResult GetEstados()
        {
            ticketeiraEntities entities = new ticketeiraEntities();

            var estados = entities.Estado;


            return Json(estados);
        }

        public ActionResult GetCidades(string uf)
        {
            ticketeiraEntities entities = new ticketeiraEntities();

            var cidades = entities.Municipio.Where(_ => _.Uf == uf);

            return Json(cidades);
        }

        [HttpPost]
        public ActionResult DoLogin(string email, string password)
        {
            ticketeiraEntities entities = new ticketeiraEntities();
            
            var user = entities.Users.FirstOrDefault(_ => _.Email == email && _.Password == password && _.Status == true);

            if(user != null)
            {
                Session["user"] = user;
            }

            return Json("/Home/Index");
        }

        [HttpPost]
        public ActionResult TesteLoginNew()
        {
            return Json(Url.Action("Index", "Home"), JsonRequestBehavior.AllowGet);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}