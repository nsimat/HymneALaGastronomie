using HymneALaGastronomie.CoreBusiness;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace HymneALaGastronomie.Data
{
    public class RestaurantDataRepository : IRestaurantData
    {
        private readonly HymneALaGastronomieDbContext dbContext;

        public RestaurantDataRepository(HymneALaGastronomieDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public int Commit()
        {
            return dbContext.SaveChanges();
        }

        public Restaurant CreateRestaurant(Restaurant newRestaurant)
        {
            dbContext.Restaurants.Add(newRestaurant);
            return newRestaurant;
        }

        public Restaurant Delete(int id)
        {
            var restaurant = GetRestaurantById(id);

            if(restaurant != null)
            {
                dbContext.Restaurants.Remove(restaurant);
            }
            return restaurant;
        }

        public int GetCountOfRetaurants()
        {
            return dbContext.Restaurants.Count();
        }

        public Restaurant GetRestaurantById(int id)
        {
            return dbContext.Restaurants.Find(id);
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name)
        {
            var restaurants = from r in dbContext.Restaurants
                              where r.Name.StartsWith(name) || string.IsNullOrEmpty(name)
                              orderby r.Name 
                              select r;

            return restaurants;
        }

        public Restaurant UpdateRestaurant(Restaurant updatedRestaurant)
        {
            var entity = dbContext.Restaurants.Attach(updatedRestaurant);
            entity.State = EntityState.Modified;
            return updatedRestaurant;
        }
    }
}
