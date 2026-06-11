using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZomatoFoodDeliveryApp.Strategies
{
    public class CreditCardPaymentStrategy
    {
        private readonly string _cardNumber;

        public CreditCardPaymentStrategy(string cardNumber)
        {
            _cardNumber = cardNumber;
        }

        public void Pay(double amount)
        {
            Console.WriteLine($"Paid ₹{amount} using Credit Card ({_cardNumber})");
        }
    }
}
