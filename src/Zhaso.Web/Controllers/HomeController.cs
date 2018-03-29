using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Diagnostics;
using Zhaso.Web.Models;

namespace Zhaso.Web.Controllers
{
    public class HomeController : Controller
    {
        private SiteSettings Settings;
        public HomeController(IOptions<SiteSettings> options)
        {
            Settings = options.Value;
        }
        public IActionResult Index()
        {
            ViewData["Title"] = Settings.SiteName;
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
