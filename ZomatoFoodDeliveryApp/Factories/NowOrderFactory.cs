using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZomatoFoodDeliveryApp.Models;
using ZomatoFoodDeliveryApp.Strategies;
using ZomatoFoodDeliveryApp.Utils;

namespace ZomatoFoodDeliveryApp.Factories
{
    public class NowOrderFactory : IOrderFactory
    {
        public Order CreateOrder(
            User user,
            Cart cart,
            Restaurant restaurant,
            List<MenuItem> menuItems,
            IPaymentStrategy paymentStrategy,
            double totalCost,
            string orderType)
        {
            Order order;

            if (orderType.Equals("Delivery", StringComparison.OrdinalIgnoreCase))
            {
                DeliveryOrder deliveryOrder = new DeliveryOrder();

                deliveryOrder.SetUserAddress(user.Address);

                order = deliveryOrder;
            }
            else
            {
                PickupOrder pickupOrder = new PickupOrder();

                pickupOrder.SetRestaurantAddress(restaurant.Location);

                order = pickupOrder;
            }

            order.SetUser(user);
            order.SetRestaurant(restaurant);
            order.SetItems(menuItems);
            order.SetPaymentStrategy(paymentStrategy);
            order.SetScheduled(TimeUtils.GetCurrentTime());
            order.SetTotal(totalCost);

            return order;
        }
    }
}

