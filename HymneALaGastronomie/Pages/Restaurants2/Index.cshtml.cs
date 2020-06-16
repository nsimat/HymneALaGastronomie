using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HymneALaGastronomie.CoreBusiness;
using HymneALaGastronomie.Data;

namespace HymneALaGastronomie.Pages.Restaurants2
{
    public class IndexModel : PageModel
    {
        private readonly HymneALaGastronomie.Data.HymneALaGastronomieDbContext _context;

        public IndexModel(HymneALaGastronomie.Data.HymneALaGastronomieDbContext context)
        {
            _context = context;
        }

        public IList<Restaurant> Restaurant { get;set; }

        public async Task OnGetAsync()
        {
            Restaurant = await _context.Restaurants.ToListAsync();
        }
    }
}
