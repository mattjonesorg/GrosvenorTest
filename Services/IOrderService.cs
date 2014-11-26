using System;
using Grosvenor.Practicum.Services.Model;

namespace Grosvenor.Practicum.Services
{
    public interface IOrderService
    {
        IOrder CreateOrder(String menuType);
    }
}