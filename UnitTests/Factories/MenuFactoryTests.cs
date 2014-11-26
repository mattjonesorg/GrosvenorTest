using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grosvenor.Practicum.Services.Exceptions;
using Grosvenor.Practicum.Services.Model;
using NUnit.Framework;
using Grosvenor.Practicum.Services.Factories;

namespace Grosvenor.Practicum.UnitTests.Factories
{
    [TestFixture]
    public class MenuFactoryTests
    {
        private IMenuFactory _menuFactory;
        [SetUp]
        public void Setup()
        {
            _menuFactory = new MenuFactory();
        }

        [Test]
        public void GetMorningMenuShouldCreateMenuNamedMorning()
        {
            IMenu menu = _menuFactory.GetMenu("morning");
            Assert.That(menu, Is.Not.Null);
            Assert.That(menu.Name, Is.EqualTo("Morning"));
        }

        [Test]
        public void GetNightMenuShouldCreateMenuNamedNight()
        {
            IMenu menu = _menuFactory.GetMenu("night");
            Assert.That(menu, Is.Not.Null);
            Assert.That(menu.Name, Is.EqualTo("Night"));
        }

        [TestCase("morning")]
        [TestCase("Morning")]
        [TestCase("morniNg")]
        [TestCase("MORNING")]
        public void GetMenuShouldBeCaseInsensitive(string someCaseOfMorning)
        {
            IMenu menu = _menuFactory.GetMenu(someCaseOfMorning);
            Assert.That(menu, Is.Not.Null);
        }

        [Test]
        public void MorningMenuShouldHaveCorrectItems()
        {
            IMenu menu = _menuFactory.GetMenu("Morning");

            Assert.That(menu.Entree.Name, Is.EqualTo("eggs"));
            Assert.That(menu.Entree.MaxAllowablePerOrder, Is.EqualTo(1));

            Assert.That(menu.Side.Name, Is.EqualTo("toast"));
            Assert.That(menu.Side.MaxAllowablePerOrder, Is.EqualTo(1));

            Assert.That(menu.Drink.Name, Is.EqualTo("coffee"));
            Assert.That(menu.Drink.MaxAllowablePerOrder, Is.EqualTo(int.MaxValue));

            Assert.That(menu.Dessert, Is.Null);
        }

        [Test]
        public void NightMenuShouldHaveCorrectItems()
        {
            IMenu menu = _menuFactory.GetMenu("Night");

            Assert.That(menu.Entree.Name, Is.EqualTo("steak"));
            Assert.That(menu.Entree.MaxAllowablePerOrder, Is.EqualTo(1));

            Assert.That(menu.Side.Name, Is.EqualTo("potato"));
            Assert.That(menu.Side.MaxAllowablePerOrder, Is.EqualTo(int.MaxValue));

            Assert.That(menu.Drink.Name, Is.EqualTo("wine"));
            Assert.That(menu.Drink.MaxAllowablePerOrder, Is.EqualTo(1));

            Assert.That(menu.Dessert.Name, Is.EqualTo("cake"));
            Assert.That(menu.Dessert.MaxAllowablePerOrder, Is.EqualTo(1));
        }

        [Test]
        [ExpectedException(ExpectedException = typeof (MenuDefinitionNotFoundException))]
        public void ExceptionIsThrownWhenMenuDefinitionIsNotFound()
        {
            IMenu menu = _menuFactory.GetMenu("Bogus Value");
        }
    }
}
