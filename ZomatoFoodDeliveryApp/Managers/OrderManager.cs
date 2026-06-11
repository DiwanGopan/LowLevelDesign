using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZomatoFoodDeliveryApp.Models;

namespace ZomatoFoodDeliveryApp.Managers
{
    public class OrderManager
    {
        private readonly List<Order> _orders = new();

        private static OrderManager? _instance;

        private OrderManager()
        {
            // Private constructor
        }
        
        public static OrderManager GetInstance()
        {
            if (_instance == null)
            {
                _instance = new OrderManager();
            }
            return _instance;
        }

        public void AddOrder(Order order)
        {
            _orders.Add(order);
        }

        public void ListOrders()
        {
            Console.WriteLine("\n--- All Orders ---\n");

            foreach(Order order in _orders)
            {
                Console.WriteLine(
                    $"{order.GetType()} order for {order.User?.Name}" +
                    $" | Total: ₹{order.Total}" +
                    $" | At: {order.Scheduled}");
            }
        }
    }
}
