using ConsoleApp.Tests;
using Ninject.Modules;

namespace ConsoleApp.IoC
{
    public class TestModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ITest>().To<DemoTest>();
        }
    }
}