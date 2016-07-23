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
        private readonly IUrlValidator _validator;

        public HomeController(IUrlGenerator generator, IUrlValidator validator)
        {
            _generator = generator;
            _validator = validator;
        }

        public IActionResult Index()
        {
            return View();
        }        

        public IActionResult Error()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Post(UrlModel model)
        {
            var validatedUri = _validator.Validate(model.Url);

            var result = _generator.GenerateUrl(validatedUri);
            model.MappedUrl = result.AbsoluteUri;

            return RedirectToAction("Result", model);
        }

        public IActionResult Result(UrlModel model)
        {
            if (string.IsNullOrEmpty(model?.MappedUrl))
            {
                return RedirectToAction("Index");
            }

            return View(model);
        }
    }
}
