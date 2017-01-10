using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MvcRedisDemo.Models;
using Newtonsoft.Json;

namespace MvcRedisDemo.Sevices
{
    public class HeroService : IHeroService
    {
        private const string HeroKeyPattern = "Hero:{0}";
        private const string HeroIdsSetKey = "ids:Hero";

        private readonly IDatabaseContext _databaseContext;

        public HeroService(IDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<List<Hero>> GetAllHeroesAsync()
        {
            var members = await _databaseContext.GetRedisDatabase().SetMembersAsync(HeroIdsSetKey);

            var heroes = new List<Hero>();
            foreach (var member in members)
            {
                var hero = await GetHeroAsync(member);
                heroes.Add(hero);
            }

            return heroes;
        }

        public async Task<Hero> GetHeroAsync(string id)
        {
            var serializedHero = await _databaseContext.GetRedisDatabase().StringGetAsync(string.Format(HeroKeyPattern, id));

            return serializedHero.IsNullOrEmpty ? null : JsonConvert.DeserializeObject<Hero>(serializedHero);
        }

        public async Task<Hero> CreateHeroAsync(CreateHeroModel createHeroModel)
        {
            var hero = new Hero
            {
                Id           = Guid.NewGuid().ToString(),
                Name         = createHeroModel.Name,
                Description  = createHeroModel.Description,
                Score        = createHeroModel.Score,
                CreationDate = DateTime.UtcNow,
                Status       = "Created"
            };

            var serializedHero = JsonConvert.SerializeObject(hero);

            await _databaseContext.GetRedisDatabase().StringSetAsync(string.Format(HeroKeyPattern, hero.Id), serializedHero);
            await _databaseContext.GetRedisDatabase().SetAddAsync(HeroIdsSetKey, hero.Id);

            return await Task.FromResult(hero);
        }
    }
}