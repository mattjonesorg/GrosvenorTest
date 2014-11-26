using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grosvenor.Practicum.Services.Exceptions;
using Grosvenor.Practicum.Services.Model;

namespace Grosvenor.Practicum.Services.Factories
{
    /// <summary>
    /// I like the fluent builder for creating these menus.  One could have made a class MorningMenu and EveningMenu.  Instead, I went with 
    /// a general class to hold the information about the menu.  I can see this factory implementation easily being replaced with something 
    /// which read XML, JSON, or YAML to configure the builders.  
    /// </summary>
    internal class MenuFactory : IMenuFactory
    {
        public IMenu GetMenu(string menuName)
        {
            IMenu menu = null;

            switch (menuName.ToLower())
            {
                case "morning":
                    menu =
                        new MenuBuilder().CreateMenuFor("Morning")
                            .WithEntree("eggs")
                            .WithSide("toast")
                            .WithDrink("coffee", int.MaxValue)
                            .Build();
                    break;
                case "night":
                    menu =
                        new MenuBuilder().CreateMenuFor("Night")
                            .WithEntree("steak")
                            .WithSide("potato", int.MaxValue)
                            .WithDrink("wine")
                            .WithDessert("cake")
                            .Build();
                    break;
                default:
                    throw new MenuDefinitionNotFoundException();
            }
            return menu;
        }
    }
}
