using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using lnkchngr.Models;
using lnkchngr.Services.Interfaces;

namespace lnkchngr.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IUrlEngine _engine;
    private readonly IUrlValidator _validator;

    public HomeController(ILogger<HomeController> logger, IUrlEngine engine, IUrlValidator validator)
    {
        _logger = logger;
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

    public IActionResult Privacy()
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

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
