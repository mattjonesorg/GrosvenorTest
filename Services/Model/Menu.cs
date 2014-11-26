using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grosvenor.Practicum.Services.Model
{
    public class Menu : IMenu
    {
        public Menu(string name, IMenuItem entree, IMenuItem side, IMenuItem drink, IMenuItem dessert)
        {
            MenuItems = new Dictionary<MenuItemType, IMenuItem>
                        {
                            {MenuItemType.Entree, entree},
                            {MenuItemType.Side, side},
                            {MenuItemType.Drink, drink},
                            {MenuItemType.Dessert, dessert}
                        };

            Name = name;
        }

        public string Name { get; private set; }
        public Dictionary<MenuItemType, IMenuItem> MenuItems { get; private set; }

        public IMenuItem Entree { get { return MenuItems[MenuItemType.Entree]; } }
        public IMenuItem Side { get { return MenuItems[MenuItemType.Side]; } }
        public IMenuItem Drink { get { return MenuItems[MenuItemType.Drink]; } }
        public IMenuItem Dessert { get { return MenuItems[MenuItemType.Dessert]; } }
    }
}
