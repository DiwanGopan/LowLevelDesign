using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZomatoFoodDeliveryApp.Strategies
{
    public class UpiPaymentStrategy : IPaymentStrategy
    {
        private readonly string _mobile;

        public UpiPaymentStrategy(string mobile)
        {
            _mobile = mobile;
        }

        public void Pay(double amount)
        {
            Console.WriteLine($"Paid ₹{amount} using UPI ({_mobile})");
        }
    }
}
