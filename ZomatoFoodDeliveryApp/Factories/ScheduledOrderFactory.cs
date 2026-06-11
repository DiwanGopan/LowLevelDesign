using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZomatoFoodDeliveryApp.Models;
using ZomatoFoodDeliveryApp.Strategies;

namespace ZomatoFoodDeliveryApp.Factories
{
    public class ScheduledOrderFactory : IOrderFactory
    {
        private readonly string _scheduleTime;

        public ScheduledOrderFactory(string scheduleTime)
        {
            _scheduleTime = scheduleTime;
        }

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

            if (orderType.Equals(
                    "Delivery",
                    StringComparison.OrdinalIgnoreCase))
            {
                DeliveryOrder deliveryOrder = new();

                deliveryOrder.SetUserAddress(
                    user.Address);

                order = deliveryOrder;
            }
            else
            {
                PickupOrder pickupOrder = new();

                pickupOrder.SetRestaurantAddress(
                    restaurant.Location);

                order = pickupOrder;
            }

            order.SetUser(user);
            order.SetRestaurant(restaurant);
            order.SetItems(menuItems);
            order.SetPaymentStrategy(paymentStrategy);
            order.SetScheduled(_scheduleTime);
            order.SetTotal(totalCost);

            return order;
        }
    }
}
