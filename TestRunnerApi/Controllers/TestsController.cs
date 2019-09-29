using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TestHarness.Models;
using TestRunnerApi.Models;
using TestRunnerApi.Services;

namespace TestRunnerApi.Controllers
{
    [Route("api/tests")]
    public class TestsController : ControllerBase
    {
        private readonly ITestResolver _testResolver;
        private readonly IApiTestExecutor _testExecutor;

        public TestsController(ITestResolver testResolver,
            IApiTestExecutor testExecutor)
        {
            _testResolver = testResolver;
            _testExecutor = testExecutor;
        }

        // GET api/tests
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(_testResolver.ListTests());
        }

        // GET api/tests/5
        [HttpGet("{id}")]
        public ActionResult<TestMeta> Get(string id)
        {
            var testMeta = _testExecutor.FindTest(id);

            if (testMeta == null)
            {
                return NotFound();
            }

            return Ok(testMeta);
        }

        // POST api/tests
        [HttpPost]
        public ActionResult Post([FromBody] ScheduleExecutionRequest value)
        {
            var uriPath = Request.Path.ToUriComponent();
            
            try
            {
                var test = _testResolver.TestNameToType(value);
                var result = _testExecutor.Execute(test);

                return Created($"{uriPath}/{result.Id}", result);
            }
            catch (ArgumentNullException e)
            {
                var details = new Dictionary<string, string>
                {
                    {"Message", e.Message}
                };

                return BadRequest(details);
            }
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