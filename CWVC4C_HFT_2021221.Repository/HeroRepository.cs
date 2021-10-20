using CWVC4C_HFT_2021221.Data;
using CWVC4C_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWVC4C_HFT_2021221.Repository
{
    public class HeroRepository : IHeroRepository
    {
        HeroDbContext db;
        public HeroRepository(HeroDbContext db)
        {
            this.db = db;
        }
        public void Create(Hero hero)
        {
            db.Heroes.Add(hero);
            db.SaveChanges();
        }
        public Hero Read(int id)
        {
            return db.Heroes.FirstOrDefault(t => t.HeroId == id);
        }
        public IQueryable<Hero> ReadAll()
        {
            return db.Heroes;
        }
        public void Delete(int id)
        {
            db.Remove(Read(id));
            db.SaveChanges();
        }
        public void Update(Hero hero)
        {
            var oldHero = Read(hero.HeroId);
            oldHero.Name = hero.Name;
            oldHero.ElementId = hero.ElementId;
            oldHero.Element = hero.Element;
            oldHero.DefensePower = hero.DefensePower;
            oldHero.AttackPower = hero.AttackPower;
            oldHero.Abilities = hero.Abilities;
            db.SaveChanges();

        }

    }
}
