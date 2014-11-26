using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grosvenor.Practicum.Services.Exceptions;

namespace Grosvenor.Practicum.Services.Model
{
    internal class Order : IOrder
    {
        private readonly IMenu _menu;
        private Dictionary<MenuItemType, int> _itemsOrdered; 

        public Order(IMenu menu)
        {
            _menu = menu;
            _itemsOrdered = new Dictionary<MenuItemType, int>
                            {
                                {MenuItemType.Entree, 0},
                                {MenuItemType.Side, 0},
                                {MenuItemType.Drink, 0},
                                {MenuItemType.Dessert, 0}
                            };
        }

        public int EntreeCount { get { return _itemsOrdered[MenuItemType.Entree]; } }
        public int SideCount { get { return _itemsOrdered[MenuItemType.Side]; } }
        public int DrinkCount { get { return _itemsOrdered[MenuItemType.Drink]; } }
        public int DessertCount { get { return _itemsOrdered[MenuItemType.Dessert]; } }

        public void AddItem(MenuItemType menuItemType)
        {
            if (_menu.MenuItems[menuItemType] == null)
            {
                throw new MenuTypeNotFoundException();
            }

            if (_itemsOrdered[menuItemType] < _menu.MenuItems[menuItemType].MaxAllowablePerOrder)
            {
                _itemsOrdered[menuItemType]++;
            }
            else
            {
                throw new TooManyOfMenuTypeException();
            }
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();

            _itemsOrdered.Keys.ToList().ForEach(menuItemType =>
                                                {
                                                    int count = _itemsOrdered[menuItemType];
                                                    if (count > 0)
                                                    {
                                                        stringBuilder.AppendFormat("{0}{1}{2}", (stringBuilder.Length > 0 ? ", " : string.Empty),
                                                            _menu.MenuItems[menuItemType].Name,
                                                            count > 1 ? string.Format("(x{0})", count) : string.Empty);
                                                    }
                                                });

            return stringBuilder.ToString();
        }
    }
}
