using Grosvenor.Practicum.Services;
using Grosvenor.Practicum.Services.Factories;
using StructureMap;

namespace Grosvenor.Practicum.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Container container = Bootstrapper.GetIocContainer();

            IOrdersCommandLineInterface cli = container.GetInstance<IOrdersCommandLineInterface>();

            System.Console.WriteLine(cli.Process(args));
        }
    }
}
