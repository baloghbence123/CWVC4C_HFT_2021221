using CWVC4C_HFT_2021221.Models;
using System.Collections.Generic;

namespace CWVC4C_HFT_2021221.Logic
{
    public interface IAbilityLogic
    {
        double AVGdmg();
        IEnumerable<KeyValuePair<string, double>> AVGdmgByHsA();
        IEnumerable<KeyValuePair<string, double>> AVGManaByHsA();
        void Create(Ability ability);
        void Delete(int id);
        Ability Read(int id);
        IEnumerable<Ability> ReadAll();
        IEnumerable<KeyValuePair<string, double>> TheStrongestElementAbility();
        void Update(Ability ability);
    }
}