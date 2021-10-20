using CWVC4C_HFT_2021221.Models;
using CWVC4C_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CWVC4C_HFT_2021221.Logic
{
    public class AbilityLogic : IAbilityLogic
    {
        //itt írható olyan logic metódus amiben mindegyik repositorit használhatjuk
        // Tudunk bele plusz ellenörző logikákat tenni
        //+ non-Crud methods

        IAbilityRepository abilityRepo;
        public AbilityLogic(IAbilityRepository abilityRepo)
        {
            this.abilityRepo = abilityRepo;
        }



        public void Create(Ability ability)
        {
            if (ability.Name!=null && ability.HeroId>-1 && ability.ManaCost>-1 && ability.DMG>-1)
            {
                abilityRepo.Create(ability);
            }
            else throw new ArgumentException("You didn't define well this ability, didn't you?");

            
        }
        public Ability Read(int id)
        {
            return abilityRepo.Read(id);

        }
        public IEnumerable<Ability> ReadAll()
        {
            return abilityRepo.ReadAll();
        }
        public void Delete(int id)
        {
            abilityRepo.Delete(id);
        }
        public void Update(Ability ability)
        {
            if (true)
            {
                abilityRepo.Update(ability);
            }
            else throw new ArgumentException("You didn't define well this ability, didn't you?");
            
        }



        //non-Crud methods
        //Average dmg
        public double AVGdmg()
        {
            return abilityRepo.ReadAll()
                .Average(t => t.DMG);
        }
        //Avarage dmg by heroes
        public IEnumerable<KeyValuePair<string, double>> AVGdmgByHsA()
        {
            return from x in abilityRepo.ReadAll()
                   group x by x.Hero.Name into g
                   select new KeyValuePair<string, double>(g.Key, g.Average(t => t.DMG));
        }
        public IEnumerable<KeyValuePair<string, double>> AVGManaByHsA()
        {
            return from x in abilityRepo.ReadAll()
                   group x by x.Hero.Name into g
                   select new KeyValuePair<string, double>(g.Key, g.Average(t => t.ManaCost));
        }
        public IEnumerable<KeyValuePair<string, double>> TheStrongestElementAbility()
        {
            return (from x in abilityRepo.ReadAll()
                    group x by x.Hero.Element.Name into g
                    orderby g.Max(t => t.DMG) descending
                    select new KeyValuePair<string, double>(g.Key, g.Max(t => t.DMG))).Take(1);
        }

    }
}
