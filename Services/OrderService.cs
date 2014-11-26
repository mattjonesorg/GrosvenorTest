using System;
using Grosvenor.Practicum.Services.Factories;
using Grosvenor.Practicum.Services.Model;

namespace Grosvenor.Practicum.Services
{
    internal class OrderService : IOrderService
    {
        private readonly IMenuFactory _menuFactory;

        public OrderService(IMenuFactory menuFactory)
        {
            _menuFactory = menuFactory;
        }

        public IOrder CreateOrder(String menuType)
        {
            IMenu menu = _menuFactory.GetMenu(menuType);

            return new Order(menu);
        }
    }
}
