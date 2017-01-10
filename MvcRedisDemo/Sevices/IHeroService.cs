using System.Collections.Generic;
using System.Threading.Tasks;
using MvcRedisDemo.Models;

namespace MvcRedisDemo.Sevices
{
    public interface IHeroService
    {
        Task<List<Hero>> GetAllHeroesAsync();

        Task<Hero> GetHeroAsync(string id);

        Task<Hero> CreateHeroAsync(CreateHeroModel createHeroModel);

        Task<Hero> UpdateHeroAsync(string id, UpdateHeroModel updateHeroModel);

        Task<bool> DeleteHeroAsync(string id);
    }
}
