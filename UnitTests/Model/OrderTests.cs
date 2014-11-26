using Grosvenor.Practicum.Services.Exceptions;
using Grosvenor.Practicum.Services.Factories;
using Grosvenor.Practicum.Services.Model;
using NUnit.Framework;

namespace Grosvenor.Practicum.UnitTests.Model
{
    [TestFixture]
    public class OrderTests
    {
        private IMenu _menu;
        private Order _order;

        [SetUp]
        public void Setup()
        {
            _menu =
                new MenuBuilder().CreateMenuFor("test")
                    .WithEntree("pad see ew")
                    .WithSide("egg roll", 3)
                    .WithDrink("iced tea")
                    .Build();
            _order = new Order(_menu);
        }

        [Test]
        public void OrdersShouldBeCreatedWithNoItems()
        {
            Assert.That(_order.EntreeCount, Is.EqualTo(0));
            Assert.That(_order.SideCount, Is.EqualTo(0));
            Assert.That(_order.DrinkCount, Is.EqualTo(0));
            Assert.That(_order.DessertCount, Is.EqualTo(0));
        }

        [Test]
        public void ValidItemTypesShouldIncrementCountOrdered()
        {
            _order.AddItem(MenuItemType.Entree);
            _order.AddItem(MenuItemType.Side);
            _order.AddItem(MenuItemType.Drink);

            Assert.That(_order.EntreeCount, Is.EqualTo(1));
            Assert.That(_order.SideCount, Is.EqualTo(1));
            Assert.That(_order.DrinkCount, Is.EqualTo(1));
        }

        [Test]
        [ExpectedException(ExpectedException = typeof (TooManyOfMenuTypeException))]
        public void TooManyEntreesThrowsExceptionsWithDefaultCount()
        {
            _order.AddItem(MenuItemType.Entree);
            _order.AddItem(MenuItemType.Entree);
        }

        [Test]
        [ExpectedException(ExpectedException = typeof(TooManyOfMenuTypeException))]
        public void TooManyEntreesThrowsExceptions()
        {
            _order.AddItem(MenuItemType.Side);
            _order.AddItem(MenuItemType.Side);
            _order.AddItem(MenuItemType.Side);
            _order.AddItem(MenuItemType.Side);
        }

        [Test]
        [ExpectedException(ExpectedException = typeof(MenuTypeNotFoundException))]
        public void MenuTypeNotFoundExceptionIsThrownWhenMenuDoesNotHaveThisMenuType()
        {
            _order.AddItem(MenuItemType.Dessert);
        }

        [Test]
        public void ToStringWithOnlyEntreesShouldNotHaveTrailingComma()
        {
            _order.AddItem(MenuItemType.Entree);
            Assert.That(_order.ToString(), Is.EqualTo("pad see ew"));
        }

        [Test]
        public void ToStringShouldReturnItemsWithProperCount()
        {
            _order.AddItem(MenuItemType.Entree);
            _order.AddItem(MenuItemType.Side);
            _order.AddItem(MenuItemType.Side);
            _order.AddItem(MenuItemType.Drink);
            Assert.That(_order.ToString(), Is.EqualTo("pad see ew, egg roll(x2), iced tea"));
        }
    }
}
