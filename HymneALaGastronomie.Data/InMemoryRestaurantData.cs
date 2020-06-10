using HymneALaGastronomie.CoreBusiness;
using System.Linq;
using System.Collections.Generic;

namespace HymneALaGastronomie.Data
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant { Id = 1, Name = "Pizza Domino", Location = "Namur", Cuisine = CuisineType.Italian},
                new Restaurant { Id = 2, Name = "Brussels Taco", Location = "Brussels", Cuisine = CuisineType.Mexican},
                new Restaurant { Id = 3, Name = "Kongo Makusa", Location = "Brussels", Cuisine = CuisineType.Congolease},
                new Restaurant { Id = 4, Name = "Le Fouquet", Location = "Paris", Cuisine = CuisineType.French},
                new Restaurant { Id = 5, Name = "Le Cèdre du Liban", Location = "Namur", Cuisine = CuisineType.Lebanese}
            };
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name = null)
        {
            return from r in restaurants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
        }

        public Restaurant GetRestaurantById(int id)
        {
            return restaurants.SingleOrDefault(r => r.Id == id);
        }

        public Restaurant CreateRestaurant(Restaurant newRestaurant)
        {
            restaurants.Add(newRestaurant);
            newRestaurant.Id = restaurants.Max(r => r.Id) + 1;

            return newRestaurant;
        }

        public Restaurant UpdateRestaurant(Restaurant updatedRestaurant)
        {
            var restaurant = restaurants.SingleOrDefault(r => r.Id == updatedRestaurant.Id);

            if(restaurant != null)
            {
                restaurant.Name = updatedRestaurant.Name;
                restaurant.Location = updatedRestaurant.Location;
                restaurant.Cuisine = updatedRestaurant.Cuisine;
            }
            return restaurant;
        }

        public int Commit()
        {
            return 0;
        }

        public Restaurant Delete(int id)
        {
            var restaurant = restaurants.FirstOrDefault(r => r.Id == id);
            if(restaurant != null)
            {
                restaurants.Remove(restaurant);
            }
            return restaurant;

        }

        public int GetCountOfRetaurants()
        {
            return restaurants.Count();
        }
    }
}
