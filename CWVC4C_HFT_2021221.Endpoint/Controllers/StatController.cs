using CWVC4C_HFT_2021221.Logic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CWVC4C_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class StatController : ControllerBase
    {
        IAbilityLogic al;
        IHeroLogic hl;
        
        public StatController(IHeroLogic hl, IAbilityLogic al)
        {
            this.hl = hl;
            this.al = al;
        }


        //ABILITIES ------------------
        // GET: stat/thestrongestelementbyability
        [HttpGet]
        public IEnumerable<KeyValuePair<string, double>> TheStrongestElementByAbility()
        {
            return al.TheStrongestElementByAbility();
        }

        //GET: stat/avgdmgbyhsa
        [HttpGet]
        public IEnumerable<KeyValuePair<string,double>> AVGdmgByHsA()
        {
            return al.AVGdmgByHsA();
        }

        //GET: stat/avgmanabyhsa
        [HttpGet]
        public IEnumerable<KeyValuePair<string, double>> AVGManaByHsA()
        {
            return al.AVGManaByHsA();
        }

        //GET: stat/avgdmg
        [HttpGet]
        public double AVGdmg()
        {
            return al.AVGdmg();
        }

        //HEROES---------------------

        //GET: stat/avgherodef
        [HttpGet]
        public double AvgHeroDef()
        {
            return hl.AvgHeroDef();
        }

        //GET: stat/avgheropower
        [HttpGet]
        public double AvgHeroPower()
        {

            return hl.AvgHeroPower();
        }

        //GET: stat/avgherodefbyelements
        [HttpGet]
        public IEnumerable<KeyValuePair<string, double>> AVGHeroDefByElements()
        {
            return hl.AVGHeroDefByElements();
        }

        //GET: stat/avgheropowerbyelements
        [HttpGet]
        public IEnumerable<KeyValuePair<string, double>> AVGHeroPowerByElements()
        {
            return hl.AVGHeroPowerByElements();
        }


    }
}
