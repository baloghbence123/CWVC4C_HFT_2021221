using CWVC4C_HFT_2021221.Models;
using System.Collections.Generic;

namespace CWVC4C_HFT_2021221.Logic
{
   public interface IElementLogic
    {
        void Create(Element hero);
        void Delete(int id);
        Element Read(int id);
        IEnumerable<Element> ReadAll();
        void Update(Element hero);
    }
}