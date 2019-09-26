using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace TestRunnerApi.Services
{
    public interface ITestResolver
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        ActionResult<IEnumerable<string>> ListTests();
    }
}