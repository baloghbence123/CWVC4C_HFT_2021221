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
    public class AbilityController : ControllerBase
    {

        IAbilityLogic al;
        IHubContext<SignalRHub> hub;
        public AbilityController(IAbilityLogic al, IHubContext<SignalRHub> hub)
        {
            this.al = al;
            this.hub = hub;
        }

        // GET: /ability
        [HttpGet]
        public IEnumerable<Ability> Get()
        {
            return al.ReadAll();
        }

        // GET /ability/5
        [HttpGet("{id}")]
        public Ability Get(int id)
        {
            return al.Read(id);
        }

        // POST /ability
        [HttpPost]
        public void Post([FromBody] Ability value)
        {
            al.Create(value);
            this.hub.Clients.All.SendAsync("AbilityCreated", value);
        }

        // PUT /ability
        [HttpPut]
        public void Put([FromBody] Ability value)
        {
            al.Update(value);
            this.hub.Clients.All.SendAsync("AbilityUpdated", value);
        }

        // DELETE ability/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
           

            var abilityToDelete = this.al.Read(id);

            al.Delete(id);
            this.hub.Clients.All.SendAsync("AbilityDeleted", abilityToDelete);
        }
    }
}
