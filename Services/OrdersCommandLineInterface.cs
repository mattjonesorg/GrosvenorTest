using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Grosvenor.Practicum.Services.Model;

namespace Grosvenor.Practicum.Services
{
    public class OrdersCommandLineInterface : IOrdersCommandLineInterface
    {
        private readonly IOrderService _orderService;

        public OrdersCommandLineInterface(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public string Process(string[] args)
        {
            IOrder order = null;
            var returnString = new StringBuilder();

            // mash all the inputs together into a single string, this will take care of spaces and commas.
            String input = string.Join("", args, 0, args.Length);
            List<String> inputs = input.Split(',').ToList();

            if (inputs.Count > 0)
            {
                try
                {
                    order = _orderService.CreateOrder(inputs[0].Trim());

                    for (int i = 1; i < inputs.Count; i++)
                    {
                        var menuItemType = (MenuItemType)Enum.Parse(typeof (MenuItemType), inputs[i].Trim());
                        order.AddItem(menuItemType);
                    }
                    returnString.Append(order);
                }
                catch (Exception e)
                {
                    //Normally, I'd do some logging here, but for the purposes of this exercise, the exceptions that are thrown mean we stop processing.
                    //so, we'll just log that an error occurred.  But with the strongly typed exceptions we could easily be more explicit about the error.
                    if (order != null)
                    {
                        returnString.Append(order);
                    }
                    returnString.Append(", error");
                }
            }
            return returnString.ToString();
        }
    }
}