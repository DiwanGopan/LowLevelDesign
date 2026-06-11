using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZomatoFoodDeliveryApp.Models
{
    public class Cart
    {
        public Restaurant? Restaurant { get; private set; }

        public List<MenuItem> Items { get; private set; }

        public Cart()
        {
            Restaurant = null;
            Items = new List<MenuItem>();
        }

        public void AddItem(MenuItem item)
        {
            if (Restaurant == null)
            {
                Console.Error.WriteLine("Cart: Set a restaurant before adding items.");
                return;
            }

            Items.Add(item);
        }

        public double GetTotalCost()
        {
            return Items.Sum(item => item.Price);
        }

        public bool IsEmpty()
        {
            return Restaurant == null || Items.Count == 0;
        }

        public void Clear()
        {
            Items.Clear();
            Restaurant = null;
        }

        public void SetRestaurant(Restaurant restaurant)
        {
            Restaurant = restaurant;
        }
    }
}
