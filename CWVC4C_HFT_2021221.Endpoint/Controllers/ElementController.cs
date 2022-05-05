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
    public class ElementController : ControllerBase
    {
        IElementLogic el;
        IHubContext<SignalRHub> hub;
        public ElementController(IElementLogic el, IHubContext<SignalRHub> hub)
        {
            this.el = el;
            this.hub = hub;
        }


        // GET: /<element>
        [HttpGet]
        public IEnumerable<Element> Get()
        {
            return el.ReadAll();
        }

        // GET /element/5
        [HttpGet("{id}")]
        public Element Get(int id)
        {
            return el.Read(id);
        }

        // POST /element
        [HttpPost]
        public void Post([FromBody] Element value)
        {
            el.Create(value);
            this.hub.Clients.All.SendAsync("ElementCreated", value);
        }

        // PUT /element/5
        [HttpPut]
        public void Put([FromBody] Element value)
        {
            el.Update(value);
            this.hub.Clients.All.SendAsync("ElementUpdated", value);
        }

        // DELETE /element/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var elementToDelete = this.el.Read(id);

            el.Delete(id);
            this.hub.Clients.All.SendAsync("ElementDeleted", elementToDelete);
        }
    }
}
