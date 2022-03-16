using CWVC4C_HFT_2021221.Endpoint.Services;
using CWVC4C_HFT_2021221.Logic;
using CWVC4C_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
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
        IHubContext<SignalRHub> hub;
        public HeroController(IHeroLogic hl, IHubContext<SignalRHub> hub)
        {
            this.hl = hl;
            this.hub = hub;
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
            this.hub.Clients.All.SendAsync("HeroCreated", value);
        }

        // PUT /hero
        [HttpPut]
        public void Put( [FromBody] Hero value)
        {
            hl.Update(value);
            this.hub.Clients.All.SendAsync("HeroUpdated", value);
        }

        // DELETE hero/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var heroToDelete = this.hl.Read(id);

            hl.Delete(id);
            this.hub.Clients.All.SendAsync("HeroDeleted", heroToDelete);
        }
    }
}
