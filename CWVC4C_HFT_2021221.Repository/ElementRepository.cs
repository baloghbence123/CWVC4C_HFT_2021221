using CWVC4C_HFT_2021221.Data;
using CWVC4C_HFT_2021221.Models;
using System;
using System.Linq;

namespace CWVC4C_HFT_2021221.Repository
{
    public class ElementRepository : IElementRepository
    {
        HeroDbContext db;

        public ElementRepository(HeroDbContext db)
        {
            this.db = db;
        }

        public void Create(Element element)
        {
            db.Elements.Add(element);
            db.SaveChanges();
        }
        public Element Read(int id)
        {
            return db.Elements.FirstOrDefault(t => t.ElementId == id);

        }
        public IQueryable<Element> ReadAll()
        {
            return db.Elements;
        }
        public void Delete(int id)
        {
            db.Remove(Read(id));
            db.SaveChanges();
        }
        public void Update(Element element)
        {
            var oldelement = Read(element.ElementId);
            oldelement.Heroes = element.Heroes;
            oldelement.Name = element.Name;
            db.SaveChanges();
        }


    }
}
