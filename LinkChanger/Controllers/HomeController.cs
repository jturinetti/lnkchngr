using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LinkChanger.Models;
using LinkChanger.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LinkChanger.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUrlGenerator _generator;

        public HomeController(IUrlGenerator generator)
        {
            _generator = generator;
        }

        public IActionResult Index()
        {
            return View();
        }        

        public IActionResult Error()
        {
            return View();
        }

        public IActionResult Post(UrlModel model)
        {
            // TODO

            return null;
        }
    }
}
