using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grosvenor.Practicum.Services.Model;

namespace Grosvenor.Practicum.Services.Factories
{
    public class MenuBuilder
    {
        private string name;
        private MenuItem entree;
        private MenuItem side;
        private MenuItem drink;
        private MenuItem dessert;

        public MenuBuilder CreateMenuFor(string name)
        {
            this.name = name;
            return this;
        }

        public MenuBuilder WithEntree(string name, int maxAllowable = 1)
        {
            this.entree = new MenuItem(name, maxAllowable);
            return this;
        }

        public MenuBuilder WithSide(string name, int maxAllowable = 1)
        {
            this.side = new MenuItem(name, maxAllowable);
            return this;
        }

        public MenuBuilder WithDrink(string name, int maxAllowable = 1)
        {
            this.drink = new MenuItem(name, maxAllowable);
            return this;
        }

        public MenuBuilder WithDessert(string name, int maxAllowable = 1)
        {
            this.dessert = new MenuItem(name, maxAllowable);
            return this;
        }

        public IMenu Build()
        {
            return new Menu(this.name, this.entree, this.side,this.drink,this.dessert);
        }
    }
}
