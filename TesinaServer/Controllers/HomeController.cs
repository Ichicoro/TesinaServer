﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using TesinaServer.Models;

namespace TesinaServer.Controllers {
    public class HomeController : Controller {

        // Let's return a PartialView() only because we want completely
        // custom styling for our Index (landing) page.
        public IActionResult Index() => PartialView();
        public IActionResult Testing() => PartialView();


        public IActionResult About() {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Game(int id = -1) {
            ViewData.Add("MatchID", id);
            return PartialView();
        }


        public IActionResult Contact() {
            ViewData["Message"] = "Your contact page.";

            return View();
        }


        public IActionResult Error() =>
            View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
