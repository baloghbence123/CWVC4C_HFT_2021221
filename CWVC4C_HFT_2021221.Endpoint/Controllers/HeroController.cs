using CWVC4C_HFT_2021221.Logic;
using CWVC4C_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CWVC4C_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HeroController : ControllerBase
    {
        IHeroLogic hl;
        public HeroController(IHeroLogic hl)
        {
            this.hl = hl;

        }

        // GET: /Hero>
        [HttpGet]
        public IEnumerable<Hero> Get()
        {
            return hl.ReadAll();
        }

        // GET /Hero/5
        [HttpGet("{id}")]
        public Hero Get(int id)
        {
            return hl.Read(id);
        }

        // POST /hero
        [HttpPost]
        public void Post([FromBody] Hero value)
        {
            hl.Create(value);
        }

        // PUT /hero
        [HttpPut]
        public void Put( [FromBody] Hero value)
        {
            hl.Update(value);
        }

        // DELETE hero/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            hl.Delete(id);
        }
    }
}
