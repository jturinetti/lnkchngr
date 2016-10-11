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
        private readonly IUrlEngine _engine;
        private readonly IUrlValidator _validator;

        public HomeController(IUrlEngine engine, IUrlValidator validator)
        {
            _engine = engine;
            _validator = validator;
        }        

        public IActionResult Index(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                // lookup URL
                var response = _engine.LookupUrl(id);                

                if (response.Url != null)
                {
                    return Redirect(response.Url.AbsoluteUri);
                }

                // TODO: better job of handling service-layer error messages getting to front-end
            }            

            return View();
        }        

        public IActionResult Error()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Post(UrlModel model)
        {
            if (ModelState.IsValid)
            {
                var validatedUri = _validator.Validate(model.Url);

                var response = _engine.GenerateUrl(validatedUri);
                model.MappedUrl = response.Url.AbsoluteUri;
            }                 

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
