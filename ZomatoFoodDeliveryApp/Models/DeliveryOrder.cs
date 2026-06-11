using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZomatoFoodDeliveryApp.Models
{
    public class DeliveryOrder : Order
    {
        public string UserAddress { get; private set; }

        public DeliveryOrder()
        {
            UserAddress = string.Empty;
        }

        public override string GetType()
        {
            return "Delivery";
        }

        public void SetUserAddress(string address)
        {
            UserAddress = address;
        }
    }
}
