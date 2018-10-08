using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using MVCSession.Models;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Redis;

namespace MVCSession.Controllers
{
    public class HomeController : Controller
    {
        //private SessionStore _sessionStore;

        //private IMemoryCache _memCache;

        private IDistributedCache _redisCache;
        public HomeController(/*SessionStore store, IMemoryCache cache,*/ IDistributedCache redisCache)
        {
            //_sessionStore = store;
            //_memCache = cache;
            this._redisCache = redisCache;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string fname)
        {
            //Cookie
            //Response.Cookies.Append("myName", fname, new CookieOptions
            //{
            //    MaxAge = TimeSpan.FromMinutes(10)
            //});

            //Session
            //HttpContext.Session.SetString("myName", fname);

            //TempData
            //TempData["myName"] = fname;
            //return View();

            //Singleton
            //_sessionStore.Name = fname;


            //ViewData["userType"] = HttpContext.Items["userType"];

            //MemoeryCache
            //MemoryCacheEntryOptions memOptions = new MemoryCacheEntryOptions()
            //{
            //    SlidingExpiration = TimeSpan.FromSeconds(190),
            //    AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(95)
            //};
            //_memCache.Set("myName", fname);

            //Redis Cache
            DistributedCacheEntryOptions distOptions = new DistributedCacheEntryOptions()
            {
                SlidingExpiration = TimeSpan.FromSeconds(1800),
                AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(950)
            };
            _redisCache.SetString("myName", fname, distOptions);
            HttpContext.Session.SetString("BlahBlah", "Rakesh");
            //ViewData["UserName"] = _memCache.Get("myName"); //_sessionStore.Name;

            return RedirectToAction("about");
        }
        public IActionResult About()
        {
            //ViewData["UserName"] = Request.Cookies["myName"];

            //ViewData["UserName"] = HttpContext.Session.GetString("myName");

            //ViewData["UserName"] = TempData["myName"];
            //if (ViewData["UserName"] == null)
            //{
            //    ViewData["UserName"] = TempData.Peek("myName");
            //}

            //TempData.Keep();

            //Singleton
            //ViewData["UserName"] = _sessionStore.Get("myName");

            //In Memory cache
            //ViewData["UserName"] = _memCache.Get("myName");

            //REdis cache
            ViewData["UserName"] = _redisCache.GetString("myName");
            return View();
        }

        public IActionResult Contact()
        {
            //ViewData["Message"] = "Your contact page.";

            //ViewData["UserName"] = TempData["myName"];
            //if (ViewData["UserName"] == null)
            //{
            //    ViewData["UserName"] = TempData.Peek("myName");
            //}
            //TempData.Keep();

            //Singleton
            //ViewData["UserName"] = _sessionStore.Name;

            //In memory cache
            //ViewData["UserName"] = _memCache.Get("myName");

            //Redis cache
            ViewData["UserName"] = _redisCache.GetString("myName");
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
