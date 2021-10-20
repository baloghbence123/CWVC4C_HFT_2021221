using CWVC4C_HFT_2021221.Data;
using CWVC4C_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWVC4C_HFT_2021221.Repository
{
    public class AbilityRepository : IAbilityRepository
    {
        HeroDbContext db;
        public AbilityRepository(HeroDbContext db)
        {
            this.db = db;
        }

        public void Create(Ability ability)
        {
            db.Abilities.Add(ability);
            db.SaveChanges();
        }
        public Ability Read(int id)
        {
            return db.Abilities.FirstOrDefault(t => t.AbilityId == id);

        }
        public IQueryable<Ability> ReadAll()
        {
            return db.Abilities;
        }
        public void Delete(int id)
        {
            db.Remove(Read(id));
            db.SaveChanges();
        }
        public void Update(Ability ability)
        {
            var oldability = Read(ability.AbilityId);
            oldability.DMG = ability.DMG;            
            oldability.HeroId = ability.HeroId;
            oldability.ManaCost = ability.ManaCost;
            oldability.Name = ability.Name;
            db.SaveChanges();
        }


    }
}
