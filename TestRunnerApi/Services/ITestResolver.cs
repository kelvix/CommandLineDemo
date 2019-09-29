using System;
using System.Collections.Generic;
using TestHarness.Tests;
using TestRunnerApi.Models;

namespace TestRunnerApi.Services
{
    public interface ITestResolver
    {
        /// <summary>
        /// Finds all tests that may be executed by this application. The result
        /// is provided as an enumeration of strings. The individual values is
        /// the class name of the test. 
        /// </summary>
        /// <returns>all tests that may be executed</returns>
        IEnumerable<string> ListTests();

        /// <summary>
        /// Returns the object tied to a specific test name. This could be used
        /// to execute a test requested via the web api.
        /// </summary>
        /// <param name="executionRequest">a object that includes the test name
        /// to be identified</param>
        /// <returns>a test to execute if one was found; an exception if no test
        /// name is found</returns>
        /// <exception cref="ArgumentNullException"></exception>
        ITest TestNameToType(ScheduleExecutionRequest executionRequest);
    }
}