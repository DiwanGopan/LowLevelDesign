using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZomatoFoodDeliveryApp.Models
{
    public class PickupOrder : Order
    {
        public string RestaurantAddress { get; private set; }

        public PickupOrder()
        {
            RestaurantAddress = string.Empty;
        }

        public override string GetType()
        {
            return "Pickup";
        }

        public void SetRestaurantAddress(string address)
        {
            RestaurantAddress = address;
        }
    }
}
