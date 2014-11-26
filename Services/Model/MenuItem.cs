using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grosvenor.Practicum.Services.Model
{
    class MenuItem : IMenuItem
    {
        public MenuItem(string name, int maxAllowablePerOrder)
        {
            Name = name;
            MaxAllowablePerOrder = maxAllowablePerOrder;
        }

        public string Name { get; private set; }
        public int MaxAllowablePerOrder { get; private set; }
    }
}
