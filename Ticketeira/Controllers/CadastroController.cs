﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ticketeira.Controllers
{
    public class CadastroController : Controller
    {
        // GET: Cadastro
        public ActionResult Index()
        {
            return View("CadastraEvento");
        }

        public ActionResult CadastraEvento()
        {
            return View();
        }

    }
}