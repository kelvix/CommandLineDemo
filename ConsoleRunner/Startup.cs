using Microsoft.Extensions.DependencyInjection;
using TestHarness.IoC;

namespace ConsoleApp
{
    public class Startup
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            TestModule.ConfigureServices(services);
        }
    }
}