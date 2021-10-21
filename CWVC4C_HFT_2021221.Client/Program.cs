using CWVC4C_HFT_2021221.Data;
using CWVC4C_HFT_2021221.Logic;
using CWVC4C_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CWVC4C_HFT_2021221.Client
{
    class Program
    {
        static void Main(string[] args)
        {

            HeroDbContext db = new HeroDbContext();

            AbilityLogic a1 = new AbilityLogic(new AbilityRepository(db));
            HeroLogic h1 = new HeroLogic(new HeroRepository(db));
            ElementLogic e1 = new ElementLogic(new ElementRepository(db));
            var t1 = e1.TheStrongestElementAbility();
            
            ;


                     

            

        }
    }
}
