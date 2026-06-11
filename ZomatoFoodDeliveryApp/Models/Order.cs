using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZomatoFoodDeliveryApp.Strategies;

namespace ZomatoFoodDeliveryApp.Models
{
    public abstract class Order
    {
        private static int _nextOrderId = 0;

        public int OrderId { get; private set; }

        public User? User { get; private set; }

        public Restaurant? Restaurant { get; private set; }

        public List<MenuItem> Items { get; private set; }

        protected IPaymentStrategy? PaymentStrategy;

        public double Total { get; private set; }

        public string Scheduled { get; private set; }


        protected Order()
        {
            User = null;
            Restaurant = null;
            PaymentStrategy = null;
            Total = 0.0;
            Scheduled = string.Empty;
            Items = new List<MenuItem>();

            OrderId = ++_nextOrderId;
        }

        public bool ProcessPayment()
        {
            if (PaymentStrategy != null)
            {
                PaymentStrategy.Pay(Total);
                return true;
            }

            Console.WriteLine("Please choose a payment mode first");
            return false;
        }

        public abstract string GetType();

        public void SetUser(User user)
        {
            User = user;
        }

        public void SetRestaurant(Restaurant restaurant)
        {
            Restaurant = restaurant;
        }

        public void SetItems(List<MenuItem> items)
        {
            Items = items;

            Total = Items?.Sum(item => item.Price) ?? 0;
        }

        public void SetPaymentStrategy(IPaymentStrategy paymentStrategy)
        {
            PaymentStrategy = paymentStrategy;
        }

        public void SetScheduled(string scheduled)
        {
            Scheduled = scheduled;
        }

        public void SetTotal(double total)
        {
            Total = total;
        }


    }
}
