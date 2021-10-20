using CWVC4C_HFT_2021221.Models;
using System.Collections.Generic;

namespace CWVC4C_HFT_2021221.Logic
{
    interface IHeroLogic
    {
        double AvgHeroDef();
        IEnumerable<KeyValuePair<string, double>> AVGHeroDefByElements();
        double AvgHeroPower();
        IEnumerable<KeyValuePair<string, double>> AVGHeroPowerByElements();
        void Create(Hero hero);
        void Delete(int id);
        Hero Read(int id);
        IEnumerable<Hero> ReadAll();
        void Update(Hero hero);
    }
}