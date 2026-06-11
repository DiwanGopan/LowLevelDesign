using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZomatoFoodDeliveryApp.Models;

namespace ZomatoFoodDeliveryApp.Managers
{
    public class RestaurantManager
    {
        private readonly List<Restaurant> _restaurants = new();

        private static RestaurantManager? _instance;

        private RestaurantManager()
        {
            // Private constructor to prevent instantiation from outside
        }

        public static RestaurantManager GetInstance()
        {
            if (_instance == null)
            {
                _instance = new RestaurantManager();
            }

            return _instance;
        }

        public void AddRestaurant(Restaurant restaurant)
        {
            _restaurants.Add(restaurant);
        }

        public List<Restaurant> SearchByLocation(string location)
        {
            return _restaurants
                .Where(r => string.Equals(
                    r.Location,
                    location,
                    StringComparison.OrdinalIgnoreCase))
                .ToList();
        }
    }
}
