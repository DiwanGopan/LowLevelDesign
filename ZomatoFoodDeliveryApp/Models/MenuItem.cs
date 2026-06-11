using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZomatoFoodDeliveryApp.Models
{
    public class MenuItem
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public int Price { get; set; }

        public MenuItem(string code, string name, int price)
        {
            Code = code;
            Name = name;
            Price = price;
        }
    }
}
