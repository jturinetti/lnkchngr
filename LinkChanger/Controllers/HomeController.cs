using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LinkChanger.Models;
using Microsoft.AspNetCore.Mvc;

namespace LinkChanger.Controllers
{
    public class HomeController : Controller
    {
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
