using System;
using System.Collections.Generic;
using System.Linq;
using CommandLine;
using Microsoft.Extensions.DependencyInjection;
using TestHarness.Tests;

namespace ConsoleApp
{
    internal class Program
    {
        private static IEnumerable<ITest> _tests;

        private static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            var startup = new Startup();
            
            startup.ConfigureServices(serviceCollection);
            var serviceProvider = serviceCollection.BuildServiceProvider();

            _tests = serviceProvider.GetServices<ITest>();

            if (args.Length > 0)
            {
                Parser.Default.ParseArguments<Options>(args)
                    .WithParsed(RunWithOptions);                
            }
            else
            {
                Console.WriteLine("Default run with no options.");                
            }
        }

        private static void RunWithOptions(Options options)
        {
            Console.WriteLine("Doing a run with custom command line options.");
            
            Console.WriteLine(options.Environment);
            Console.WriteLine(options.Test);

            var testToRun = FindTest(options.Test);
            if (testToRun == null)
            {
                System.Environment.Exit(1);
            }
            else
            {
                testToRun.Assert();
            }
        }

        /// <summary>
        /// Use <see cref="_tests"/> to find a test to execute.
        /// </summary>
        /// <param name="testName"></param>
        /// <returns></returns>
        private static ITest FindTest(string testName)
        {
            if (string.IsNullOrWhiteSpace(testName)) return null;

            return _tests.FirstOrDefault(test => test.GetType().Name.Equals(testName));
        }
    }
}