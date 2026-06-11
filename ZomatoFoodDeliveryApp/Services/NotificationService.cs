using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZomatoFoodDeliveryApp.Models;

namespace ZomatoFoodDeliveryApp.Services
{
    public static class NotificationService
    {
        public static void Notify(Order order)
        {
            Console.WriteLine($"\nNotification: New {order.GetType()} order placed.");

            Console.WriteLine("---------------------------------------------");

            Console.WriteLine($"Order ID: {order.OrderId}");

            Console.WriteLine($"Customer: {order.User?.Name}");

            Console.WriteLine($"Restaurant: {order.Restaurant?.Name}");

            Console.WriteLine("Items Ordered:");

            foreach (MenuItem item in order.Items)
            {
                Console.WriteLine(
                    $"   - {item.Name} (₹{item.Price})");
            }

            Console.WriteLine($"Total: {order.Total}");

            Console.WriteLine($"Scheduled For: {order.Scheduled}");

            Console.WriteLine("Payment: Done");

            Console.WriteLine("---------------------------------------------");
        }
    }
}
