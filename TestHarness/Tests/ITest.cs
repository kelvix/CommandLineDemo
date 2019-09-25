namespace ConsoleApp.Tests
{
    public interface ITest
    {
        void Arrange();
        void Act();
        bool Assert();
    }
}