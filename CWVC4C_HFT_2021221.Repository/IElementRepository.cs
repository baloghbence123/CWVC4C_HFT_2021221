using CWVC4C_HFT_2021221.Models;
using System.Linq;

namespace CWVC4C_HFT_2021221.Repository
{
    public interface IElementRepository
    {
        void Create(Element element);
        void Delete(int id);
        Element Read(int id);
        IQueryable<Element> ReadAll();
        void Update(Element element);
    }
}