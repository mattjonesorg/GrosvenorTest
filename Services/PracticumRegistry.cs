using Grosvenor.Practicum.Services.Factories;
using StructureMap.Configuration.DSL;

namespace Grosvenor.Practicum.Services
{
    public class PracticumRegistry : Registry
    {
        public PracticumRegistry()
        {
            For<IOrderService>().Use<OrderService>();
            For<IMenuFactory>().Use<MenuFactory>();
            For<IOrdersCommandLineInterface>().Use<OrdersCommandLineInterface>();
        }
    }
}
