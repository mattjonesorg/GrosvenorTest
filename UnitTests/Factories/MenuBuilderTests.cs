using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grosvenor.Practicum.Services.Factories;
using Grosvenor.Practicum.Services.Model;
using NUnit.Framework;

namespace Grosvenor.Practicum.UnitTests.Factories
{
    [TestFixture]
    public class MenuBuilderTests
    {
        [Test]
        public void MenuBuilderShouldCreateMenuWithCorrectNames()
        {
            IMenu menu =
                new MenuBuilder().CreateMenuFor("Morning")
                    .WithEntree("eggs")
                    .WithDrink("coffee")
                    .WithSide("toast")
                    .WithDessert("cinnamon roll")
                    .Build();

            Assert.That(menu.Name, Is.EqualTo("Morning"));
            Assert.That(menu.Entree.Name, Is.EqualTo("eggs"));
            Assert.That(menu.Drink.Name, Is.EqualTo("coffee"));
            Assert.That(menu.Side.Name, Is.EqualTo("toast"));
            Assert.That(menu.Dessert.Name, Is.EqualTo("cinnamon roll"));
        }

        [Test]
        public void MenuBuilderShouldCreateMenuWithCorrectMaxQuantities()
        {
            IMenu menu =
                new MenuBuilder().CreateMenuFor("Morning")
                    .WithEntree("eggs", 2)
                    .WithDrink("coffee", 0)
                    .WithSide("toast", 3)
                    .WithDessert("cinnamon roll", 4)
                    .Build();

            Assert.That(menu.Entree.MaxAllowablePerOrder, Is.EqualTo(2));
            Assert.That(menu.Drink.MaxAllowablePerOrder, Is.EqualTo(0));
            Assert.That(menu.Side.MaxAllowablePerOrder, Is.EqualTo(3));
            Assert.That(menu.Dessert.MaxAllowablePerOrder, Is.EqualTo(4));
        }
    }
}
