using CWVC4C_HFT_2021221.Models;
using CWVC4C_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWVC4C_HFT_2021221.Logic
{
    public class HeroLogic : IHeroLogic
    {
        IHeroRepository heroRepository;
        public HeroLogic(IHeroRepository heroRepository)
        {
            this.heroRepository = heroRepository;
        }


        public void Create(Hero hero)
        {
            if (hero.Name!=null && hero.AttackPower>0 && hero.DefensePower>0 && hero.ElementId>-1 )
            {
                heroRepository.Create(hero);
            }
            else throw new ArgumentException("More hero information is required");

        }
        public Hero Read(int id)
        {
            return heroRepository.Read(id);

        }
        public IEnumerable<Hero> ReadAll()
        {
            return heroRepository.ReadAll();
        }
        public void Delete(int id)
        {
            heroRepository.Delete(id);
        }
        public void Update(Hero hero)
        {
            if (hero.Name != null && hero.AttackPower > 0 && hero.DefensePower > 0 && hero.ElementId > -1)
            {
                heroRepository.Update(hero);
            }
            else throw new ArgumentException("More hero information is required");

        }


        //NON-CRUD
        public double AvgHeroPower()
        {
            return heroRepository.ReadAll().Average(t => t.AttackPower);
        }
        public double AvgHeroDef()
        {
            return heroRepository.ReadAll().Average(t => t.DefensePower);
        }
        public IEnumerable<KeyValuePair<string, double>> AVGHeroPowerByElements()
        {
            return from x in heroRepository.ReadAll()
                   group x by x.Element.Name into g
                   select new KeyValuePair<string, double>(g.Key, g.Average(t => t.AttackPower));
        }
        public IEnumerable<KeyValuePair<string, double>> AVGHeroDefByElements()
        {
            return from x in heroRepository.ReadAll()
                   group x by x.Element.Name into g
                   select new KeyValuePair<string, double>(g.Key, g.Average(t => t.DefensePower));
        }


    }
}
