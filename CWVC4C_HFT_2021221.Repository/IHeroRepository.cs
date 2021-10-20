using CWVC4C_HFT_2021221.Models;
using System.Linq;

namespace CWVC4C_HFT_2021221.Repository
{
    public interface IHeroRepository
    {
        void Create(Hero hero);
        void Delete(int id);
        Hero Read(int id);
        IQueryable<Hero> ReadAll();
        void Update(Hero hero);
    }
}