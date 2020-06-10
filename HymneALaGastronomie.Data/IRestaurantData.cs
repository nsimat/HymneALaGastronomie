using HymneALaGastronomie.CoreBusiness;
using System.Collections.Generic;
using System.Text;

namespace HymneALaGastronomie.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantsByName(string name);
        Restaurant GetRestaurantById(int id);
        Restaurant UpdateRestaurant(Restaurant updatedRestaurant);
        Restaurant CreateRestaurant(Restaurant newRestaurant);
        Restaurant Delete(int id);
        int GetCountOfRetaurants();
        int Commit();
    }
}
