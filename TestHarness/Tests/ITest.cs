namespace TestHarness.Tests
{
    public interface ITest
    {
        void Arrange();
        void Act();
        bool Assert();
    }
}