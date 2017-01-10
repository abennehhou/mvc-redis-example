using System.Threading.Tasks;
using System.Web.Mvc;
using MvcRedisDemo.Models;
using MvcRedisDemo.Sevices;

namespace MvcRedisDemo.Controllers
{
    public class HeroesController : Controller
    {
        private readonly IHeroService _heroService;

        public HeroesController(IHeroService heroService)
        {
            _heroService = heroService;
        }

        // GET: Heroes/Details/5
        public async Task<ActionResult> Details(string id)
        {
            var hero = await _heroService.GetHeroAsync(id);

            return View(hero);
        }

        // GET: Heroes/Create
        public ActionResult Create()
        {
            var accountModel = new CreateHeroModel();

            return View(accountModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateHeroModel createHeroModel)
        {
            if (ModelState.IsValid)
            {
                var hero = await _heroService.CreateHeroAsync(createHeroModel);

                return RedirectToAction("Details", "Heroes", new { id = hero.Id});
            }

            return View(createHeroModel);
        }
    }
}
