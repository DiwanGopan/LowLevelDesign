using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZomatoFoodDeliveryApp.Models
{
    public class User
    {
        public int UserId { get; private set; }

        public string Name { get; set; }

        public string Address { get; set; }


        public Cart Cart { get; private set; }

        public User(int userId, string name, string address)
        {
            UserId = userId;
            Name = name;
            Address = address;
            Cart = new Cart();
        }

    }
}
