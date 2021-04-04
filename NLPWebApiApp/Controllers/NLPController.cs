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
        // POST api/<NLPController>
        [HttpPost]
        public IActionResult Post([FromBody] NLP nlp)
        {
            NLPResult output = new NLPResult();
            output.makeDigits(nlp.UserText);
            return Ok(output);
        }

    }
}
