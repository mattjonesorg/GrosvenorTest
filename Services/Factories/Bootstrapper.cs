using StructureMap;

namespace Grosvenor.Practicum.Services.Factories
{
    public class Bootstrapper
    {
        public static Container GetIocContainer()
        {
            return new Container(new PracticumRegistry());
        }
    }
}
