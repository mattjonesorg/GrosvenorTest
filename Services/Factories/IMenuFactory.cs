using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grosvenor.Practicum.Services.Model;

namespace Grosvenor.Practicum.Services.Factories
{
    public interface IMenuFactory
    {
        IMenu GetMenu(string menuName);
    }
}
