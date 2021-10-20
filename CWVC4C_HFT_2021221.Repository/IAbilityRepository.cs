using CWVC4C_HFT_2021221.Models;
using System.Linq;

namespace CWVC4C_HFT_2021221.Repository
{
    public interface IAbilityRepository
    {
        void Create(Ability ability);
        void Delete(int id);
        Ability Read(int id);
        IQueryable<Ability> ReadAll();
        void Update(Ability ability);
    }
}