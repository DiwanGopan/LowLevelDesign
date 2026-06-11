using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZomatoFoodDeliveryApp.Models;
using ZomatoFoodDeliveryApp.Strategies;

namespace ZomatoFoodDeliveryApp.Factories
{
    public interface IOrderFactory
    {
        Order CreateOrder(
            User user,
            Cart cart,
            Restaurant restaurant,
            List<MenuItem> menuItems,
            IPaymentStrategy paymentStrategy,
            double totalCost,
            string orderType);
    }
}
