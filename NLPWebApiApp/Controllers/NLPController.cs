using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NLPWebApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NLPController : ControllerBase
    {
        // GET: api/<NLPController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<NLPController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<NLPController>
        [HttpPost]
        public IActionResult Post([FromBody] NLP nlp)
        {
            NLPResult output = new NLPResult();
            output.makeDigits(nlp.UserText);
            return Ok(output);
        }

        // PUT api/<NLPController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<NLPController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
