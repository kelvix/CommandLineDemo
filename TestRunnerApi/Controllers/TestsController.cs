using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TestRunnerApi.Services;

namespace TestRunnerApi.Controllers
{
    [Route("api/tests")]
    public class TestsController : ControllerBase
    {
        private readonly ITestResolver _testResolver;

        public TestsController(ITestResolver testResolver)
        {
            _testResolver = testResolver;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return _testResolver.ListTests();
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