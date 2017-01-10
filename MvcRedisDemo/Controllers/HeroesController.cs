using System;
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

        public async Task<ActionResult> Details(string id)
        {
            var hero = await _heroService.GetHeroAsync(id);

            return View(hero);
        }

        public ActionResult Create()
        {
            var heroModel = new CreateHeroModel();

            return View(heroModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateHeroModel createHeroModel)
        {
            if (ModelState.IsValid)
            {
                var hero = await _heroService.CreateHeroAsync(createHeroModel);

                return RedirectToAction("Details", "Heroes", new { id = hero.Id });
            }

            return View(createHeroModel);
        }

        public async Task<ActionResult> Edit(string id)
        {
            var hero = await _heroService.GetHeroAsync(id);
            var editHeroModel = new UpdateHeroModel
            {
                Id          = hero.Id,
                Name        = hero.Name,
                Description = hero.Description,
                Score       = hero.Score,
                Status      = hero.Status
            };

            return View(editHeroModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(string id, UpdateHeroModel hero)
        {
            if (hero == null)
                throw new Exception($"Hero not provided for id={id}.");

            if (id != hero.Id)
                throw new Exception($"Id {id} is different from hero's id {hero.Id}.");

            if (ModelState.IsValid)
            {
                await _heroService.UpdateHeroAsync(id, hero);

                return RedirectToAction("Details", "Heroes", new { id = hero.Id });
            }

            return View(hero);
        }

        public async Task<ActionResult> Delete(string id)
        {
            var hero = await _heroService.GetHeroAsync(id);
            return View(hero);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            await _heroService.DeleteHeroAsync(id);

            return RedirectToAction("Index", "Home");
        }
    }
}
