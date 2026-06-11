using ZomatoFoodDeliveryApp;
using ZomatoFoodDeliveryApp.Models;
using ZomatoFoodDeliveryApp.Strategies;



ZomatoApp zomato = new();

User user = new(101, "Aditya", "Delhi");

Console.WriteLine($"User: {user.Name} is active.");


List<Restaurant> restaurantList = zomato.SearchRestaurants("Delhi");

if (restaurantList.Count == 0)
{
    Console.WriteLine("No restaurants found!");
    return;
}

Console.WriteLine("Found Restaurants:");


foreach (Restaurant restaurant in restaurantList)
{
    Console.WriteLine($" - {restaurant.Name}");
}


// User selects a restaurant
zomato.SelectRestaurant(user, restaurantList[0]);


// User adds items to the cart
zomato.AddToCart(user, "P1");
zomato.AddToCart(user, "P2");


zomato.PrintUserCart(user);

// User checks out
Order? order = zomato.CheckoutNow(
    user,
    "Delivery",
    new UpiPaymentStrategy("1234567890"));

if (order == null)
{
    Console.WriteLine("Checkout failed.");
    return;
}

// User pays for the order
zomato.PayForOrder(user, order);


// User pays for the order
zomato.PayForOrder(user, order);