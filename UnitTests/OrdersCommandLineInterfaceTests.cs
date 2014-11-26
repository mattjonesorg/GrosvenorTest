using Grosvenor.Practicum.Services;
using Grosvenor.Practicum.Services.Factories;
using NUnit.Framework;
using StructureMap;

namespace Grosvenor.Practicum.UnitTests
{
    [TestFixture]
    class OrdersCommandLineInterfaceTests
    {
        private IOrdersCommandLineInterface cli;

        [SetUp]
        public void Setup()
        {
            Container container = Bootstrapper.GetIocContainer();
            cli = container.GetInstance<IOrdersCommandLineInterface>();
        }

        [TestCase("eggs, toast, coffee", new string[] { "morning,", "1,", "2,", "3" })]
        [TestCase("eggs, toast, coffee", new string[] { "morning,", "2,", "1,", "3" })]
        [TestCase("eggs, toast, coffee, error", new string[] { "morning,", "1,", "2,", "3,","4" })]
        [TestCase("eggs, toast, coffee(x3)", new string[] { "morning,", "1,", "2,", "3,","3,3" })]
        [TestCase("steak, potato(x2), cake", new string[] { "night,", "1,", "2,","2,", "4" })]
        [TestCase("steak, potato, wine, error", new string[] { "night,", "1, 2, 3, 5" })]
        [TestCase("steak, error", new string[] { "night,", "1, 1, 2, 3, 5" })]
        [TestCase("steak, error", new string[] { "NIGHT,", "1, 1, 2, 3, 5" })]
        public void IntegrationTests(string expectation, string[] args)
        {
            Assert.That(cli.Process(args), Is.EqualTo(expectation));
        }
    }
}
