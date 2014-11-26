using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Grosvenor.Practicum.Services.Model
{
    /// <summary>
    /// IMenu represents the available options and the rules about the maximum items which can be ordered.
    /// Since there's only one rule now, I put it's configuration as a property on the IMenuItem.  
    /// </summary>
    public interface IMenu
    {
        string Name { get; }

        Dictionary<MenuItemType, IMenuItem> MenuItems { get; }

        IMenuItem Entree { get; }
        IMenuItem Side { get; }
        IMenuItem Drink { get; }
        IMenuItem Dessert { get; }
    }
}
