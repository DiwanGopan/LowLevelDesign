using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZomatoFoodDeliveryApp.Factories;
using ZomatoFoodDeliveryApp.Managers;
using ZomatoFoodDeliveryApp.Models;
using ZomatoFoodDeliveryApp.Services;
using ZomatoFoodDeliveryApp.Strategies;

namespace ZomatoFoodDeliveryApp
{
    public class ZomatoApp
    {
        public ZomatoApp()
        {
            InitializeRestaurants();
        }

        public void InitializeRestaurants()
        {
            Restaurant restaurant1 = new("Bikaner", "Delhi");
            restaurant1.AddMenuItem(
                new MenuItem("P1", "Chole Bhature", 120));
            restaurant1.AddMenuItem(
                new MenuItem("P2", "Samosa", 15));

            Restaurant restaurant2 = new("Haldiram", "Kolkata");
            restaurant2.AddMenuItem(
                new MenuItem("P1", "Raj Kachori", 80));
            restaurant2.AddMenuItem(
                new MenuItem("P2", "Pav Bhaji", 100));
            restaurant2.AddMenuItem(
                new MenuItem("P3", "Dhokla", 50));

            Restaurant restaurant3 = new("Saravana Bhavan", "Chennai");
            restaurant3.AddMenuItem(
                new MenuItem("P1", "Masala Dosa", 90));
            restaurant3.AddMenuItem(
                new MenuItem("P2", "Idli Vada", 60));
            restaurant3.AddMenuItem(
                new MenuItem("P3", "Filter Coffee", 30));

            RestaurantManager restaurantManager =
                RestaurantManager.GetInstance();

            restaurantManager.AddRestaurant(restaurant1);
            restaurantManager.AddRestaurant(restaurant2);
            restaurantManager.AddRestaurant(restaurant3);
        }

        public List<Restaurant> SearchRestaurants(string location)
        {
            return RestaurantManager
                .GetInstance()
                .SearchByLocation(location);
        }

        public void SelectRestaurant(
            User user,
            Restaurant restaurant)
        {
            user.Cart.SetRestaurant(restaurant);
        }

        public void AddToCart(
            User user,
            string itemCode)
        {
            Restaurant? restaurant =
                user.Cart.Restaurant;

            if (restaurant == null)
            {
                Console.WriteLine(
                    "Please select a restaurant first.");

                return;
            }

            foreach (MenuItem item in restaurant.Menu)
            {
                if (item.Code.Equals(
                        itemCode,
                        StringComparison.OrdinalIgnoreCase))
                {
                    user.Cart.AddItem(item);
                    break;
                }
            }
        }

        public Order? CheckoutNow(
            User user,
            string orderType,
            IPaymentStrategy paymentStrategy)
        {
            return Checkout(
                user,
                orderType,
                paymentStrategy,
                new NowOrderFactory());
        }

        public Order? CheckoutScheduled(
            User user,
            string orderType,
            IPaymentStrategy paymentStrategy,
            string scheduleTime)
        {
            return Checkout(
                user,
                orderType,
                paymentStrategy,
                new ScheduledOrderFactory(scheduleTime));
        }

        public Order? Checkout(
            User user,
            string orderType,
            IPaymentStrategy paymentStrategy,
            IOrderFactory orderFactory)
        {
            if (user.Cart.IsEmpty())
            {
                return null;
            }

            Cart userCart = user.Cart;

            Restaurant orderedRestaurant =
                userCart.Restaurant!;

            List<MenuItem> itemsOrdered =
                userCart.Items;

            double totalCost =
                userCart.GetTotalCost();

            Order order = orderFactory.CreateOrder(
                user,
                userCart,
                orderedRestaurant,
                itemsOrdered,
                paymentStrategy,
                totalCost,
                orderType);

            OrderManager
                .GetInstance()
                .AddOrder(order);

            return order;
        }

        public void PayForOrder(
            User user,
            Order order)
        {
            bool isPaymentSuccess =
                order.ProcessPayment();

            if (isPaymentSuccess)
            {
                NotificationService.Notify(order);

                user.Cart.Clear();
            }
        }

        public void PrintUserCart(User user)
        {
            Console.WriteLine("Items in cart:");
            Console.WriteLine("------------------------------------");

            foreach (MenuItem item in user.Cart.Items)
            {
                Console.WriteLine(
                    $"{item.Code} : {item.Name} : ₹{item.Price}");
            }

            Console.WriteLine("------------------------------------");

            Console.WriteLine(
                $"Grand total : ₹{user.Cart.GetTotalCost()}");
        }
    }
}
