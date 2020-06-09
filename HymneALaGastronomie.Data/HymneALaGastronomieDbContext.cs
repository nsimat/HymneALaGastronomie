using HymneALaGastronomie.CoreBusiness;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HymneALaGastronomie.Data
{
    public class HymneALaGastronomieDbContext : DbContext
    {
        public HymneALaGastronomieDbContext(DbContextOptions<HymneALaGastronomieDbContext> options) : base(options)
        {

        }
        public DbSet<Restaurant> Restaurants { get; set; }
    }
}
