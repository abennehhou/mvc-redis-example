using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using MvcRedisDemo.Sevices;

namespace MvcRedisDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHeroService _heroService;

        public HomeController(IHeroService heroService)
        {
            _heroService = heroService;
        }


        // GET: Home
        public async Task<ActionResult> Index()
        {
            var heroes = await _heroService.GetAllHeroesAsync();
            return View(heroes);
        }

    }
}