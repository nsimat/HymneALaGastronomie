using HymneALaGastronomie.CoreBusiness;
using System;
using System.Collections.Generic;
using System.Text;

namespace HymneALaGastronomie.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAllRestaurants();
    }
}
