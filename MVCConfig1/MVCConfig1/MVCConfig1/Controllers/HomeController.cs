using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MVCConfig1.Models;

namespace MVCConfig1.Controllers
{
    public class HomeController : Controller
    {
        private AppConfig _appConfig;
        public HomeController(IConfiguration config, IOptions<AppConfig> appConfig)
        {
            Configuration = config;
            _appConfig = appConfig.Value;
        }

        public IConfiguration Configuration { get; set; }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page." + Configuration.GetValue<string>("jsondata:name");

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
