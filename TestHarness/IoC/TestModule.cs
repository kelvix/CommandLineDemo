using ConsoleApp.Tests;
using Microsoft.Extensions.DependencyInjection;
using TestHarness.Tests;

namespace TestHarness.IoC
{
    public class TestModule
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<ITestExecutor, TestExecutor>();
            services.AddTransient<ITest, DemoTest>();
            services.AddTransient<ITest, SecondTest>();
        }
    }
}