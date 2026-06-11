using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZomatoFoodDeliveryApp.Models
{
    public class Restaurant
    {
        private static int _nextRestaurantId = 0;

        public int RestaurantId { get; private set; }

        public string Name { get; set; }

        public string Location { get; set; }

        public List<MenuItem> Menu { get; private set; }

        public Restaurant(string name, string location)
        {
            Name = name;
            Location = location;
            RestaurantId = ++_nextRestaurantId;
            Menu = new List<MenuItem>();
        }

        public void AddMenuItem(MenuItem item)
        {
            Menu.Add(item);
        }
    }
}
