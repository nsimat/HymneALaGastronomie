using HymneALaGastronomie.CoreBusiness;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace HymneALaGastronomie.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantsByName(string name);
    }

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
    }
}
