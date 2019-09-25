using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace TestRunnerApi.Controllers
{
    [Route("api/tests")]
    public class TestsController : ControllerBase
    { 
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] {"value1", "value2"};
        }
        
        // GET api/tests/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }
        
        // POST api/tests
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }
        
        // PUT api/tests/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/tests/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}