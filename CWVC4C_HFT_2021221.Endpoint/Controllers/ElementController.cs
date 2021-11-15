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
    public class ElementController : ControllerBase
    {
        IElementLogic el;
        public ElementController(IElementLogic el)
        {
            this.el = el;
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
        }

        // PUT /element/5
        [HttpPut]
        public void Put([FromBody] Element value)
        {
            el.Update(value);
        }

        // DELETE /element/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            el.Delete(id);
        }
    }
}
