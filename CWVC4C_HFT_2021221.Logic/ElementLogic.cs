using CWVC4C_HFT_2021221.Models;
using CWVC4C_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWVC4C_HFT_2021221.Logic
{
    public class ElementLogic : IElementLogic
    {

        IElementRepository elementRepository;
        public ElementLogic(IElementRepository elementRepository)
        {
            this.elementRepository = elementRepository;
        }
        public void Create(Element element)
        {
            if (element.Name != null)
            {
                elementRepository.Create(element);
            }
            else throw new ArgumentException("Name is required");
            
        }
        public Element Read(int id)
        {
            return elementRepository.Read(id);

        }
        public IEnumerable<Element> ReadAll()
        {
            return elementRepository.ReadAll();
        }
        public void Delete(int id)
        {
            elementRepository.Delete(id);
        }
        public void Update(Element element)
        {
            if (element.Name!=null)
            {
                elementRepository.Update(element);
            }
            else throw new ArgumentException("Name is required");

        }
        public IEnumerable<KeyValuePair<string,double>> TheStrongestElementAbility()
        {
            return from x in elementRepository.ReadAll()
                   from y in x.Heroes
                   from z in y.Abilities
                   group z by z.Hero.Element.Name into g
                   orderby g.Max(t=>t.DMG) descending
                   select new KeyValuePair<string, double>(g.Key,g.Max(t=>t.DMG));
        }


    }
}
