using CommandLine;
using CommandLine.Text;

namespace ConsoleApp
{
    public class Options
    {
        [Option('e', Required = true, 
            HelpText = "The environment the tests should target.")]
        public Environment Environment { get; set; }

        [Option('t', Required = true, HelpText = "The name of the test to run.")]
        public string Test { get; set; }
    }

    public enum Environment
    {
        Test,
        Stage,
        Mock,
        Prod
    }
}